using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



using PO_proba_2.KlasyPostaci;

namespace PO_proba_2
{
    public partial class FormKreatorPostaci : Form
    {

        public FormKreatorPostaci()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Btn_ZapiszPostac_Click(object sender, EventArgs e)
        {
            string imie = Txt_ImiePostaci.Text;
            //walidacja pola
            if (String.IsNullOrEmpty(Txt_ImiePostaci.Text) || Txt_ImiePostaci.Text[0]==' ')
            {
                MessageBox.Show("Wpisz imię postaci.");
                return;
            }
            //wybor plci
            JednostkaPlec jPlec;
            if (Rdio_PlecK.Checked)
                jPlec = JednostkaPlec.Kobieta;
            else
                jPlec = JednostkaPlec.Mężczyzna;
            //wybor klasy
            JednostkaKlasa jKlasa = new JednostkaKlasa();
            jKlasa = JednostkaKlasa.Unknown;
            if (this.Cbo_KlasyPostaci.Text == "Bard")
                jKlasa = JednostkaKlasa.Bard;
            else if (this.Cbo_KlasyPostaci.Text == "Druid")
                jKlasa = JednostkaKlasa.Druid;
            else if (this.Cbo_KlasyPostaci.Text == "Kleryk")
                jKlasa = JednostkaKlasa.Kleryk;
            else if (this.Cbo_KlasyPostaci.Text == "Łotr")
                jKlasa = JednostkaKlasa.Łotr;
            else if (this.Cbo_KlasyPostaci.Text == "Mag")
                jKlasa = JednostkaKlasa.Mag;
            else if (this.Cbo_KlasyPostaci.Text == "Paladyn")
                jKlasa = JednostkaKlasa.Paladyn;
            else if (this.Cbo_KlasyPostaci.Text == "Wojownik")
                jKlasa = JednostkaKlasa.Wojownik;
            else
            {
                MessageBox.Show("Musisz wybrać klasę postaci");
                return;
            }
            //statystyki
            int sila = Convert.ToInt32(Num_Sila.Text);
            int zrecznosc = Convert.ToInt32(Num_Zrecznosc.Text);
            int kondycja = Convert.ToInt32(Num_Kondycja.Text);
            int inteligencja = Convert.ToInt32(Num_Inteligencja.Text);
            if (sila + zrecznosc + kondycja + inteligencja > 40)
            {
                MessageBox.Show("Przydzieliłeś za dużo punktów! Nie oszukuj!");
                return;
            }
            else if (sila + zrecznosc + kondycja + inteligencja < 40)
            {
                MessageBox.Show("Przydzieliłeś za mało punktów!");
                return;
            }

            //walidacja pola
            if (String.IsNullOrEmpty(Txt_ImiePostaci.Text) || Txt_ImiePostaci.Text[0] == ' ')
            {
                MessageBox.Show("Wpisz imię postaci.");
                return;
            }

            Gracz gracz1 = new Gracz(imie, jPlec, jKlasa, sila, zrecznosc, kondycja, inteligencja);
            string output = String.Format("Stworzyłeś nową postać.\n" +
                "Twoje imię to: {0}\nTwoja płeć to: {1}\nTwoja klasa to: {2}",
                gracz1.Imie, gracz1.Plec, gracz1.KlasaPostaci);
            MessageBox.Show(output, "Sukces");
            MenagerPlikow.ZapiszPostac(gracz1);
            ID_postaci stats = new ID_postaci();
            stats.Show();
            this.Close();
        }
        private void Cbo_KlasyPostaci_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormKreatorPostaci_Load(object sender, EventArgs e)
        {
            
        }

       
    }
}
