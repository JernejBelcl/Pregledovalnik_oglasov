using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private ObservableCollection<string> Znamke = new ObservableCollection<string>();
        public SettingsWindow()
        {
            InitializeComponent();
            listznamke.ItemsSource = Properties.Settings.Default.SettingsZnamka;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Dodaj(object sender, RoutedEventArgs e)
        {
            if(txtboxznamka.Text!=null)
            {
                Properties.Settings.Default.SettingsZnamka.Add(txtboxznamka.Text);
                Properties.Settings.Default.Save();
            }
            txtboxznamka.Text = "" ;
        }

        private void Brisi(object sender, RoutedEventArgs e)
        {
            int index = listznamke.SelectedIndex;
            if (index > -1)
            {
                //Znamke.RemoveAt(index);
                Properties.Settings.Default.SettingsZnamka.RemoveAt(index);
                Properties.Settings.Default.Save();
            }      
        }

        private void Uredi(object sender, RoutedEventArgs e)
        {
            int index = listznamke.SelectedIndex;
            TextDialogWindow tdw = new TextDialogWindow();
            tdw.editTxt.Text = Properties.Settings.Default.SettingsZnamka.ElementAt(index);
            
            if (tdw.ShowDialog()==true)
            {
                Properties.Settings.Default.SettingsZnamka[index] = tdw.editTxt.Text;
                Properties.Settings.Default.Save();
            }
        }
    }
}
