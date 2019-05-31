using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_proba_2.KlasyPostaci
{
    public class Gracz : Jednostka
    {
        public Gracz() : base()
        { }
        public Gracz(string imie, JednostkaPlec jPlec, JednostkaKlasa jKlasa) : base()
        {
            Imie = imie;
            Plec = jPlec;
            KlasaPostaci = jKlasa;
        }
        public Gracz(string imie, JednostkaPlec jPlec, JednostkaKlasa jKlasa, int sila, int zrecznosc, int kondycja,
            int inteligencja) : base()
        {
            Imie = imie;
            Plec = jPlec;
            KlasaPostaci = jKlasa;
            Sila = sila;
            Zrecznosc = zrecznosc;
            Kondycja = kondycja;
            Inteligencja = inteligencja;
        }
    }
}
