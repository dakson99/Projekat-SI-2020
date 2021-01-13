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
    public partial class Rezervacije : Form
    {
        Business bussines_ = new Business();
        string [] konstruktorParametri = new string[4];
        public Rezervacije(string dogadjajid, string korisnikid,string bioskop, string datum, string film)
        {
            InitializeComponent();
            konstruktorParametri[0]= dogadjajid;
            konstruktorParametri[1] = korisnikid;
            label1.Text = "Bioskop: " + bioskop + "; Film: "+film;
            label2.Text = "Datum dogadjaja: " + datum;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bussines_.BrojKarata(int.Parse(textbroj.Text)))
            {
                if(bussines_.RezervisiKarte(konstruktorParametri[0], konstruktorParametri[1], textbroj.Text))
                {
                    MessageBox.Show("Uspešno ste rezervisali karte");
                }
                else
                {
                    MessageBox.Show("Došlo je do greške. Pokušajte ponovo");
                }
            }
            else
            {
                MessageBox.Show("Maksimalan broj karata koji možete rezervisati je 5.");
            }

        }

        private void textPrezime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
