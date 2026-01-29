using System;
using System.Collections.Generic;
using KockasFuzet.Models;

namespace KockasFuzet.Views
{
    internal class SzolgaltatoView
    {
        public SzolgaltatoView() 
        {
            
        }

        public void ShowSzolgaltato(Szolgaltato szolgaltato)
        {
            Console.WriteLine($"Rövid név: {szolgaltato.RovidNev}");
            Console.WriteLine($"Név: {szolgaltato.Nev}");
            Console.WriteLine("Ügyfélszolgálat:");
            Console.WriteLine($"Cím: {szolgaltato.Ugyfelszolgalat}");
            Console.WriteLine($"Telefon: ");
        }

        public void ShowSzolgaltatoList(List<Szolgaltato> szolgaltatok)
        {
            Console.WriteLine("|--------|-------------------------------|-------------------------------|-------------|");
            Console.WriteLine("|Rövidnév|             Név               |        Ügyfélszolgálat        |   Telefon   |");
            foreach (Szolgaltato szolgaltato in szolgaltatok)
            {
                //120*30 méret
                Console.WriteLine("|--------|-------------------------------|-------------------------------|-------------|");
                Console.WriteLine(SzolgaltatoToRow(szolgaltato));
            }
            Console.WriteLine("|--------|-------------------------------|-------------------------------|-------------|");
        }

        private static string SzolgaltatoToRow(Szolgaltato szolgaltato)
        {
            string row = "|";
            row += szolgaltato.RovidNev;
            row += new string(' ', 8 - szolgaltato.RovidNev.Length) + "|";
            row += szolgaltato.Nev.Length < 30 ? szolgaltato.Nev + new string(' ', 30 - szolgaltato.Nev.Length + 1) + "|" : szolgaltato.Nev.Substring(0, 28) + "...|";
            row += szolgaltato.Ugyfelszolgalat.Length < 30 ? szolgaltato.Ugyfelszolgalat + new string(' ', 30 - szolgaltato.Ugyfelszolgalat.Length + 1) + "|             |" : szolgaltato.Ugyfelszolgalat.Substring(0,28) + "...|             |";
            return row;
        }
    }
}
