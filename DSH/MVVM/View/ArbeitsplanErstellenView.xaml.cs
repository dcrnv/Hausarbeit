using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DSH.MVVM.View
{
    /// <summary>
    /// Interaktionslogik für ArbeitsplanErstellenView.xaml
    /// </summary>
    public partial class ArbeitsplanErstellenView : UserControl
    {
        private ICollectionView CollectionView;
        public BaufirmaEntities ctx = new BaufirmaEntities();

        public ArbeitsplanErstellenView()
        {
            InitializeComponent();
            datumhzf.SelectedDate = DateTime.Today;



            ctx.Material.Load();
            material.ItemsSource = CollectionViewSource.GetDefaultView(ctx.Material.Local);

            ctx.Mitarbeiter.Load();
            mitarbeiter.ItemsSource = CollectionViewSource.GetDefaultView(ctx.Mitarbeiter.Local);

            DataContext = CollectionView;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //if (mitarbeiter.SelectedItems.Count > 0)
            //{
            //    foreach (Mitarbeiter m in mitarbeiter.SelectedItems)
            //    {
            //        ctx.Arbeitsplan.Add(m);
            //    }
            //}

            //if (material.SelectedItems.Count > 0)
            //{
            //    foreach (Material m in material.SelectedItems)
            //    {
            //        ctx.Arbeitsplan.Add(m);
            //    }
            //}

            //ctx.SaveChanges();
            //MessageBox.Show("Die Baustelle wurde erfolgreich hinzugefügt", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
