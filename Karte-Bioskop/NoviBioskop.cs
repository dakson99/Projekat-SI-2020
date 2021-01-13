using Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karte_Bioskop
{
    public partial class NoviBioskop : Form
    {
        Business bussines_ = new Business();
        public NoviBioskop()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (bussines_.DodajBioskop(txtNaziv.Text, txtAdresa.Text, txtMail.Text, txtTelefon.Text, txtKapcitet.Text))
            {
                MessageBox.Show("Uspešno ste dodali bioskop.");
                this.Hide();
            }
            else
            {
                MessageBox.Show("Došlo je do greške. Pokušajte ponovo.");
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
