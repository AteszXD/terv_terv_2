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
            Program.WriteCentered($"Rövid név: {szolgaltato.RovidNev}");
            Program.WriteCentered($"Név: {szolgaltato.Nev}");
            Program.WriteCentered("Ügyfélszolgálat:");
            Program.WriteCentered($"Cím: {szolgaltato.Ugyfelszolgalat}");
            Program.WriteCentered($"Telefon: ");
        }

        public void ShowSzolgaltatoList(List<Szolgaltato> szolgaltatok)
        {
            Program.WriteCentered("┌────────┬───────────────────────────────┬───────────────────────────────┬─────────────┐");
            Program.WriteCentered("│Rövidnév│             Név               │        Ügyfélszolgálat        │   Telefon   │");
            foreach (Szolgaltato szolgaltato in szolgaltatok)
            {
                //120*30 méret
                Program.WriteCentered("├────────┼───────────────────────────────┼───────────────────────────────┼─────────────┤");
                Program.WriteCentered(SzolgaltatoToRow(szolgaltato));
            }
            Program.WriteCentered("└────────┴───────────────────────────────┴───────────────────────────────┴─────────────┘");
        }

        private static string SzolgaltatoToRow(Szolgaltato szolgaltato)
        {
            string row = "│";
            row += szolgaltato.RovidNev;
            row += new string(' ', 8 - szolgaltato.RovidNev.Length) + "│";
            row += szolgaltato.Nev.Length < 30 ? szolgaltato.Nev + new string(' ', 30 - szolgaltato.Nev.Length + 1) + "│" : szolgaltato.Nev.Substring(0, 28) + "...│";
            row += szolgaltato.Ugyfelszolgalat.Length < 30 ? szolgaltato.Ugyfelszolgalat + new string(' ', 30 - szolgaltato.Ugyfelszolgalat.Length + 1) + "│             │" : szolgaltato.Ugyfelszolgalat.Substring(0,28) + "...│             │";
            return row;
        }
    }
}
