using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace DSH.MVVM.View
{
    /// <summary>
    /// Interaktionslogik für HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://allgemeinebauzeitung.de/");
        }
    }
}
