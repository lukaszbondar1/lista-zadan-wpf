using ProjektWPF.Data;
using ProjektWPF.models;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Windows.Media.Animation;
using System.IO;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace ProjektWPF
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        public class ZenQuote
        {
            public string q { get; set; } // Quote
            public string a { get; set; } // Author
        }
        private void ShowStatistics_Click(object sender, RoutedEventArgs e)
        {
            //var statsWindow = new StatisticWindow(tasks.ToList());
            //statsWindow.ShowDialog();
        }

        private async void FetchZenQuote_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using var httpClient = new HttpClient();
                var response = await httpClient.GetAsync("https://zenquotes.io/api/random");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var quotes = JsonSerializer.Deserialize<List<ZenQuote>>(json);

                    if (quotes != null && quotes.Count > 0)
                    {
                        var quote = quotes[0];
                        MessageBox.Show($"\"{quote.q}\"\n\n— {quote.a}", "Cytat motywacyjny");
                        string text = $"\"{quote.q}\"\n— {quote.a}";
                        // Save to file
                        File.WriteAllText("last_quote.txt", text);
                    }
                    else
                    {
                        MessageBox.Show("Nie udało się przetworzyć cytatu.");
                    }
                }
                else
                {
                    MessageBox.Show("Nie udało się połączyć z serwisem ZenQuotes.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd: {ex.Message}");
            }
        }

    }
}