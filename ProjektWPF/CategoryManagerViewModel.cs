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

namespace ProjektWPF
{
    public class CategoryManagerViewModel : INotifyPropertyChanged
    {
        private readonly AppDbContext _db = new();

        public ObservableCollection<Category> Categories { get; set; }

        private Category? _selectedCategory;
        public Category? SelectedCategory
        {
            get => _selectedCategory;
            set { _selectedCategory = value; OnPropertyChanged(); }
        }

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public CategoryManagerViewModel()
        {
            Categories = new ObservableCollection<Category>(_db.Categories.ToList());

            AddCommand = new RelayCommand(Add);
            EditCommand = new RelayCommand(Edit, () => SelectedCategory != null);
            DeleteCommand = new RelayCommand(Delete, () => SelectedCategory != null);
        }

        private void Add()
        {
            string? name = PromptDialog.Show("Nowa kategoria", "Wpisz nazwę kategorii:");
            if (!string.IsNullOrWhiteSpace(name))
            {
                var category = new Category { Name = name };
                _db.Categories.Add(category);
                _db.SaveChanges();
                Categories.Add(category);
            }
        }

        private void Edit()
        {
            if (SelectedCategory == null) return;
            string? name = PromptDialog.Show("Edytuj kategorię", "Nowa nazwa:", SelectedCategory.Name);
            if (!string.IsNullOrWhiteSpace(name))
            {
                SelectedCategory.Name = name;
                _db.Categories.Update(SelectedCategory);
                _db.SaveChanges();
                OnPropertyChanged(nameof(Categories));
            }
        }

        private void Delete()
        {
            if (SelectedCategory == null) return;

            var taskCount = _db.Tasks.Count(t => t.CategoryId == SelectedCategory.Id);
            if (taskCount > 0)
            {
                MessageBox.Show("Nie można usunąć kategorii, ponieważ zawiera przypisane zadania.",
                                "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (MessageBox.Show("Usunąć kategorię?", "Potwierdzenie", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _db.Categories.Remove(SelectedCategory);
                _db.SaveChanges();
                Categories.Remove(SelectedCategory);
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
