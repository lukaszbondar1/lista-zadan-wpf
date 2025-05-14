using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektWPF.models
{
    // Models/TaskItem.cs
    public class TaskItem
    {

        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public PriorityLevel Priority { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; } = false;
        public ObservableCollection<SubTaskItem> SubTasks { get; set; } = new();

    }

    public enum PriorityLevel
    {
        Niski = 0,
        Średni = 1,
        Wysoki = 2
    }

}
