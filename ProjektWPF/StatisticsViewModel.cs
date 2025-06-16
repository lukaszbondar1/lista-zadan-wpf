using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using ProjektWPF.models;
using SkiaSharp;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProjektWPF
{
    public class StatisticsViewModel
    {
        public ObservableCollection<ISeries> CompletionSeries { get; set; }
        public ObservableCollection<ISeries> CategorySeries { get; set; }

        public StatisticsViewModel(IEnumerable<TaskItem> tasks)
        {
            var taskList = tasks.ToList();

            int done = taskList.Count(t => t.IsCompleted);
            int notDone = taskList.Count - done;
            CompletionSeries = new ObservableCollection<ISeries>
            {
                new PieSeries<int> { Values = new[] { done }, Name = "Ukoñczone", Fill = new SolidColorPaint(new SKColor(76, 175, 80))
 },
                new PieSeries<int> { Values = new[] { notDone }, Name = "Nieukoñczone", Fill = new SolidColorPaint (new SKColor(244, 67, 54)) }
            };

            var grouped = taskList.Where(t => t.Category != null)
                                  .GroupBy(t => t.Category!.Name)
                                  .OrderByDescending(g => g.Count());

            CategorySeries = new ObservableCollection<ISeries>(
                grouped.Select(g => new PieSeries<int>
                {
                    Values = new[] { g.Count() },
                    Name = g.Key
                })
            );
        }
    }
}
