using ProjektWPF.Data;
using ProjektWPF.models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace ProjektWPF
{
    public class AddEditTaskViewModel : INotifyPropertyChanged
    {
        private readonly AppDbContext _db = new();
        public ObservableCollection<Category> Categories { get; set; }

        public TaskItem Task { get; set; }

        public ICommand SaveCommand { get; }

        public AddEditTaskViewModel(TaskItem? task = null)
        {
            Categories = new ObservableCollection<Category>(_db.Categories.ToList());
            Task = task ?? new TaskItem { SubTasks = new ObservableCollection<SubTaskItem>() };
            SaveCommand = new RelayCommand(Save);
        }

        private void Save()
        {
            if (string.IsNullOrWhiteSpace(Task.Name))
            {
                MessageBox.Show("Nazwa zadania jest wymagana.");
                return;
            }

            if (Task.Id == 0)
            {
                _db.Tasks.Add(Task);
            }
            else
            {
                _db.Tasks.Update(Task);
                _db.SubTasks.RemoveRange(_db.SubTasks.Where(s => s.TaskItemId == Task.Id)); // usuń stare
            }

            foreach (var sub in Task.SubTasks)
            {
                sub.TaskItemId = Task.Id;
                _db.SubTasks.Add(sub);
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
