using Database_Layer;
using Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Business_Layer
{
    public class Business : IBussiness
    {
        MysqlConn konekcija = new MysqlConn();
        public void DizajnirajTabelu(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
            dgv.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgv.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgv.BackgroundColor = Color.White;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
        
        
        public int vratiStatistiku(int opcija)
        {
            string sql;
            if (opcija == 1)
            {
                sql = "SELECT count(*) from  bioskopi";
                konekcija.Brojac(sql);
                return konekcija.Brojac(sql);
            }
            else if (opcija == 2)
            {
                sql = "SELECT count(*) from korisnici where idstatus=2";
                konekcija.Brojac(sql);
                return konekcija.Brojac(sql);
            }
            else if (opcija == 3)
            {
                sql = "SELECT count(*) from korisnici where idstatus=1";
                konekcija.Brojac(sql);
                return konekcija.Brojac(sql);
            }  
            else if (opcija == 4)
            {
                DateTime datum = DateTime.Now;
                sql = "SELECT count(*) from dogadjaji where datum<'" + datum.ToString("yyyy-MM-dd") + "'";
                return konekcija.Brojac(sql);
            }     
            else if (opcija == 5)
            {
                DateTime datum = DateTime.Now;
                sql = "SELECT count(*) from dogadjaji where datum>'" + datum.ToString("yyyy-MM-dd") + "'";
                return konekcija.Brojac(sql);
            }
            else if (opcija == 6)
            {
                DateTime datum = DateTime.Now;
                sql = "SELECT count(*) from dogadjaji where datum='" + datum + "'";
                return konekcija.Brojac(sql);
            }
            else if (opcija == 7)
            {
                sql = "SELECT count(*) from dogadjaji";
                konekcija.Brojac(sql);
                return konekcija.Brojac(sql);
            }
            else
            {
                return 0;
            }
        }

        public void UcitajTabelu(DataGridView dgv, string s)
        {
            DataTable dt = konekcija.VratiDataTable(s);
            dgv.DataSource = dt;
        }
        public bool Registracija(string ime, string prezime, string korisnicko, string lozinka)
        {
            try
            {
                string sql = "INSERT INTO korisnici (ime,prezime,korisnicko,lozinka) VALUES ('" + ime + "', '" + prezime + "', '" + korisnicko + "', '" + lozinka + "');";
                konekcija.DodajRed(sql);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public string[] Prijava(string korisnicko, string lozinka)
        {
            string sql = "SELECT count(*),korisnikid,idstatus,ime,prezime,korisnicko,lozinka from korisnici where korisnicko='"+korisnicko+"' and lozinka='"+lozinka+"';";
           
            
            int broj = konekcija.Brojac(sql);
            if (broj == 1)
            {
                
                return KorisnikInfo(konekcija.VratiInfo(sql));

            }
            return null;
        }
        public string [] KorisnikInfo(string [] upit)
        {
            return upit;
        }

        public bool izmeniProfilInfo(string upit)
        {
            try
            {
                konekcija.IzmeniRed(upit);
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        public DateTime VratiDatum()
        {
            DateTime datum = DateTime.Now;
            datum.ToString("yyyy-MM-dd");
            return datum;
        }
        public bool DodajBioskop(string naziv, string adresa, string email, string telefon, string kapacitet)
        {
            try
            {
                string sql = "INSERT INTO bioskopi (nazivBioskopa,adresa,telefon,email,kapacitet) VALUES ('" + naziv + "', '" + adresa + "', '" + telefon + "', '" + email + "', '" + kapacitet + "');";
                konekcija.DodajRed(sql);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<string> VratiListuBioskopa()
        {
            return konekcija.VratiListu("SELECT nazivBioskopa from bioskopi");
        }

        public void UcitajBioskope(ComboBox cmb)
        {
            var lista = VratiListuBioskopa();
            int x = 0;
            while (x < lista.Count())
            {
                cmb.Items.Add(lista[x]);
                x++;
            }
        }
        public bool DodajDogadjaj(string nazivFilma, string idboskop, string datum)
        {
            try
            {

                string sql = "INSERT INTO dogadjaji (nazivFilma,idbioskop,datum) VALUES ('" + nazivFilma + "', '" + idboskop + "', '" + datum + "');";
                konekcija.DodajRed(sql);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public string VratiBoiskopID(string nazivBioskopa)
        {
            return konekcija.VratiID("SELECT bioskopid from bioskopi where nazivBioskopa='"+nazivBioskopa+"'");
        }

        public bool BrojKarata(int broj)
        {
            if (broj > 5)
            {
                return false;
            }
            return true;
        }

        public bool RezervisiKarte(string iddogadjaj, string idkorisnik, string rezervisaoKarata)
        {
            try
            {
                string sql = "INSERT INTO rezervacije (iddogadjaj,idkorisnik,rezervisaoKarata) VALUES ('" + iddogadjaj + "', '" + idkorisnik + "', '" + rezervisaoKarata + "');";
                konekcija.DodajRed(sql);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
