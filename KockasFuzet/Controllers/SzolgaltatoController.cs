using KockasFuzet.Models;
using KockasFuzet.Views;
using MySql.Data.MySqlClient;
using System;
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

        public string UpdateSzolgaltato(Szolgaltato szolgaltato)
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER=localhost;DATABASE=kockasfuzet;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
            connection.Open();

            List<Szolgaltato> szolgaltatodb = new SzolgaltatoController().GetSzolgaltatoList();
            Console.WriteLine();
            new SzolgaltatoView().ShowSzolgaltatoList(szolgaltatodb);
            Console.WriteLine();

            Console.Write("A módosítandó szolgáltató rövid neve: ");
            string rovidNev = Console.ReadLine();

            string cmd = "UPDATE `szolgaltato` SET RovidNev=@RovidNev,Nev=@Nev,Ugyfelszolgalat=@Ugyfelszolgalat WHERE RovidNev=@RovidNev";
            MySqlCommand command = new MySqlCommand(cmd, connection);

            command.Parameters.AddWithValue("@Rovidnev", rovidNev);
            command.Parameters.AddWithValue("@Nev", szolgaltato.Nev);
            command.Parameters.AddWithValue("@Ugyfelszolgalat", szolgaltato.Ugyfelszolgalat);

            int sorokSzama = command.ExecuteNonQuery();
            connection.Close();

            string valasz = sorokSzama > 0 ? "Sikeres frissítés" : "Sikertelen frissítés";
            return valasz;
        }

        public string DeleteSzolgaltato()
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER=localhost;DATABASE=kockasfuzet;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
            connection.Open();

            List<Szolgaltato> szolgaltatodb = new SzolgaltatoController().GetSzolgaltatoList();
            Console.WriteLine();
            new SzolgaltatoView().ShowSzolgaltatoList(szolgaltatodb);
            Console.WriteLine();

            Console.Write("A törlendő szolgáltató rövid neve: ");
            string rnev = Console.ReadLine();

            string cmd = "DELETE FROM `szolgaltato` WHERE RovidNev=@RovidNev";
            MySqlCommand command = new MySqlCommand(cmd, connection);

            command.Parameters.AddWithValue("@RovidNev", rnev);

            int sorokSzama = command.ExecuteNonQuery();

            connection.Close();

            string valasz = sorokSzama > 0 ? "Sikeres törlés" : "Sikertelen törlés";
            return valasz;
        }
    }
}
