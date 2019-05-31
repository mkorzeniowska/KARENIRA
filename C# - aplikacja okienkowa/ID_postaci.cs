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
    public partial class ID_postaci : Form
    {
        public ID_postaci()
        {
            InitializeComponent();
        }

        private void ID_postaci_Load(object sender, EventArgs e)
        {
            Gracz g1 = new Gracz();
            g1 = MenagerPlikow.WczytajGracza();
            Lbl_Imie.Text = g1.Imie;
            Lbl_plec.Text = Convert.ToString(g1.Plec);
            Lbl_klasa.Text = Convert.ToString(g1.KlasaPostaci);
            Lbl_WaroscSily.Text = g1.Sila.ToString();
            Lbl_WartoscInt.Text = g1.Inteligencja.ToString();
            Lbl_WartoscKon.Text = g1.Kondycja.ToString();
            Lbl_WartoscZr.Text = g1.Zrecznosc.ToString();

        }

        private void Lbl_plec_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_klasa_Click(object sender, EventArgs e)
        {

        }

        private void Btn_zamknij_Click(object sender, EventArgs e)
        {
            //Form_Menu home = new Form_Menu();
            //home.Show();
            this.Hide();
        }

        private void Lbl_Stat_Zrecznosc_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_Stat_Sila_Click(object sender, EventArgs e)
        {
           
        }

        private void Lbl_Stat_Kondycja_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_WaroscSily_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_Imie_Click(object sender, EventArgs e)
        {

        }
    }
}
