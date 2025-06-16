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
    public class FilterViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Category> Categories { get; set; }

        public IEnumerable<PriorityLevel> PriorityLevels => Enum.GetValues(typeof(PriorityLevel)).Cast<PriorityLevel>();

        private Category? _selectedCategory;
        public Category? SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged();
            }
        }

        private PriorityLevel? _selectedPriority;
        public PriorityLevel? SelectedPriority
        {
            get => _selectedPriority;
            set
            {
                _selectedPriority = value;
                OnPropertyChanged();
            }
        }

        private StatusOption? _selectedStatusOption;
        public StatusOption? SelectedStatusOption
        {
            get => _selectedStatusOption;
            set
            {
                _selectedStatusOption = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SelectedStatus)); // odświeżenie powiązanej właściwości
            }
        }

        private DateTime? _dueBefore;
        public DateTime? DueBefore
        {
            get => _dueBefore;
            set
            {
                _dueBefore = value;
                OnPropertyChanged();
            }
        }

        public ICommand ApplyCommand { get; }
        public ICommand ResetCommand { get; }

        public Action? OnApply;

        public bool? SelectedStatus => SelectedStatusOption?.Value;

        public FilterViewModel(ObservableCollection<Category> categories)
        {
            Categories = categories;
            ApplyCommand = new RelayCommand(Apply);
            ResetCommand = new RelayCommand(Reset);
            SelectedStatusOption = StatusOptions.FirstOrDefault();
        }

        private void Apply()
        {
            OnApply?.Invoke();
        }

        private void Reset()
        {
            SelectedCategory = null;
            SelectedPriority = null;
            SelectedStatusOption = StatusOptions.FirstOrDefault();
            DueBefore = null;
            OnApply?.Invoke();
        }

        public class StatusOption
        {
            public string Name { get; set; } = "";
            public bool? Value { get; set; }
        }

        public List<StatusOption> StatusOptions { get; } = new()
        {
            new() { Name = "(wszystkie)", Value = null },
            new() { Name = "Ukończone", Value = true },
            new() { Name = "Nieukończone", Value = false },
        };

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}