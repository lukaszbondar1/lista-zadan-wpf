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

        public ICommand SaveCommand { get; }

        public AddEditTaskViewModel(TaskItem? task = null)
        {
            Categories = new ObservableCollection<Category>(_db.Categories.ToList());

            if (task != null)
            {
                // Pobierz pełne dane zadania z podzadaniami z bazy
                var loaded = _db.Tasks
                            .Include(t => t.SubTasks)
                            .First(t => t.Id == task.Id);

                loaded.SubTasks = new ObservableCollection<SubTaskItem>(loaded.SubTasks);
                Task = loaded;


                // Skopiuj oryginalne podzadania do porównania przy zapisie
                OriginalSubTasks = Task.SubTasks
                    .Select(s => new SubTaskItem
                    {
                        Id = s.Id,
                        TaskItemId = s.TaskItemId,
                        Name = s.Name,
                        IsDone = s.IsDone
                    }).ToList();
            }
            else
            {
                Task = new TaskItem
                {
                    SubTasks = new ObservableCollection<SubTaskItem>()
                };
            }

            // Bardzo ważne: nie ustawiaj Task.Category!
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

            // Upewnij się, że nie ma podpiętej instancji Category
            Task.Category = null;

            // Rejestruj zadanie
            _db.Entry(Task).State = Task.Id == 0 ? EntityState.Added : EntityState.Modified;

            // Usuń z bazy te podzadania, które zostały usunięte w UI
            var currentIds = Task.SubTasks.Select(s => s.Id).ToList();
            var toRemove = OriginalSubTasks.Where(s => !currentIds.Contains(s.Id)).ToList();
            if (toRemove.Any())
            {
                _db.SubTasks.RemoveRange(toRemove);
            }

            // Zapisz obecne podzadania
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
