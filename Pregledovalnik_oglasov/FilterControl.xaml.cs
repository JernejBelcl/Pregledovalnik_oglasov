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

namespace Pregledovalnik_oglasov
{
    /// <summary>
    /// Interaction logic for FilterControl.xaml
    /// </summary>
    public partial class FilterControl : UserControl
    {
        public delegate void Filtriranje(string s,string combo);
        public event Filtriranje OnFiltriranje;
        public FilterControl()
        {
            InitializeComponent();
            comboBoxZnamka.ItemsSource = Properties.Settings.Default.SettingsZnamka;
        }

        private void Filtriraj(object sender, RoutedEventArgs e)
        {
            OnFiltriranje?.Invoke(editBox.Text,comboBoxZnamka.Text);            
        }
    }
}
