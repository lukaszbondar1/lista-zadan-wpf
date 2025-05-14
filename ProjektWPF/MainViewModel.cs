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

        public ICommand AddTaskCommand { get; }
        public ICommand FilterCommand { get; }
        public ICommand AddCategoryCommand { get; }
        public ICommand EditTaskCommand { get; }


        public MainViewModel()
        {
            AddTaskCommand = new RelayCommand(AddTask);
            FilterCommand = new RelayCommand(OpenFilter);
            AddCategoryCommand = new RelayCommand(AddCategory);
            EditTaskCommand = new RelayCommand<TaskItem>(EditTask);
            LoadData();
        }

        private void LoadData()
        {
            _db.Categories.Load();
            _db.Tasks.Include(t => t.Category).Load();

            Categories = _db.Categories.Local.ToObservableCollection();
            FilteredTasks = new ObservableCollection<TaskItem>(_db.Tasks.Local);
            OnPropertyChanged(nameof(Categories));
            OnPropertyChanged(nameof(FilteredTasks));
            OnPropertyChanged(nameof(TaskSummary));
        }

        private void ApplyFilter()
        {
            var tasks = _db.Tasks.Include(t => t.Category).AsQueryable();

            if (!string.IsNullOrWhiteSpace(SearchText))
                tasks = tasks.Where(t => t.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase));

            if (_filter?.SelectedCategory != null)
                tasks = tasks.Where(t => t.CategoryId == _filter.SelectedCategory.Id);

            if (_filter?.SelectedPriority != null)
                tasks = tasks.Where(t => t.Priority == _filter.SelectedPriority);

            if (_filter?.SelectedStatus != null)
                tasks = tasks.Where(t => t.IsCompleted == _filter.SelectedStatus);

            if (_filter?.DueBefore != null)
                tasks = tasks.Where(t => t.DueDate != null && t.DueDate <= _filter.DueBefore);

            FilteredTasks = new ObservableCollection<TaskItem>(tasks.ToList());
            OnPropertyChanged(nameof(FilteredTasks));
            OnPropertyChanged(nameof(TaskSummary));
        }

        private void AddTask()
        {
            var window = new AddEditTaskWindow();
            window.Owner = Application.Current.MainWindow;
            window.ShowDialog();
            LoadData(); // odświeżenie
        }
        private void EditTask(TaskItem task)
        {
            if (task == null) return;

            var window = new AddEditTaskWindow(task);
            window.Owner = Application.Current.MainWindow;
            window.ShowDialog();
            LoadData(); // odświeżenie listy po edycji
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
            LoadData(); // odświeżenie listy po zmianach
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
