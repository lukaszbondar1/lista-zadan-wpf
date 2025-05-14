using ProjektWPF.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace ProjektWPF
{
    public class FilterViewModel
    {
        public ObservableCollection<Category> Categories { get; set; }

        public Category? SelectedCategory { get; set; }
        public PriorityLevel? SelectedPriority { get; set; }
        public bool? SelectedStatus { get; set; }
        public DateTime? DueBefore { get; set; }

        public ICommand ApplyCommand { get; }

        public Action? OnApply;

        public FilterViewModel(ObservableCollection<Category> categories)
        {
            Categories = categories;
            ApplyCommand = new RelayCommand(Apply);
        }

        private void Apply()
        {
            OnApply?.Invoke();
            foreach (var w in App.Current.Windows.OfType<Window>())
            {
                if (w is FilterWindow) w.Close();
            }
        }
    }
}
