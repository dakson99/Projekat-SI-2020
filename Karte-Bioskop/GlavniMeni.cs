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
    public partial class GlavniMeni : Form
    {
        Business bussines_ = new Business();
        string[] informacije = new string[6];
        public GlavniMeni(string [] info)
        {
            InitializeComponent();
            informacije = info;
            DateTime datum = DateTime.Now;
            bussines_.DizajnirajTabelu(dataGridView1);
            bussines_.DizajnirajTabelu(dataGridView2);
            bussines_.UcitajTabelu(dataGridView1, "SELECT dogadjajiid as ID, nazivBioskopa as Bioskop, datum as Datum, nazivFilma as Film, kapacitet as Kapacitet from dogadjaji inner join bioskopi on dogadjaji.idbioskop=bioskopi.bioskopid order by datum desc");
            bussines_.UcitajTabelu(dataGridView2, "SELECT nazivBioskopa as Bioskop, nazivFilma as Film, ime as Ime, prezime as Prezime, datum as Datum, rezervisaoKarata as Rezerviao from rezervacije inner join korisnici on rezervacije.idkorisnik=korisnici.korisnikid inner join dogadjaji on rezervacije.iddogadjaj=dogadjaji.dogadjajiid inner join bioskopi on dogadjaji.idbioskop=bioskopi.bioskopid where korisnikid=" + info[0] + "");
            PopuniProfilInfo();
        }

        public void PopuniProfilInfo()
        {
            textIme.Text = informacije[2].ToString();
            textPrezime.Text = informacije[3].ToString();
            textKorisnicko.Text = informacije[4].ToString();
            textLozinka.Text = informacije[5].ToString();
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(bussines_.izmeniProfilInfo("UPDATE korisnici set ime='"+textIme.Text+"',prezime='"+textPrezime.Text+"',korisnicko='"+textKorisnicko.Text+"',lozinka='"+textLozinka.Text+"' where korisnikid=" + informacije[0] + ""))
            {
                MessageBox.Show("Uspešno ste izmenili profilne informacije.");
            }
            else
            {
                MessageBox.Show("Došlo je do greške, pokušajte ponovo.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string dogadjajid = Convert.ToString(selectedRow.Cells[0].Value);
                int res = DateTime.Compare(Convert.ToDateTime(selectedRow.Cells[2].Value), bussines_.VratiDatum());
                if (res < 0)
                {
                    MessageBox.Show("Ovaj događaj se već završio");
                }
                else
                {
                    Rezervacije swap = new Rezervacije(dogadjajid, informacije[0], Convert.ToString(selectedRow.Cells[1].Value), Convert.ToString(selectedRow.Cells[2].Value), Convert.ToString(selectedRow.Cells[3].Value));
                    swap.Show();
                    this.Hide();
                }
                
            }
        }
    }
}
