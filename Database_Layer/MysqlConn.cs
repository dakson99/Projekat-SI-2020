using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Layer
{
    public class MysqlConn
    {
        private MySqlConnection konekcija;
        static string server = "localhost";
        static string baza = "karte_bioskop";
        static string lozinka = "marko";
        static string korisnicko = "root";
        public static string konektor = "SERVER="+ server + ";DATABASE="+ baza + ";UID="+ korisnicko + ";PASSWORD="+ lozinka + ";";
        public MysqlConn()
        {
            Initialize();
        }

        private void Initialize()
        {
           
            konekcija = new MySqlConnection(konektor);
        }
        public string VratiGresku(string error)
        {
            return error;
        }
        private bool OtvoriKonekciju()
        {
            try
            {
                konekcija.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                VratiGresku(ex.Message);
                return false;
            }
        }
        private bool ZatvoriKonekciju()
        {
            try
            {
                konekcija.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                VratiGresku(ex.Message);
                return false;
            }
        }
        public void RezervnaKopija()
        {
            try
            {
                DateTime Time = DateTime.Now;
                int year = Time.Year;
                int month = Time.Month;
                int day = Time.Day;
                int hour = Time.Hour;
                int minute = Time.Minute;
                int second = Time.Second;
                int millisecond = Time.Millisecond;


                string path;
                path = "C:\\MySqlBackup" + year + "-" + month + "-" + day + "-" + hour + "-" + minute + "-" + second + "-" + millisecond + ".sql";
                StreamWriter file = new StreamWriter(path);
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysqldump";
                psi.RedirectStandardInput = false;
                psi.RedirectStandardOutput = true;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                    korisnicko, lozinka, server, baza);
                psi.UseShellExecute = false;

                Process process = Process.Start(psi);

                string output;
                output = process.StandardOutput.ReadToEnd();
                file.WriteLine(output);
                process.WaitForExit();
                file.Close();
                process.Close();
            }
            catch (IOException ex)
            {
                VratiGresku(ex.Message);
            }
        }
        public void UcitajRezevnuKopiju()
        {
            try
            {
                string path;
                path = "C:\\MySqlBackup.sql";
                StreamReader file = new StreamReader(path);
                string input = file.ReadToEnd();
                file.Close();

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysql";
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = false;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                    korisnicko, lozinka, server, baza);
                psi.UseShellExecute = false;


                Process process = Process.Start(psi);
                process.StandardInput.WriteLine(input);
                process.StandardInput.Close();
                process.WaitForExit();
                process.Close();
            }
            catch (IOException ex)
            {
                VratiGresku(ex.Message);
            }
        }
        public void DodajRed(string query)
        {
            if (this.OtvoriKonekciju() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, konekcija);
                cmd.ExecuteNonQuery();
                this.ZatvoriKonekciju();
            }
        }
        public void IzmeniRed(string query)
        {
            if (this.OtvoriKonekciju() == true)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = konekcija;
                cmd.ExecuteNonQuery();
                this.ZatvoriKonekciju();
            }
        }
        public void IzbrisiRed(string query)
        {
            if (this.OtvoriKonekciju() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, konekcija);
                cmd.ExecuteNonQuery();
                this.ZatvoriKonekciju();
            }
        }
        public List<string> VratiListu(string query)
        {
            List<string> list = new List<string>();
            if (this.OtvoriKonekciju() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, konekcija);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    list.Add(dataReader[0].ToString());

                }
                dataReader.Close();
                this.ZatvoriKonekciju();
                return list;
            }
            else
            {
                return list;
            }
        }
        public int Brojac(string query)
        {

            int Count = -1;

            if (this.OtvoriKonekciju() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, konekcija);
                Count = int.Parse(cmd.ExecuteScalar() + "");
                this.ZatvoriKonekciju();
                return Count;
            }
            else
            {
                return Count;
            }
        }

        public DataSet VraitDataSet(string sql)
        {
            MySqlConnection konektor = new MySqlConnection(MysqlConn.konektor);
            MySqlCommand cmd = new MySqlCommand(sql, konektor);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            konektor.Close();

            return ds;
        }

        public DataTable VratiDataTable(string sql)
        {
            Console.WriteLine(sql);
            DataSet ds = VraitDataSet(sql);

            if (ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        public string[] VratiInfo(string upit)
        {
            string[]rez = new string[6];
            MySqlConnection kon = new MySqlConnection(konektor);
            MySqlCommand cmdDataBase = new MySqlCommand(upit, kon);
            MySqlDataReader myReader;
            try
            {
                kon.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                        rez[0] = myReader[1].ToString();
                        rez[1] = myReader[2].ToString();
                        rez[2] = myReader[3].ToString();
                        rez[3] = myReader[4].ToString();
                        rez[4] += myReader[5].ToString();
                        rez[5] += myReader[6].ToString();
                }
                kon.Close();
            }

            catch (Exception ex)
            {
                VratiGresku(ex.Message);

            }
            return rez;
        }
        public string VratiID(string upit)
        {
            string rez=null;
            MySqlConnection kon = new MySqlConnection(konektor);
            MySqlCommand cmdDataBase = new MySqlCommand(upit, kon);
            MySqlDataReader myReader;
            try
            {
                kon.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    rez = myReader[0].ToString();
                   
                }
                kon.Close();
            }

            catch (Exception ex)
            {
                VratiGresku(ex.Message);

            }
            return rez;
        }

    }
}
