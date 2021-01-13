using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Layer;
namespace Karte_Bioskop
{
    public partial class Form1 : Form
    {
        Business bussines_ = new Business();
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registracija swap = new Registracija();
            swap.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] korisnikinfo = new string[6];
            korisnikinfo = bussines_.Prijava(textBox1.Text, textBox2.Text);
            if (korisnikinfo != null)
            {
                
                MessageBox.Show("Prijava uspešna");
                if (int.Parse(korisnikinfo[1])==1)
                {
                    GlavniMeni swap = new GlavniMeni(korisnikinfo);
                    swap.Show();
                    this.Hide();
                }
                else
                {
                    Admin swap = new Admin(korisnikinfo);
                    swap.Show();
                    this.Hide();
                }
               
            }
            else
            {
                MessageBox.Show("Pogrešna kombinacija korisničkog imena i lozinke. Pokušajte ponovo.");
            }
           
        }
    }
}
