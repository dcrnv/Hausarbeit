using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace DSH.MVVM.View
{
    /// <summary>
    /// Interaktionslogik für MiVerwaltenView.xaml
    /// </summary>
    public partial class MiVerwaltenView : UserControl
    {
        public BaufirmaEntities ctx = new BaufirmaEntities();
        public MiVerwaltenView()
        {
            InitializeComponent();
            rollehzf.Items.Add("Baustellenarbeiter");
            rollehzf.Items.Add("Lagerarbeiter");
            rollehzf.Items.Add("Sekretärin");
            rollehzf.Items.Add("Maschinenbediener");
            rollehzf.Items.Add("Fahrer");
        }

        private void namehzf_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[a-zA-Z]"))
            {
                e.Handled = true;
            }
        }

        private void vornamehzf_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[a-zA-Z]"))
            {
                e.Handled = true;
            }
        }

        private void straßehzf_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[a-zA-Z]"))
            {
                e.Handled = true;
            }
        }

        private void hausnummerhzf_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void orthzf_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[a-zA-Z]"))
            {
                e.Handled = true;
            }
        }

        private void plzhzf_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void tlfhzf_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void rollehzf_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[a-zA-Z]"))
            {
                e.Handled = true;
            }
        }

        private void bdayhzf_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var ageInYears = GetDifferenceInYears(bdayhzf.SelectedDate.Value, DateTime.Today);
            if (ageInYears < 18)
            {
                MessageBox.Show("Mitarbeiter muss mindestens 18 Jahre alt sein! Bitte überprüfen sie den Geburtstag!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                bdayhzf.SelectedDate = new DateTime(2000, 10, 27);
            }
        }

        int GetDifferenceInYears(DateTime startDate, DateTime endDate)
        {
            return (endDate.Year - startDate.Year - 1) +
                (((endDate.Month > startDate.Month) ||
                ((endDate.Month == startDate.Month) && (endDate.Day >= startDate.Day))) ? 1 : 0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var namecheck = ctx.Mitarbeiter.Any(x => x.Name == namehzf.Text);
            var vornamecheck = ctx.Mitarbeiter.Any(x => x.Vorname == vornamehzf.Text);
            var geburtstagcheck = ctx.Mitarbeiter.Any(x => x.Geburtstag == bdayhzf.SelectedDate.Value);


            if (namehzf.Text == "" || vornamehzf.Text == "" || straßehzf.Text == "" || hausnummerhzf.Text == "" || orthzf.Text == ""
                || plzhzf.Text == "" || tlfhzf.Text == "" || bdayhzf.Text == "" || rollehzf.Text == "")
            {
                MessageBox.Show("Bitte füllen sie alle Felder aus!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (namecheck == true && vornamecheck == true && geburtstagcheck == true)
            {
                MessageBox.Show("Der Arbeitnehmer ist schon vorhanden! Bitte korrigieren sie den Mitarbeiter!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (hausnummerhzf.Text.Length > 4)
            {
                MessageBox.Show("Hausnummer darf nicht mehr als 4 Zahlen sein! Bitte korrigieren sie die Hausnummer!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (hausnummerhzf.Text.Length < 1)
            {
                MessageBox.Show("Hausnummer muss mindestens eine Zahl sein! Bitte korrigieren sie die Hausnummer!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if(plzhzf.Text.Length > 5)
            {
                MessageBox.Show("Postleitzahl darf nicht mehr als 5 Zahlen sein! Bitte korrigieren sie die Postleitzahl!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (plzhzf.Text.Length < 5)
            {
                MessageBox.Show("Postleitzahl darf nicht weniger als 5 Zahlen sein! Bitte korrigieren sie die Postleitzahl!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (tlfhzf.Text.Length < 11)
            {
                MessageBox.Show("Telefonnummer darf nicht weniger als 11 Zahlen sein! Bitte korrigieren sie die Telefonnummer!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (tlfhzf.Text.Length > 11)
            {
                MessageBox.Show("Telefonnummer darf nicht mehr als 11 Zahlen sein! Bitte korrigieren sie die Telefonnummer!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Mitarbeiter mitarbeiter = new Mitarbeiter();

                string namenfeld = Convert.ToString(namehzf.Text);
                string vornamenfeld = Convert.ToString(vornamehzf.Text);
                string straße = Convert.ToString(straßehzf.Text);
                int hausnummer = Convert.ToInt32(hausnummerhzf.Text);
                string ort = Convert.ToString(orthzf.Text);
                int postleitzahl = Convert.ToInt32(plzhzf.Text);
                decimal telefonnummer = Convert.ToDecimal(tlfhzf.Text);
                var geburtstag = Convert.ToDateTime(bdayhzf.DisplayDate);
                string rolle = Convert.ToString(rollehzf.Text);

                mitarbeiter.Name = namenfeld;
                mitarbeiter.Vorname = vornamenfeld;
                mitarbeiter.Straße = straße;
                mitarbeiter.Hausnummer = hausnummer;
                mitarbeiter.Ort = ort;
                mitarbeiter.Postleitzahl = postleitzahl;
                mitarbeiter.Telefonnummer = telefonnummer;
                mitarbeiter.Geburtstag = geburtstag;
                mitarbeiter.Rolle = rolle;

                ctx.Mitarbeiter.Add(mitarbeiter);
                ctx.SaveChanges();

                MessageBox.Show("Der neue Mitarbeiter wurde erfolgreich hinzugefügt", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void namehzf_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
            base.OnPreviewKeyDown(e);
        }

        private void vornamehzf_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
            base.OnPreviewKeyDown(e);
        }

        private void hausnummerhzf_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
            base.OnPreviewKeyDown(e);
        }

        private void plzhzf_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
            base.OnPreviewKeyDown(e);
        }

        private void tlfhzf_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
            base.OnPreviewKeyDown(e);
        }
    }
}

