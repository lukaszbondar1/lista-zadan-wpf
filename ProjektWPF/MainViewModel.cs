using ProjektWPF.Data;
using ProjektWPF.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace ProjektWPF
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly AppDbContext _db = new();
        private FilterViewModel _filter;
        private ObservableCollection<TaskItem> _allTasks = new();

        public ObservableCollection<TaskItem> FilteredTasks { get; set; } = new();
        public ObservableCollection<Category> Categories { get; set; } = new();

        private Category? _selectedCategory;
        public Category? SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged();
                ApplyFilter();
            }
        }

        private string _searchText = "";
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
                ApplyFilter();
            }
        }

        public string TaskSummary => $"Zadań: {FilteredTasks.Count}, ukończone: {FilteredTasks.Count(t => t.IsCompleted)}";

        public ICommand DeleteTaskCommand { get; }
        public ICommand AddTaskCommand { get; }
        public ICommand FilterCommand { get; }
        public ICommand AddCategoryCommand { get; }
        public ICommand EditTaskCommand { get; }
        public ICommand UpdateSubTaskCommand { get; }

        public MainViewModel()
        {
            DeleteTaskCommand = new RelayCommand<TaskItem>(DeleteTask);
            AddTaskCommand = new RelayCommand(AddTask);
            FilterCommand = new RelayCommand(OpenFilter);
            AddCategoryCommand = new RelayCommand(AddCategory);
            EditTaskCommand = new RelayCommand<TaskItem>(EditTask);
            UpdateSubTaskCommand = new RelayCommand<SubTaskItem>(UpdateSubTask);
            LoadData();
        }

        private void LoadData()
        {
            using var db = new AppDbContext();

            Categories.Clear();
            var categories = db.Categories.ToList();
            foreach (var category in categories)
            {
                Categories.Add(category);
            }

            _allTasks.Clear();
            var tasks = db.Tasks.Include(t => t.Category).Include(t => t.SubTasks).ToList();

            foreach (var task in tasks)
            {
                // Upewnij się, że SubTasks są prawidłowo załadowane
                if (task.SubTasks != null)
                {
                    foreach (var subTask in task.SubTasks)
                    {
                        subTask.PropertyChanged += SubTask_PropertyChanged;
                    }
                }
                _allTasks.Add(task);
            }

            ApplyFilter();
            OnPropertyChanged(nameof(Categories));
            OnPropertyChanged(nameof(TaskSummary));
        }

        private void SubTask_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SubTaskItem.IsDone) && sender is SubTaskItem subTask)
            {
                UpdateSubTask(subTask);
            }
        }

        private void UpdateSubTask(SubTaskItem subTask)
        {
            if (subTask == null) return;

            try
            {
                using var db = new AppDbContext();
                var dbSubTask = db.SubTasks.FirstOrDefault(st => st.Id == subTask.Id);
                if (dbSubTask != null)
                {
                    dbSubTask.IsDone = subTask.IsDone;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas aktualizacji podzadania: {ex.Message}", "Błąd",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ApplyFilter()
        {
            var filteredTasks = _allTasks.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                filteredTasks = filteredTasks.Where(t =>
                    t.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase));
            }

            if (SelectedCategory != null)
            {
                filteredTasks = filteredTasks.Where(t => t.CategoryId == SelectedCategory.Id);
            }

            if (_filter?.SelectedCategory != null)
            {
                filteredTasks = filteredTasks.Where(t => t.CategoryId == _filter.SelectedCategory.Id);
            }

            if (_filter?.SelectedPriority != null)
            {
                filteredTasks = filteredTasks.Where(t => t.Priority == _filter.SelectedPriority);
            }

            if (_filter?.SelectedStatus != null)
            {
                filteredTasks = filteredTasks.Where(t => t.IsCompleted == _filter.SelectedStatus);
            }

            if (_filter?.DueBefore != null)
            {
                filteredTasks = filteredTasks.Where(t =>
                    t.DueDate != null && t.DueDate <= _filter.DueBefore);
            }

            FilteredTasks.Clear();
            foreach (var task in filteredTasks)
            {
                FilteredTasks.Add(task);
            }

            OnPropertyChanged(nameof(FilteredTasks));
            OnPropertyChanged(nameof(TaskSummary));
        }

        private void AddTask()
        {
            var window = new AddEditTaskWindow();
            window.Owner = Application.Current.MainWindow;
            window.ShowDialog();
            LoadData();
        }

        private void EditTask(TaskItem task)
        {
            if (task == null) return;

            var window = new AddEditTaskWindow(task);
            window.Owner = Application.Current.MainWindow;
            window.ShowDialog();
            LoadData();
        }

        private void DeleteTask(TaskItem? task)
        {
            if (task == null) return;

            if (MessageBox.Show($"Czy na pewno chcesz usunąć zadanie: '{task.Name}'?", "Potwierdzenie",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                using var db = new AppDbContext();

                var taskToDelete = db.Tasks.Include(t => t.SubTasks).FirstOrDefault(t => t.Id == task.Id);
                if (taskToDelete != null)
                {
                    db.SubTasks.RemoveRange(taskToDelete.SubTasks);
                    db.Tasks.Remove(taskToDelete);
                    db.SaveChanges();
                }

                LoadData();
            }
        }

        private void OpenFilter()
        {
            _filter = new FilterViewModel(Categories)
            {
                SelectedCategory = SelectedCategory,
                OnApply = ApplyFilter
            };
            var filterWindow = new FilterWindow(_filter)
            {
                Owner = Application.Current.MainWindow
            };
            filterWindow.ShowDialog();
        }

        private void AddCategory()
        {
            var window = new CategoryManagerWindow();
            window.Owner = Application.Current.MainWindow;
            window.ShowDialog();
            LoadData();
        }

        public ICommand ClearCategoryFilterCommand => new RelayCommand(() =>
        {
            SelectedCategory = null;

            if (_filter != null)
            {
                _filter.SelectedCategory = null;
                _filter.SelectedPriority = null;
                _filter.SelectedStatus = null;
                _filter.DueBefore = null;
            }

            ApplyFilter();
        });

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Odłącz event handlery
                foreach (var task in _allTasks)
                {
                    if (task.SubTasks != null)
                    {
                        foreach (var subTask in task.SubTasks)
                        {
                            subTask.PropertyChanged -= SubTask_PropertyChanged;
                        }
                    }
                }
                _db?.Dispose();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
