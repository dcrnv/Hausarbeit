using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace DSH.MVVM.View
{
    /// <summary>
    /// Interaktionslogik für ArbeitsplanEinsehenView.xaml
    /// </summary>
    public partial class ArbeitsplanEinsehenView : UserControl
    {
        private ICollectionView CollectionView;
        public BaufirmaEntities ctx = new BaufirmaEntities();

        public ArbeitsplanEinsehenView()
        {
            InitializeComponent();
            ctx.Arbeitsplan.Load();
            CollectionView = CollectionViewSource.GetDefaultView(ctx.Arbeitsplan.Local);
            DataContext = CollectionView;
        }

        private void arbeitsplandrucken_Click(object sender, RoutedEventArgs e)
        {
            Arbeitsplan m = (Arbeitsplan)arbeitsplan.SelectedItem;

            if (arbeitsplan.SelectedItems.Count < 1)
            {
                MessageBox.Show("Bitte wählen sie eine Baustelle aus!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {


                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

                PdfDocument document = new PdfDocument();

                PdfPage page = document.AddPage();

                XGraphics gfx = XGraphics.FromPdfPage(page);

                XFont font = new XFont("Arial", 10, XFontStyle.Bold);

                XImage image = XImage.FromFile("Images/drilonshausarbeit.png");
                gfx.DrawImage(image, 5, 5, 200, 100);

                gfx.DrawString("Baustelle - Arbeitsplan", new XFont("Arial", 25, XFontStyle.Bold), XBrushes.Black, new XPoint(250, 75));
                gfx.DrawLine(new XPen(XColor.FromArgb(139, 0, 0)), new XPoint(0, 110), new XPoint(1000, 110));
                
                
                gfx.DrawString("Ausgewählte Arbeitsplan ID:", new XFont("Arial", 15, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 150));
                gfx.DrawString($"{m.ID_Arbeitsplan}", new XFont("Arial", 15, XFontStyle.Bold), XBrushes.Black, new XPoint(300, 150));

                gfx.DrawLine(new XPen(XColor.FromArgb(139, 0, 0)), new XPoint(0, 170), new XPoint(1000, 170));

                gfx.DrawString("Ausgewählte Baustelle:", new XFont("Arial", 15, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 190));
                gfx.DrawString($"{m.Baustelle}", new XFont("Arial", 15, XFontStyle.Bold), XBrushes.Black, new XPoint(300, 190));

                gfx.DrawLine(new XPen(XColor.FromArgb(139, 0, 0)), new XPoint(0, 210), new XPoint(1000, 210));

                gfx.DrawString("Datum:", new XFont("Arial", 15, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 230));
                gfx.DrawString($"{m.Datum}", new XFont("Arial", 15, XFontStyle.Bold), XBrushes.Black, new XPoint(300, 230));

                gfx.DrawLine(new XPen(XColor.FromArgb(139, 0, 0)), new XPoint(0, 250), new XPoint(1000, 250));

                gfx.DrawString("Mitarbeiter:", new XFont("Arial", 15, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 270));
                gfx.DrawString("--- wird bearbeitet", new XFont("Arial", 15, XFontStyle.Bold), XBrushes.Black, new XPoint(300, 270));

                gfx.DrawLine(new XPen(XColor.FromArgb(139, 0, 0)), new XPoint(0, 500), new XPoint(1000, 500));


                gfx.DrawString("Material:", new XFont("Arial", 15, XFontStyle.Bold), XBrushes.Black, new XPoint(10, 520));
                gfx.DrawString("--- wird bearbeitet ", new XFont("Arial", 15, XFontStyle.Bold), XBrushes.Black, new XPoint(300, 520));

                string filename = $"ID_{m.ID_Arbeitsplan}_{m.Baustelle}.pdf";

                document.Save(filename);
                Process.Start(filename);
            }


        }

        private void baustelleupdaten_Click(object sender, RoutedEventArgs e)
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

        private void baustellelöschen_Click(object sender, RoutedEventArgs e)
        {
            Arbeitsplan m = (Arbeitsplan)arbeitsplan.SelectedItem;

            if (arbeitsplan.SelectedItems.Count < 1)
            {
                MessageBox.Show("Bitte wählen sie eine Baustelle zum Löschen aus!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (MessageBox.Show("Sicher, dass sie den Mitarbeiter löschen wollen?",
                 "Delete",
                    MessageBoxButton.YesNo,
                     MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    ctx.Arbeitsplan.Remove(m);
                    ctx.SaveChanges();
                    MessageBox.Show("Die Baustelle wurde erfolgreich entfernt", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                }
            }
        }
    }
}
