using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PO_proba_2
{
    public partial class Form_Menu : Form
    {
        public Form_Menu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Lbl_Tytul_Gry_Click(object sender, EventArgs e)
        {

        }

        private void BtmWczytajGre_Click(object sender, EventArgs e)
        {
            ID_postaci stats = new ID_postaci();
            stats.Show();
        }

        private void BtmStworzPostac_Click(object sender, EventArgs e)
        {
            FormKreatorPostaci kreatPostac = new FormKreatorPostaci();
            kreatPostac.Show();
        }

        private void Btm_ZamknijGre_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
