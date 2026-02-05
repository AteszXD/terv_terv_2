using KockasFuzet.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;

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
                    szamlak.Add(new Szamla()
                    {
                        Id = reader.GetInt32("Id"),
                        SzolgaltatasAzon = reader.GetInt32("SzolgaltatasAzon"),
                        SzolgaltatasRovid = reader.GetString("SzolgaltatasRovid"),
                        Tol = reader.GetDateTime("Tol"),
                        Ig = reader.GetDateTime("Ig"),
                        Osszeg = reader.GetInt32("Osszeg"),
                        Hatarido = reader.GetDateTime("Hatarido"),
                        Befizetve = reader.GetDateTime("Befizetve")//,
                        //Megjegyzes = reader.GetString("Megjegyzes")
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
    }
}
