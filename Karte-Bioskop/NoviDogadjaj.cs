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
    public partial class NoviDogadjaj : Form
    {
        Business bussines_ = new Business();
        public NoviDogadjaj()
        {
            InitializeComponent();
            bussines_.UcitajBioskope(comboBox1);
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DateTime datum = dateTimePicker1.Value;
         
            if (bussines_.DodajDogadjaj(txtNaziv.Text, bussines_.VratiBoiskopID(comboBox1.Text), datum.ToString("yyyy-MM-dd")+ " " + comboBox2.Text))
            {
                MessageBox.Show("Uspešno ste dodali događaj");
                this.Hide();
            }
            else
            {
                MessageBox.Show("Došlo je do greške. Pokušajte ponovo");
            }
          
        }
    }
}
