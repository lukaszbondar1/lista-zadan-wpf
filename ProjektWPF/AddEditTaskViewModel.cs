using Microsoft.EntityFrameworkCore;
using ProjektWPF.Data;
using ProjektWPF.models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace ProjektWPF
{
    public class AddEditTaskViewModel : INotifyPropertyChanged
    {
        private readonly AppDbContext _db = new();
        private List<SubTaskItem> OriginalSubTasks { get; set; } = new();
        public ObservableCollection<Category> Categories { get; set; }
        public TaskItem Task { get; set; }
        public Array PriorityLevels => Enum.GetValues(typeof(PriorityLevel));
        public ICommand SaveCommand { get; }

        public AddEditTaskViewModel(TaskItem? task = null)
        {
            Categories = new ObservableCollection<Category>(_db.Categories.ToList());

            if (task != null)
            {
                var loaded = _db.Tasks
                    .Include(t => t.SubTasks)
                    .First(t => t.Id == task.Id);
                loaded.SubTasks = new ObservableCollection<SubTaskItem>(loaded.SubTasks);
                Task = loaded;
                OriginalSubTasks = loaded.SubTasks.ToList();
            }
            else
            {
                Task = new TaskItem
                {
                    SubTasks = new ObservableCollection<SubTaskItem>(),
                };
            }

            Task.Category = null;

            SaveCommand = new RelayCommand(Save);
        }

        private void Save()
        {
            if (string.IsNullOrWhiteSpace(Task.Name))
            {
                MessageBox.Show("Nazwa zadania jest wymagana.");
                return;
            }

            Task.Category = null;

            _db.Entry(Task).State = Task.Id == 0 ? EntityState.Added : EntityState.Modified;

            var currentIds = Task.SubTasks.Select(s => s.Id).ToList();
            var toRemove = OriginalSubTasks.Where(s => !currentIds.Contains(s.Id)).ToList();

            if (toRemove.Any())
            {
                _db.SubTasks.RemoveRange(toRemove);
            }

            foreach (var sub in Task.SubTasks)
            {
                sub.TaskItemId = Task.Id;
                if (sub.Id == 0)
                    _db.SubTasks.Add(sub);
                else
                    _db.SubTasks.Update(sub);
            }

            _db.SaveChanges();
            MessageBox.Show("Zadanie zapisane.");
            Application.Current.Windows
                .OfType<Window>()
                .FirstOrDefault(w => w is AddEditTaskWindow)?.Close();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}