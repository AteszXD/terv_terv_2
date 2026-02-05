using KockasFuzet.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;

namespace KockasFuzet.Controllers
{
    internal class SzolgaltatasController
    {
        public List<Szolgaltatas> GetSzolgaltatasList()
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER=localhost;DATABASE=kockasfuzet;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;

            try
            {
                connection.Open();

                string cmd = "SELECT * FROM szolgaltatas";
                MySqlCommand command = new MySqlCommand(cmd, connection);
                List<Szolgaltatas> szolgaltatasok = new List<Szolgaltatas>();

                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    szolgaltatasok.Add(new Szolgaltatas()
                    {
                        Id = reader.GetInt32("Id"),
                        Nev = reader.GetString("Nev")
                    });
                }

                connection.Close();
                return szolgaltatasok;
            }
            catch (Exception)
            {
                return new List<Szolgaltatas>();
            }
        }
    }
}
