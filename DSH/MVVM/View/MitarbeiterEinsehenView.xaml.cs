using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
namespace DSH.MVVM.View
{
    /// <summary>
    /// Interaktionslogik für MitarbeiterEinsehenView.xaml
    /// </summary>
    public partial class MitarbeiterEinsehenView : UserControl
    {
        private ICollectionView CollectionView;
        public BaufirmaEntities ctx = new BaufirmaEntities();

        public MitarbeiterEinsehenView()
        {
            InitializeComponent();
            ctx.Mitarbeiter.Load();
            CollectionView = CollectionViewSource.GetDefaultView(ctx.Mitarbeiter.Local);
            DataContext = CollectionView;
        }

        private void mitarbeiterupdate_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Sicher, dass sie die Datenbank updaten möchten?",
                       "Update",
                       MessageBoxButton.YesNo,
                       MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ctx.SaveChanges();
                ctx.Mitarbeiter.Load();
                MessageBox.Show("Die Datenbank wurde geupdated", "Reload", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void MitarbeiterLöschen_Click(object sender, RoutedEventArgs e)
        {
            Mitarbeiter m = (Mitarbeiter)mitarbeiter.SelectedItem;

            if (mitarbeiter.SelectedItems.Count < 1)
            {
                MessageBox.Show("Bitte wählen sie einen Mitarbeiter zum Löschen aus!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {


                if (MessageBox.Show("Sicher, dass sie den Mitarbeiter löschen wollen?",
                        "Delete",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question) == MessageBoxResult.Yes)
                {

                    ctx.Mitarbeiter.Remove(m);
                    ctx.SaveChanges();
                    MessageBox.Show("Der Mitarbeiter wurde erfolgreich entfernt", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                }
            }
        }
    }
}
