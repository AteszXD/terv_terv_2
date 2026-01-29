using KockasFuzet.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace KockasFuzet.Controllers
{
    internal class SzolgaltatoController
    {
        public List<Szolgaltato> GetSzolgaltatoList()
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER=localhost;DATABASE=kockasfuzet;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
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
    }
}
