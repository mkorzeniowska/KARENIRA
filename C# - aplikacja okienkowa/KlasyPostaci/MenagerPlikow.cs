using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace PO_proba_2.KlasyPostaci
{
    public class MenagerPlikow
    {
       
        private static String FolderUstawien
        {
            get
            {
                //folder
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                //dodaj podfolder
                folder = Path.Combine(folder, "RPG Projekt");
                folder = Path.Combine(folder, "UstawieniaPostaci");
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);
                return folder;
            }
        }
        private static String PlikUstawienGracza
        {
            get
            {
                return Path.Combine(FolderUstawien, "Gracz.xml");
            }
        }
        public static void ZapiszPostac(Gracz gracz)
        {
            using (Stream stream = File.Create(PlikUstawienGracza))
            {
                XmlSerializer ser = new XmlSerializer(gracz.GetType());
                ser.Serialize(stream, gracz);
            }
        }
        private static Gracz DefaultGracz
        {
            get{
                return new Gracz
                {
                    Imie = "",

                    Plec = JednostkaPlec.Unknown,
                    KlasaPostaci = JednostkaKlasa.Unknown,
                    Sila = 0,
                    Zrecznosc = 0,
                    Kondycja = 0,
                    Inteligencja = 0,
                };
            }
        }
        public static Gracz WczytajGracza()
        {
            if (!File.Exists(PlikUstawienGracza))
                return DefaultGracz;
            using (Stream stream = File.OpenRead(PlikUstawienGracza))
            {
                XmlSerializer ser = new XmlSerializer(typeof(Gracz));
                return (Gracz)ser.Deserialize(stream);
            }
        }
    }
}
