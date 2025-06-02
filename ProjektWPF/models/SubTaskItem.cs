using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjektWPF.models
{
    // Models/SubTaskItem.cs
    public class SubTaskItem : INotifyPropertyChanged
    {
        [Key]
        public int Id { get; set; }
        public int TaskItemId { get; set; }
        public TaskItem? TaskItem { get; set; }

        private string _name = "";
        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        private bool _isDone;
        public bool IsDone
        {
            get => _isDone;
            set { _isDone = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }


}
