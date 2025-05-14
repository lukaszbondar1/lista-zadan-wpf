using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace ProjektWPF
{
    public static class PromptDialog
    {
        public static string? Show(string title, string message, string defaultText = "")
        {
            var inputDialog = new Window
            {
                Title = title,
                Width = 300,
                Height = 150,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                ResizeMode = ResizeMode.NoResize
            };

            var stack = new StackPanel { Margin = new Thickness(10) };
            stack.Children.Add(new TextBlock { Text = message });
            var textBox = new TextBox { Text = defaultText, Margin = new Thickness(0, 5, 0, 5) };
            stack.Children.Add(textBox);

            var buttons = new StackPanel { Orientation = Orientation.Horizontal, HorizontalAlignment = HorizontalAlignment.Right };
            var ok = new Button { Content = "OK", IsDefault = true, Width = 75, Margin = new Thickness(5, 0, 0, 0) };
            var cancel = new Button { Content = "Anuluj", IsCancel = true, Width = 75, Margin = new Thickness(5, 0, 0, 0) };
            buttons.Children.Add(ok);
            buttons.Children.Add(cancel);
            stack.Children.Add(buttons);

            inputDialog.Content = stack;

            string? result = null;
            ok.Click += (s, e) => { result = textBox.Text; inputDialog.DialogResult = true; };
            inputDialog.ShowDialog();

            return result;
        }
    }

}
