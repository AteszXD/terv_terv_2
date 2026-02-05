using KockasFuzet.Models;
using KockasFuzet.Views;
using MySql.Data.MySqlClient;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlTypes;

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

        public string UpdateSzamla(Szamla szamla)
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER=localhost;DATABASE=kockasfuzet;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
            connection.Open();

            List<Szamla> szamladb = new SzamlaController().GetSzamlaList();
            Console.WriteLine();
            new SzamlaView().ShowSzamlaList(szamladb);
            Console.WriteLine();

            Console.Write("A módosítandó számla Id-je: ");
            int id = int.Parse(Console.ReadLine());

            string cmd = "UPDATE `szamla` SET Id=@Id,SzolgaltatasAzon=@SzolgaltatasAzon,SzolgaltatasRovid=@SzolgaltatasRovid,Tol=@Tol,Ig=@Ig,Osszeg=@Osszeg,Hatarido=@Hatarido,Befizetve=@Befizetve,Megjegyzes=@Megjegyzes WHERE Id=@id";
            MySqlCommand command = new MySqlCommand(cmd, connection);

            command.Parameters.AddWithValue("@Id", id);
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

            string valasz = sorokSzama > 0 ? "Sikeres frissítés" : "Sikertelen frissítés";
            return valasz;
        }

        public string DeleteSzamla()
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER=localhost;DATABASE=kockasfuzet;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
            connection.Open();

            List<Szamla> szamladb = new SzamlaController().GetSzamlaList();
            Console.WriteLine();
            new SzamlaView().ShowSzamlaList(szamladb);
            Console.WriteLine();

            Console.Write("A törlendő számla Id-je: ");
            int id = int.Parse(Console.ReadLine());

            string cmd = "DELETE FROM `szamla` WHERE Id=@Id";
            MySqlCommand command = new MySqlCommand(cmd, connection);

            command.Parameters.AddWithValue("@id", id);

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

            string valasz = sorokSzama > 0 ? "Sikeres törlés" : "Sikertelen törlés";
            return valasz;
        }
    }
}
