using DSH.MVVM.View;
using System.Windows;
using System.Windows.Input;


namespace DSH
{
    /// <summary>
    /// Interaktionslogik für Hauptseite.xaml
    /// </summary>
    public partial class Hauptseite : Window
    {
        public Hauptseite()
        {
            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWindow.Show();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Escape) && (Keyboard.IsKeyDown(Key.Y)))
            {
                MainWindow mainWindow = new MainWindow();
                this.Visibility = Visibility.Hidden;
                mainWindow.Show();
            }
        }
    }
}

