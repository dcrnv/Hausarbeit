using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DSH.MVVM.View
{
    /// <summary>
    /// Interaktionslogik für MaterialVerwaltenView.xaml
    /// </summary>
    public partial class MaterialVerwaltenView : UserControl
    {
        public BaufirmaEntities ctx = new BaufirmaEntities();

        public MaterialVerwaltenView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var namecheck = ctx.Material.Any(x => x.Name == namehzf.Text);

            if (namehzf.Text == "" || anzahlhzf.Text == "" || listenpreishzf.Text == "" || herstellerhzf.Text == "" || gewichthzf.Text == "")
            {
                MessageBox.Show("Bitte füllen sie alle Felder aus!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (namecheck == true)
            {
                MessageBox.Show("Das Material ist schon vorhanden! Bitte korrigieren sie den Namen!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Material material = new Material();

                string namenfeld = Convert.ToString(namehzf.Text);
                int anzahl = Convert.ToInt32(anzahlhzf.Text);
                int listenpreis = Convert.ToInt32(listenpreishzf.Text);
                string hersteller = Convert.ToString(herstellerhzf.Text);
                int gewicht = Convert.ToInt32(gewichthzf.Text);

                material.Name = namenfeld;
                material.Anzahl = anzahl;
                material.Listenpreis = listenpreis;
                material.Hersteller = hersteller;
                material.Gewicht_in_KG = gewicht;

                ctx.Material.Add(material);
                ctx.SaveChanges();
                MessageBox.Show("Das neue Material wurde erfolgreich hinzugefügt", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }

        private void namehzf_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[a-zA-Z]"))
            {
                e.Handled = true;
            }
        }

        private void anzahlhzf_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void listenpreishzf_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void herstellerhzf_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[a-zA-Z]"))
            {
                e.Handled = true;
            }
        }

        private void gewichthzf_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void anzahlhzf_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
            base.OnPreviewKeyDown(e);
        }

        private void listenpreishzf_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
            base.OnPreviewKeyDown(e);
        }

        private void gewichthzf_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
            base.OnPreviewKeyDown(e);
        }
    }
}
