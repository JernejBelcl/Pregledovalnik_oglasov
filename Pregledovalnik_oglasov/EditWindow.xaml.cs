using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace Pregledovalnik_oglasov
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public EditWindow()
        {
            InitializeComponent();
            ZnamkaTxt.ItemsSource = Properties.Settings.Default.SettingsZnamka;
        }

        private void NaloziSliko(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Slike (*.png)|*.png";
            if (ofd.ShowDialog() == true)
            {
                img.Source = new BitmapImage(new Uri(ofd.FileName, UriKind.Absolute));
                SlikaTxt.Text = ofd.FileName;
            }
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

    }
}
