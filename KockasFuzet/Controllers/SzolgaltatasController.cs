using KockasFuzet.Models;
using KockasFuzet.Views;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

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

        public List<int> GetSzolgaltatasAzonList()
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER=localhost;DATABASE=kockasfuzet;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;

            try
            {
                connection.Open();

                string cmd = "SELECT Id FROM szolgaltatas";
                MySqlCommand command = new MySqlCommand(cmd, connection);
                List<int> szolgaltatasAzonList = new List<int>();

                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    szolgaltatasAzonList.Add(reader.GetInt32("Id"));
                }

                connection.Close();
                return szolgaltatasAzonList;
            }
            catch (Exception)
            {
                return new List<int>();
            }
        }

        public string CreateSzolgaltatas(Szolgaltatas szolgaltatas)
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER=localhost;DATABASE=kockasfuzet;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
            connection.Open();

            string cmd = "INSERT INTO `szolgaltatas`(`Id`, `Nev`) VALUES (null,@Nev)";
            MySqlCommand command = new MySqlCommand(cmd, connection);

            command.Parameters.AddWithValue("@Nev", szolgaltatas.Nev);

            int sorokSzama = command.ExecuteNonQuery();
            connection.Close();

            string valasz = sorokSzama > 0 ? "Sikeres rögzítés" : "Sikertelen rögzítés";
            return valasz;
        }

        public string UpdateSzolgaltatas(Szolgaltatas szolgaltatas)
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER=localhost;DATABASE=kockasfuzet;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
            connection.Open();

            List<Szolgaltatas> szolgaltatasdb = new SzolgaltatasController().GetSzolgaltatasList();
            Console.WriteLine();
            new SzolgaltatasView().ShowSzolgaltatasList(szolgaltatasdb);
            Console.WriteLine();

            Console.Write("A módosítandó szolgáltatás Id-je: ");
            int id = int.Parse(Console.ReadLine());

            string cmd = "UPDATE `szolgaltatas` SET Id=@id,Nev=@Nev WHERE Id=@Id";
            MySqlCommand command = new MySqlCommand(cmd, connection);

            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@Nev", szolgaltatas.Nev);

            int sorokSzama = command.ExecuteNonQuery();
            connection.Close();

            string valasz = sorokSzama > 0 ? "Sikeres rögzítés" : "Sikertelen rögzítés";
            return valasz;
        }
    }
}
