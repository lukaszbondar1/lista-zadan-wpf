using ProjektWPF.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProjektWPF
{
    public partial class AddEditTaskWindow : Window
    {
        public AddEditTaskViewModel ViewModel => (AddEditTaskViewModel)DataContext;

        public AddEditTaskWindow(TaskItem? task = null)
        {
            InitializeComponent();
            DataContext = new AddEditTaskViewModel(task);
        }

        private void AddSubtask_Click(object sender, RoutedEventArgs e)
        {
            string name = SubtaskNameBox.Text.Trim();
            if (!string.IsNullOrWhiteSpace(name))
            {
                ViewModel.Task.SubTasks.Add(new SubTaskItem { Name = name });
                SubtaskNameBox.Text = "";
            }
        }

        private void DeleteSubtask_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is SubTaskItem item)
            {
                ViewModel.Task.SubTasks.Remove(item);
            }
        }

    }
}
