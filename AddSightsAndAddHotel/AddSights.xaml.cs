using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;

namespace AddSightsAndAddHotel
{
    /// <summary>
    /// Interaction logic for AddSights.xaml
    /// </summary>
    /// 


    public partial class AddSights : Page
    {
        public Sights CurrentSights { get; set; }

        public AddSights()
        {
            CurrentSights = new Sights();
            InitializeComponent();
        }

        private void Image(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openImage = new OpenFileDialog();
            openImage.FileName = "";
            openImage.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
            "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
            "Portable Network Graphic (*.png)|*.png";   // Filter files by extension

            if (openImage.ShowDialog() == DialogResult.OK)
            {
                CurrentSights.ImagePreview = (byte[])new ImageConverter().ConvertTo(new Bitmap(openImage.FileName), typeof(byte[]));
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                ADO.Instance.Sights.Add(CurrentSights);
                ADO.Instance.SaveChanges();
                System.Windows.Forms.MessageBox.Show("Save changes");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
