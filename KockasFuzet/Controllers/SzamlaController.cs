using KockasFuzet.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;
using System.Data.SqlTypes;
using System.CodeDom;

namespace KockasFuzet.Controllers
{
    internal class SzamlaController
    {
        public List<Szamla> GetSzamlaList()
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER=localhost;DATABASE=kockasfuzet;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;

            try
            {
                connection.Open();

                string cmd = "SELECT * FROM szamla";
                MySqlCommand command = new MySqlCommand(cmd, connection);
                List<Szamla> szamlak = new List<Szamla>();

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string _megj;
                    try 
                    {
                        _megj = reader.GetString("Megjegyzes");
                    }
                    catch (SqlNullValueException)
                    {
                        _megj = " ";
                    }

                    szamlak.Add(new Szamla()
                    {
                        Id = reader.GetInt32("Id"),
                        SzolgaltatasAzon = reader.GetInt32("SzolgaltatasAzon"),
                        SzolgaltatasRovid = reader.GetString("SzolgaltatasRovid"),
                        Tol = reader.GetDateTime("Tol"),
                        Ig = reader.GetDateTime("Ig"),
                        Osszeg = reader.GetInt32("Osszeg"),
                        Hatarido = reader.GetDateTime("Hatarido"),
                        Befizetve = reader.GetDateTime("Befizetve"),
                        Megjegyzes = _megj
                    });
                }

                connection.Close();
                return szamlak;
            }
            catch (Exception)
            {
                return new List<Szamla>();
            }
}

        public string CreateSzamla(Szamla szamla)
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER=localhost;DATABASE=kockasfuzet;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
            connection.Open();

            string cmd = "INSERT INTO `szamla`(`Id`, `SzolgaltatasAzon`, `SzolgaltatasRovid`, `Tol`, `Ig`, `Osszeg`, `Hatarido`, `Befizetve`, `Megjegyzes`) VALUES (null,@SzolgaltatasAzon,@SzolgaltatasRovid,@Tol,@Ig,@Osszeg,@Hatarido,@Befizetve,@Megjegyzes)";
            MySqlCommand command = new MySqlCommand(cmd, connection);

            command.Parameters.AddWithValue("@SzolgaltatasAzon", szamla.SzolgaltatasAzon);
            command.Parameters.AddWithValue("@SzolgaltatasRovid", szamla.SzolgaltatasRovid);
            command.Parameters.AddWithValue("@Tol", szamla.Tol);
            command.Parameters.AddWithValue("@Ig", szamla.Ig);
            command.Parameters.AddWithValue("@Osszeg", szamla.Osszeg);
            command.Parameters.AddWithValue("@Hatarido", szamla.Hatarido);
            command.Parameters.AddWithValue("@Befizetve", szamla.Befizetve);
            command.Parameters.AddWithValue("@Megjegyzes", szamla.Megjegyzes);

            int sorokSzama;

            try
            {
                sorokSzama = command.ExecuteNonQuery();
            }
            catch (MySqlException)
            {
                sorokSzama = 0;
            }
            
            connection.Close();

            string valasz = sorokSzama > 0 ? "Sikeres rögzítés" : "Sikertelen rögzítés";
            return valasz;
        }
    }
}
