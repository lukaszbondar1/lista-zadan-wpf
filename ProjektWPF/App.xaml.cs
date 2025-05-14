using ProjektWPF.Data;
using ProjektWPF.models;
using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace ProjektWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            DatabaseInitializer.Initialize();
        }


    }

    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            using var db = new AppDbContext();
            db.Database.Migrate();

            // Przykładowe dane
            if (!db.Categories.Any())
            {
                db.Categories.AddRange(
                    new Category { Name = "Praca" },
                    new Category { Name = "Dom" },
                    new Category { Name = "Nauka" }
                );
                db.SaveChanges();
            }
            
        }
    }

}
