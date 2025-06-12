using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System.Collections.Generic;
using System.Windows;

namespace ProjektWPF
{
    public partial class StatisticWindow : Window
    {
        public IEnumerable<ISeries> Series { get; set; }

        public StatisticWindow(List<models.TaskItem> tasks)
        {
            InitializeComponent();
            MessageBox.Show($"Zadań: {tasks.Count}");
            int completed = tasks.Count(t => t.IsCompleted);
            int notCompleted = tasks.Count(t => !t.IsCompleted);

            Series = new ISeries[]
            {
                new PieSeries<int> { Values = new[] { completed }, Name = "Ukończone" },
                new PieSeries<int> { Values = new[] { notCompleted }, Name = "Nieukończone" }
            };

            DataContext = this;
        }
    }
}
