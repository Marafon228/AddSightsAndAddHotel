using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AddSightsAndAddHotel
{
    /// <summary>
    /// Interaction logic for AddHotel.xaml
    /// </summary>
    public partial class AddHotel : Page
    {
        public Hotel CurrentHotel { get; set; }
        public AddHotel()
        {
            CurrentHotel = new Hotel();
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
                CurrentHotel.ImagePreview = (byte[])new ImageConverter().ConvertTo(new Bitmap(openImage.FileName), typeof(byte[]));
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                ADO.Instance.Hotel.Add(CurrentHotel);
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
