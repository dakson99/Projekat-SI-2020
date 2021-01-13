using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface
{
    public interface IBussiness
    {
        string[] Prijava(string korisnicko, string lozinka);
        string[] KorisnikInfo(string[] upit);
        bool Registracija(string ime, string prezime, string korisnicko, string lozinka);
        int vratiStatistiku(int opcija);
        void DizajnirajTabelu(DataGridView dgv);
        void UcitajTabelu(DataGridView dgv, string s);
        bool izmeniProfilInfo(string upit);
        DateTime VratiDatum();
        bool DodajBioskop(string naziv, string adresa, string email, string telefon, string kapacitet);
        List<string> VratiListuBioskopa();
        void UcitajBioskope(ComboBox cmb);
        bool DodajDogadjaj(string nazivFilma, string dogadjajid, string datum);
        string VratiBoiskopID(string nazivBioskopa);
        bool BrojKarata(int broj);
        bool RezervisiKarte(string iddogadjaj, string idkorisnik, string rezervisaoKarata);

    }
}
