using System;
using System.Windows;
using System.Windows.Input;


namespace DSH
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _anmeldename = "admin";
        private string _passwort = "1234";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton ==  MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string anmeldename2 = Convert.ToString(anmeldename.Text);
            string passwort2 = Convert.ToString(passwort.Password);

            if (anmeldename2 != _anmeldename || passwort2 != _passwort)
            {
                MessageBox.Show("Anmeldename oder Passwort ungültig");
            }
            else
            {
                Hauptseite zweiteseite = new Hauptseite();
                this.Visibility = Visibility.Hidden;
                zweiteseite.Show();
            }
        }

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            string anmeldename2 = Convert.ToString(anmeldename.Text);
            string passwort2 = Convert.ToString(passwort.Password);
            if (e.Key == Key.Enter)
            {
                if (anmeldename2 != _anmeldename || passwort2 != _passwort)
                {
                    MessageBox.Show("Anmeldename oder Passwort ungültig");
                }
                else
                {
                    Hauptseite zweiteseite = new Hauptseite();
                    this.Visibility = Visibility.Hidden;
                    zweiteseite.Show();
                }
            }
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Escape) && (Keyboard.IsKeyDown(Key.Y)))
            {
                App.Current.Shutdown();
            }
        }
    }
}
