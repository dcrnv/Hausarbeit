using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DSH.MVVM.View
{
    /// <summary>
    /// Interaktionslogik für MaterialEinsehenView.xaml
    /// </summary>
    public partial class MaterialEinsehenView : UserControl
    {
        private ICollectionView CollectionView;
        public BaufirmaEntities ctx = new BaufirmaEntities();
        public MaterialEinsehenView()
        {
            InitializeComponent();
            ctx.Material.Load();
            CollectionView = CollectionViewSource.GetDefaultView(ctx.Material.Local);
            DataContext = CollectionView;
        }

        private void MaterialLöschen_Click(object sender, RoutedEventArgs e)
        {
            Material m = (Material)material.SelectedItem;

            if (material.SelectedItems.Count < 1)
            {
                MessageBox.Show("Bitte wählen sie das Material zum Löschen aus!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (MessageBox.Show("Sicher, dass sie das Material löschen wollen?",
                        "Delete",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question) == MessageBoxResult.Yes)
                {

                    ctx.Material.Remove(m);
                    ctx.SaveChanges();
                    MessageBox.Show("Das Material wurde erfolgreich entfernt", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                }
            }
        }

        private void materialupdate_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Sicher, dass sie die Datenbank updaten möchten?",
                       "Update",
                       MessageBoxButton.YesNo,
                       MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ctx.SaveChanges();
                ctx.Material.Load();
                MessageBox.Show("Die Datenbank wurde geupdated", "Reload", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
