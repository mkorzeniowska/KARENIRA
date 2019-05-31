using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_proba_2.KlasyPostaci
{
    public enum JednostkaPlec {Mężczyzna, Kobieta, Unknown}
    public enum JednostkaKlasa { Bard, Druid, Kleryk, Łotr, Mag, Paladyn, Wojownik, Unknown}
    public abstract class Jednostka
    {
    #region Fields Region
    protected string _imie;
    protected JednostkaPlec _plec;
    protected JednostkaKlasa _klasaPostaci;
    protected int _sila, _zrecznosc, _kondycja, _inteligencja;
    protected int _silaModyf, _zrecznoscModyf, _kondycjaModyf, _inteligModyf;
    protected int _premiaBieglosci;

        #endregion
        #region Properties Region

        public string Imie { get; set; }  //to samo co ponizej - taki zapis sie obecnie stosuje
        //{
        //    get { return _imie; }
        //    set { _imie = value; }
        //}
        public JednostkaPlec Plec
        {
            get { return _plec; }
            set { _plec = value; }
        }
        public JednostkaKlasa KlasaPostaci
        {
            get { return _klasaPostaci; }
            set { _klasaPostaci = value; }
        }
        public int Sila
        {
            get { return _sila + _silaModyf; }
            set { _sila = value; }
        }
        public int Zrecznosc
        {
            get { return _zrecznosc + _zrecznoscModyf; }
            set { _zrecznosc = value; }
        }
        public int Kondycja
        {
            get { return _kondycja + _kondycjaModyf; }
            set { _kondycja = value; }
        }
        public int Inteligencja
        {
            get { return _inteligencja + _inteligModyf; }
            set { _inteligencja = value; }
        }
        #endregion
        #region Constructor Region
        public Jednostka()
        {
            Imie = "";
            Plec = JednostkaPlec.Unknown;
            KlasaPostaci = JednostkaKlasa.Unknown;
            Sila = 0;
            Zrecznosc = 0;
            Kondycja = 0;
            Inteligencja = 0;
        }
        #endregion
        #region Methods Region
        #endregion
    }

}
