using System;
using System.Collections.Generic;
using KockasFuzet.Models;
using KockasFuzet.Views;
using KockasFuzet.Controllers;

namespace KockasFuzet
{
    internal class Program
    {
        static void Main(string[] _)
        {
            Console.WriteLine("1. Adott szolgáltató kiírása");
            Console.WriteLine("2. Szolgáltatók listáza");
            Console.WriteLine("3. Szolgáltatások listázása");
            Console.WriteLine("999. Kilépés");

            string valasz = Console.ReadLine();
            switch (valasz)
            {
                case "1":
                    Szolgaltato szolgaltato = new Szolgaltato()
                    {
                        RovidNev = "ABC",
                        Nev = "Helyi kis ABC",
                        Ugyfelszolgalat = "Miskolc, Búza tér 2/B"
                    };
                    new SzolgaltatoView().ShowSzolgaltato(szolgaltato);
                    break;
                case "2":
                    List<Szolgaltato> szolgaltatodb = new SzolgaltatoController().GetSzolgaltatoList();
                    new SzolgaltatoView().ShowSzolgaltatoList(szolgaltatodb);
                    break;
                case "3":
                    List<Szolgaltatas> szolgaltatasdb = new SzolgaltatasController().GetSzolgaltatasList();
                    new SzolgaltatasView().ShowSzolgaltatasList(szolgaltatasdb);
                    break;
                case "4":
                    List<Szamla> szamladb = new SzamlaController().GetSzamlaList();
                    new SzamlaView().ShowSzolgaltatasList(szamladb);
                    break;
                case "999":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
