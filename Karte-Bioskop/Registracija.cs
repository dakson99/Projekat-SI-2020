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
    public partial class Registracija : Form
    {
        Business bussines_ = new Business();
        public Registracija()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 swap = new Form1();
            swap.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bussines_.Registracija(textBox3.Text, textBox4.Text, textBox1.Text, textBox2.Text))
            {
                MessageBox.Show("Registracija uspešna");

                Form1 swap = new Form1();
                swap.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Došlo je do greške. Pokušajte ponovo");
            }
        }
    }
}
