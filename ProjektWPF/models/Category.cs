using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektWPF.models
{
    // Models/Category.cs
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }

}
