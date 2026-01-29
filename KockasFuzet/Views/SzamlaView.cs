using System;
using System.Collections.Generic;
using KockasFuzet.Models;

namespace KockasFuzet.Views
{
    internal class SzamlaView
    {
        public SzamlaView()
        {

        }

        public void ShowSzamla(Szamla szamla)
        {
            Console.WriteLine($"Id: {szamla.Id}");
            Console.WriteLine($"SzolgaltatasAzon: {szamla.SzolgaltatasAzon}");
            Console.WriteLine($"SzolgaltatasRovid: {szamla.SzolgaltatasRovid}");
            Console.WriteLine($"Tól: {szamla.Tol}");
            Console.WriteLine($"Ig: {szamla.Ig}");
            Console.WriteLine($"Osszeg: {szamla.Osszeg}");
            Console.WriteLine($"Határidő: {szamla.Hatarido}");
            Console.WriteLine($"Befizetve: {szamla.Befizetve}");
            Console.WriteLine($"Megjegyzés: {szamla.Megjegyzes}");
        }

        public void ShowSzamlaList(List<Szamla> szamlak)
        {
            Console.WriteLine("+---+----------------+-----------------+----------+----------+------+----------+----------+");
            Console.WriteLine("|Id |SzolgaltatasAzon|SzolgaltatasRovid|Tól       |Ig        |Összeg|Határidő  |Befizetve |");
            foreach (Szamla szamla in szamlak)
            {
                //120*30 méret
                Console.WriteLine("+---+----------------+-----------------+----------+----------+------+----------+----------+");
                Console.WriteLine(SzamlaToRow(szamla));
            }
            Console.WriteLine("+---+----------------+-----------------+----------+----------+------+----------+----------+");
        }

        private static string SzamlaToRow(Szamla szamla)
        {
            string row = "|";
            row += szamla.Id;
            row += new string(' ', 3 - szamla.Id.ToString().Length) + "|";
            row += szamla.SzolgaltatasAzon.ToString().Length < 16 ? szamla.SzolgaltatasAzon.ToString() + new string(' ', 16 - szamla.SzolgaltatasAzon.ToString().Length) + "|" : szamla.SzolgaltatasAzon.ToString().Substring(0, 14) + "...|";
            row += szamla.SzolgaltatasRovid.Length < 17 ? szamla.SzolgaltatasRovid + new string(' ', 17 - szamla.SzolgaltatasRovid.Length) + "|" : szamla.SzolgaltatasRovid.Substring(0, 15) + "...|";
            row += szamla.Tol.ToString("yyyy-MM-dd").Length < 10 ? szamla.Tol.ToString("yyyy-MM-dd") + new string(' ', 10 - szamla.Tol.ToString("yyyy-MM-dd").Length + 1) + "|" : szamla.Tol.ToString("yyyy-MM-dd").Substring(0, 10) + "|";
            row += szamla.Ig.ToString("yyyy-MM-dd").Length < 10 ? szamla.Ig.ToString("yyyy-MM-dd") + new string(' ', 10 - szamla.Ig.ToString("yyyy-MM-dd").Length + 1) + "|" : szamla.Ig.ToString("yyyy-MM-dd").Substring(0, 10) + "|";
            row += szamla.Osszeg.ToString().Length < 6 ? szamla.Osszeg.ToString() + new string(' ', 6 - szamla.Osszeg.ToString().Length) + "|" : szamla.Osszeg.ToString().Substring(0, 4) + "...|";
            row += szamla.Hatarido.ToString("yyyy-MM-dd").Length < 10 ? szamla.Hatarido.ToString("yyyy-MM-dd") + new string(' ', 10 - szamla.Hatarido.ToString("yyyy-MM-dd").Length + 1) + "|" : szamla.Hatarido.ToString("yyyy-MM-dd").Substring(0, 10) + "|";
            row += szamla.Befizetve.ToString("yyyy-MM-dd").Length < 10 ? szamla.Befizetve.ToString("yyyy-MM-dd") + new string(' ', 10 - szamla.Befizetve.ToString("yyyy-MM-dd").Length + 1) + "|" : szamla.Befizetve.ToString("yyyy-MM-dd").Substring(0, 10) + "|";         
            return row;
        }
    }
}
