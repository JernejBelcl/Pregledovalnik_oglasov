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
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Win32;

namespace Pregledovalnik_oglasov
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Oglas> seznam = new ObservableCollection<Oglas>();
        private string imageSource = "";
        public MainWindow()
        {
            InitializeComponent();
            list.ItemsSource = seznam;
            
        }
       
        
        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Add(object sender, RoutedEventArgs e)
        {

            int index = seznam.Count();              
            if (index > -1)
            {
                EditWindow ew = new EditWindow();
                ew.Naslov.Text = "DODAJANJE NOVEGA OGLASA";
                if (Properties.Settings.Default.ImageSourceStr != "")
                {
                    ew.img.Source = new BitmapImage(new Uri(imageSource, UriKind.Relative));
                    ew.SlikaTxt.Text = imageSource;

                }
                if (ew.ShowDialog() == true)
                {
                    //ew.Show();
                    
                    seznam.Add(new Oglas()
                    {
                        Naziv = ew.NazivTxt.Text,
                        Znamka=ew.ZnamkaTxt.Text,
                        Model=ew.ModelTxt.Text,
                        Letnik = Int32.Parse(ew.LetnikTxt.Text),
                        Cena = Double.Parse(ew.CenaTxt.Text),
                        Slika = ew.SlikaTxt.Text,
                    });
                    Properties.Settings.Default.ImageSourceStr = ew.SlikaTxt.Text;              
                    Properties.Settings.Default.Save();
                }

            }

        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            int index = list.SelectedIndex;
            if (index > -1)
            {
                Odstrani.IsEnabled = true;
                seznam.RemoveAt(index);
                //list.Items.RemoveAt(list.SelectedIndex);
            }
            else if (index <= -1)
            {
                //Odstrani.IsEnabled = false;
                MessageBox.Show("Izbran ni doben element");
            }
        }

        private void Display(object sender, MouseButtonEventArgs e)
        {
            if (list.SelectedItem != null)
            {
                string text = ((Oglas)list.SelectedItem).ToString();
                MessageBox.Show(text);
            }
        }

        private void Nastavitve(object sender, RoutedEventArgs e)
        {
            SettingsWindow sw = new SettingsWindow();
            if(sw.ShowDialog()==true)
            {
                //sw.Show();
            }
           
        }

        private void Uredi(object sender, RoutedEventArgs e)
        {
            int index = list.SelectedIndex;
            if (index > -1)
            {
                Urejanje.IsEnabled = true;
                EditWindow ew = new EditWindow();
                ew.Naslov.Text = String.Concat(seznam[index].Znamka," ",seznam[index].Model," LETNIK: ",seznam[index].Letnik.ToString()," ",seznam[index].Model, " CENA: ", seznam[index].Cena.ToString(),"€");
                ew.NazivTxt.Text = seznam[index].Naziv;
                ew.ZnamkaTxt.Text = seznam[index].Znamka;
                ew.ModelTxt.Text = seznam[index].Model;
                ew.LetnikTxt.Text = seznam[index].Letnik.ToString();
                ew.CenaTxt.Text = seznam[index].Cena.ToString();
                ew.SlikaTxt.Text = seznam[index].Slika;

                if (Properties.Settings.Default.ImageSourceStr != "")
                {
                    ew.img.Source = new BitmapImage(new Uri(imageSource, UriKind.Relative));
                    ew.SlikaTxt.Text = imageSource;

                }
                if (ew.ShowDialog() == true)
                {
                    //ew.Show();
                    seznam[index].Naziv = ew.NazivTxt.Text;
                    seznam[index].Znamka = ew.ZnamkaTxt.Text;
                    seznam[index].Model = ew.ModelTxt.Text;
                    seznam[index].Letnik = Int32.Parse(ew.LetnikTxt.Text);
                    seznam[index].Cena = Double.Parse(ew.CenaTxt.Text);
                    seznam[index].Slika = ew.SlikaTxt.Text;
                    Properties.Settings.Default.ImageSourceStr = ew.SlikaTxt.Text;
                    Properties.Settings.Default.Save();
                }

            }

            else if (index <= -1)
            {
                //Odstrani.IsEnabled = false;
                MessageBox.Show("Urediti ni mozno nobenega elementa");
            }
        }

        private void Uvozi(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = System.IO.Path.GetFullPath(Environment.CurrentDirectory + @"\..\..\..");
            ofd.Filter = "Xml files (*.xml)|*.xml|All files(*.*)|*.*";
            if (ofd.ShowDialog() == true)
            {
                    using (TextReader tr = new StreamReader(ofd.FileName))
                    {
                        XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Oglas>));
                        seznam = (ObservableCollection<Oglas>)xs.Deserialize(tr);
                        list.ItemsSource = seznam;
                    }             
            }
            MessageBox.Show(" awr"+seznam.Count());

        }

        private void Izvozi(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.InitialDirectory = System.IO.Path.GetFullPath(Environment.CurrentDirectory + @"\..\..\..");
            sfd.Filter = "Xml files (*.xml)|*.xml|All files(*.*)|*.*";
            if (sfd.ShowDialog() == true)
            {
                using (TextWriter tw = new StreamWriter(sfd.FileName))
            {
                XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Oglas>));
                xs.Serialize(tw, seznam);
            }
            }
            MessageBox.Show(" izvozi" + seznam.Count());

        }
        private void FilterControl_OnFiltriranje(string s,string combo)
        {
            //items.Add(new ToDoItem { Naslov = "Item", Vsebina = s, Pomembnost = 1 });
            ObservableCollection<Oglas> filter_oglas = new ObservableCollection<Oglas>();
            foreach(var item in seznam)
                {
                    if(item.Model.Contains(s))
                    {
                        filter_oglas.Add(item);
                    }
             }
            foreach (var item in seznam)
            {
                if (item.Znamka.Contains(combo))
                {
                    filter_oglas.Add(item);
                }
            }

            list.ItemsSource = filter_oglas;
        }
    }
}
