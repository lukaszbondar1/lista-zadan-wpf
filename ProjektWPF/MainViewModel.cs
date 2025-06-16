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

        public FilterViewModel FilterViewModel { get; }

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

        private bool _isDarkTheme = false;
        public bool IsDarkTheme
        {
            get => _isDarkTheme;
            set
            {
                _isDarkTheme = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ThemeIcon));
                OnPropertyChanged(nameof(ThemeText));
            }
        }

        public string ThemeIcon => IsDarkTheme ? "☀️" : "🌙";
        public string ThemeText => IsDarkTheme ? "Jasny" : "Ciemny";

        public string TaskSummary => $"Zadań: {FilteredTasks.Count}, ukończone: {FilteredTasks.Count(t => t.IsCompleted)}";

        public ICommand DeleteTaskCommand { get; }
        public ICommand AddTaskCommand { get; }
        public ICommand FilterCommand { get; }
        public ICommand AddCategoryCommand { get; }
        public ICommand EditTaskCommand { get; }
        public ICommand ToggleThemeCommand { get; }

        public MainViewModel()
        {
            DeleteTaskCommand = new RelayCommand<TaskItem>(DeleteTask);
            AddTaskCommand = new RelayCommand(AddTask);
            AddCategoryCommand = new RelayCommand(AddCategory);
            EditTaskCommand = new RelayCommand<TaskItem>(EditTask);
            ToggleThemeCommand = new RelayCommand(ToggleTheme);

            Categories = new ObservableCollection<Category>(_db.Categories.ToList());

            FilterViewModel = new FilterViewModel(Categories);
            FilterViewModel.OnApply = ApplyFilter;

            LoadData();
            ApplyTheme();
        }

        private void ToggleTheme()
        {
            IsDarkTheme = !IsDarkTheme;
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            var mainWindow = Application.Current.MainWindow;
            if (mainWindow == null) return;

            var themeKey = IsDarkTheme ? "DarkTheme" : "LightTheme";
            var themeDict = mainWindow.Resources[themeKey] as ResourceDictionary;

            if (themeDict != null)
            {

                foreach (var key in themeDict.Keys)
                {
                    if (mainWindow.Resources.Contains(key))
                    {
                        mainWindow.Resources[key] = themeDict[key];
                    }
                }
            }
        }

        private void LoadData()
        {
            using var db = new AppDbContext();

            Categories.Clear();
            foreach (var category in db.Categories.ToList())
            {
                Categories.Add(category);
            }

            FilteredTasks = new ObservableCollection<TaskItem>(
                db.Tasks.Include(t => t.Category).Include(t => t.SubTasks).ToList()
            );

            OnPropertyChanged(nameof(FilteredTasks));
            OnPropertyChanged(nameof(TaskSummary));
        }


        private void ApplyFilter()
        {
            var tasks = _db.Tasks
                .Include(t => t.Category)
                .Include(t => t.SubTasks)
                .ToList()
                .AsEnumerable();

            if (!string.IsNullOrWhiteSpace(SearchText))
                tasks = tasks.Where(t => t.Name != null && t.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase));

            if (FilterViewModel.SelectedCategory != null)
                tasks = tasks.Where(t => t.CategoryId == FilterViewModel.SelectedCategory.Id);

            if (FilterViewModel.SelectedPriority != null)
                tasks = tasks.Where(t => t.Priority == FilterViewModel.SelectedPriority);

            if (FilterViewModel.SelectedStatus != null)
                tasks = tasks.Where(t => t.IsCompleted == FilterViewModel.SelectedStatus);

            if (FilterViewModel.DueBefore != null)
                tasks = tasks.Where(t => t.DueDate != null && t.DueDate <= FilterViewModel.DueBefore);

            FilteredTasks = new ObservableCollection<TaskItem>(tasks);
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

        private void AddCategory()
        {
            var window = new CategoryManagerWindow();
            window.Owner = Application.Current.MainWindow;
            window.ShowDialog();
            LoadData();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}