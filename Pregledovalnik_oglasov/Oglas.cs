using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregledovalnik_oglasov
{
    public class Oglas : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Oglas() { }

      /*  public Oglas(string n, string z,string m,int l,double c,string s )
        {
            Naziv = n;
            Znamka = z;
            Model = m;
            Letnik = l;
            Cena = c;
            Slika = s;
        }*/
        /* private string naziv { get; set; } = "";
          private string znamka { get; set; } = "";
          private string model { get; set; } = "";
          private int letnik { get; set; } = 2001;
          private double cena { get; set; } =15.552;
          private string slika { get; set; } = "";*/

        private string naziv;
        private string znamka;
        private string model;
        private int letnik;
        private double cena;
        private string slika;
                 public string Naziv
                 {
                     get
                     {
                         return naziv;
                     }
                     set
                     {
                      naziv = value;
                         OnPropertyChanged("naziv");
                     }
                 }
                 public string Znamka {
                     get
                     {
                         return znamka;
                     }
                     set
                     {
                         znamka = value;
                         OnPropertyChanged("znamka");
                     }

                 }
                 public string Model {
                     get
                     {
                         return model;
                     }
                     set
                     {
                         model = value;
                         OnPropertyChanged("model");
                     }
                 } 
                 public int Letnik {
                     get
                     {
                         return letnik;
                     }
                     set
                     {
                         letnik = value;
                         OnPropertyChanged("letnik");
                     }
                 } 
                 public double Cena {
                     get
                     {
                         return cena;
                     }
                     set
                     {
                         cena = value;
                         OnPropertyChanged("cena");
                     }
                 } 
                 public string Slika {
                     get
                     {
                         return slika;
                     }
                     set
                     {
                         slika = value;
                         OnPropertyChanged("slika");
                     }
                 }
        
        public override string ToString()
        {
            return $"{Naziv}\n{Znamka}\n{Model}\n{Letnik}\n{Cena}\n{Slika}";
            
        }
    }
}
