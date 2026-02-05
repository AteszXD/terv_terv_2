using KockasFuzet.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;

namespace KockasFuzet.Controllers
{
    internal class SzolgaltatoController
    {
        public List<Szolgaltato> GetSzolgaltatoList()
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER=localhost;DATABASE=kockasfuzet;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;

            try
            {
                connection.Open();

                string cmd = "SELECT * FROM szolgaltato";
                MySqlCommand command = new MySqlCommand(cmd, connection);
                List<Szolgaltato> szolgaltatok = new List<Szolgaltato>();

                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    szolgaltatok.Add(new Szolgaltato()
                    {
                        RovidNev = reader.GetString("RovidNev"),
                        Nev = reader.GetString("Nev"),
                        Ugyfelszolgalat = reader.GetString("Ugyfelszolgalat")
                    });
                }

                connection.Close();
                return szolgaltatok;
            }
            catch (Exception)
            {
                return new List<Szolgaltato>();
            }

        }

        public string CreateSzolgaltato(Szolgaltato szolgaltato)
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER=localhost;DATABASE=kockasfuzet;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
            connection.Open();

            string cmd = "INSERT INTO `szolgaltato`(`RovidNev`, `Nev`, `Ugyfelszolgalat`) VALUES (@RovidNev,@Nev,@Ugyfelszolgalat)";
            MySqlCommand command = new MySqlCommand(cmd, connection);

            command.Parameters.AddWithValue("@Rovidnev", szolgaltato.RovidNev);
            command.Parameters.AddWithValue("@Nev", szolgaltato.Nev);
            command.Parameters.AddWithValue("@Ugyfelszolgalat", szolgaltato.Ugyfelszolgalat);

            int sorokSzama = command.ExecuteNonQuery();
            connection.Close();

            string valasz = sorokSzama > 0 ? "Sikeres rögzítés" : "Sikertelen rögzítés";
            return valasz;
        }
    }
}
