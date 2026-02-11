using System.Collections.Generic;
using KockasFuzet.Models;

namespace KockasFuzet.Views
{
    internal class SzolgaltatasView
    {
        public SzolgaltatasView()
        {

        }

        public void ShowSzolgaltatas(Szolgaltatas szolgaltatas)
        {
            Program.WriteCentered($"Id: {szolgaltatas.Id}");
            Program.WriteCentered($"Név: {szolgaltatas.Nev}");
        }

        public void ShowSzolgaltatasList(List<Szolgaltatas> szolgaltatasok)
        {
            Program.WriteCentered("┌───┬───────────────────────────────┐");
            Program.WriteCentered("│Id │             Név               │");
            foreach (Szolgaltatas szolgaltatas in szolgaltatasok)
            {
                //120*30 méret
                Program.WriteCentered("├───┼───────────────────────────────┤");
                Program.WriteCentered(SzolgaltatasToRow(szolgaltatas));
            }
            Program.WriteCentered("└───┴───────────────────────────────┘");
        }

        private static string SzolgaltatasToRow(Szolgaltatas szolgaltatas)
        {
            string row = "│";
            row += szolgaltatas.Id;
            row += new string(' ', 3 - szolgaltatas.Id.ToString().Length) + "│";
            row += szolgaltatas.Nev.Length < 30 ? szolgaltatas.Nev + new string(' ', 30 - szolgaltatas.Nev.Length + 1) + "│" : szolgaltatas.Nev.Substring(0, 28) + "...│";
            return row;
        }
    }
}
