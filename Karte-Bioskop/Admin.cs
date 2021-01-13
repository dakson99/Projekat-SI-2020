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
    public partial class Admin : Form
    {
        Business bussines_ = new Business();
        string[] informacije = new string[6];
        public Admin(string[] info)
        {
            InitializeComponent();
            informacije = info;
            PopuniProfilInfo();
            bussines_.DizajnirajTabelu(dataGridView1);
            bussines_.DizajnirajTabelu(dataGridView4);
            bussines_.DizajnirajTabelu(dataGridView5);
            bussines_.UcitajTabelu(dataGridView1, "SELECT nazivBioskopa as Bioskop, datum as Datum, nazivFilma as Film, kapacitet as Kapacitet from dogadjaji inner join bioskopi on dogadjaji.idbioskop=bioskopi.bioskopid");
            bussines_.UcitajTabelu(dataGridView4, "SELECT nazivBioskopa as Bioskop, nazivFilma as Film, ime as Ime, prezime as Prezime, datum as Datum, rezervisaoKarata as Rezerviao from rezervacije inner join korisnici on rezervacije.idkorisnik=korisnici.korisnikid inner join dogadjaji on rezervacije.iddogadjaj=dogadjaji.dogadjajiid inner join bioskopi on dogadjaji.idbioskop=bioskopi.bioskopid");
            bussines_.UcitajTabelu(dataGridView5, "SELECT * from korisnici where  idstatus=1");
            label1.Text = bussines_.vratiStatistiku(7).ToString();
            label6.Text = bussines_.vratiStatistiku(1).ToString(); 
            label8.Text = bussines_.vratiStatistiku(4).ToString();
            label10.Text = bussines_.vratiStatistiku(5).ToString();
            label9.Text = bussines_.vratiStatistiku(3).ToString();
            label11.Text = bussines_.vratiStatistiku(2).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bussines_.izmeniProfilInfo("UPDATE korisnici set ime='" + textIme.Text + "',prezime='" + textPrezime.Text + "',korisnicko='" + textKorisnicko.Text + "',lozinka='" + textLozinka.Text + "' where korisnikid=" + informacije[0] + ""))
            {
                MessageBox.Show("Uspešno ste izmenili profilne informacije.");
            }
            else
            {
                MessageBox.Show("Došlo je do greške, pokušajte ponovo.");
            }
        }
        public void PopuniProfilInfo()
        {
            textIme.Text = informacije[2].ToString();
            textPrezime.Text = informacije[3].ToString();
            textKorisnicko.Text = informacije[4].ToString();
            textLozinka.Text = informacije[5].ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NoviBioskop swap = new NoviBioskop();
            swap.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NoviDogadjaj swap = new NoviDogadjaj();
            swap.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bussines_.UcitajTabelu(dataGridView1, "SELECT * from dogadjaji inner join bioskopi on dogadjaji.idbioskop=bioskopi.bioskopid");
            bussines_.UcitajTabelu(dataGridView4, "SELECT nazivBioskopa as Bioskop, nazivFilma as Film, ime as Ime, prezime as Prezime, datum as Datum, rezervisaoKarata as Rezerviao from rezervacije inner join korisnici on rezervacije.idkorisnik=korisnici.korisnikid inner join dogadjaji on rezervacije.iddogadjaj=dogadjaji.dogadjajiid inner join bioskopi on dogadjaji.idbioskop=bioskopi.bioskopid");
            bussines_.UcitajTabelu(dataGridView5, "SELECT * from korisnici where  idstatus=1");
        }
    }
}
