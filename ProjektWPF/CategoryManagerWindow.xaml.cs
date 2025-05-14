using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjektWPF
{
    public partial class CategoryManagerWindow : Window
    {
        public CategoryManagerWindow()
        {
            InitializeComponent();
            DataContext = new CategoryManagerViewModel();
        }
    }
}
