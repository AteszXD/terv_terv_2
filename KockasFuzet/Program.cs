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
            Console.WriteLine("1. Random szolgáltató kiírása");
            Console.WriteLine("2. Random szolgáltatás kiírása");
            Console.WriteLine("3. Random számla kiírása");
            Console.WriteLine("4. Szolgáltatók listáza");
            Console.WriteLine("5. Szolgáltatások listázása");
            Console.WriteLine("6. Számlák listázása");
            Console.WriteLine("7. Szolgáltató felvétele");
            Console.WriteLine("999. Kilépés");
            Console.WriteLine();

            string valasz = Console.ReadLine();
            Console.WriteLine();

            switch (valasz)
            {
                case "1":
                    List<Szolgaltato> _szolgaltatodb = new SzolgaltatoController().GetSzolgaltatoList();
                    Random random = new Random();
                    int i = random.Next(_szolgaltatodb.Count);
                    new SzolgaltatoView().ShowSzolgaltato(_szolgaltatodb[i]);
                    break;
                case "2":
                    List<Szolgaltatas> _szolgaltatasdb = new SzolgaltatasController().GetSzolgaltatasList();
                    random = new Random();
                    i = random.Next(_szolgaltatasdb.Count);
                    new SzolgaltatasView().ShowSzolgaltatas(_szolgaltatasdb[i]);
                    break;
                case "3":
                    List<Szamla> _szamladb = new SzamlaController().GetSzamlaList();
                    random = new Random();
                    i = random.Next(_szamladb.Count);
                    new SzamlaView().ShowSzamla(_szamladb[i]);
                    break;
                case "4":
                    List<Szolgaltato> szolgaltatodb = new SzolgaltatoController().GetSzolgaltatoList();
                    new SzolgaltatoView().ShowSzolgaltatoList(szolgaltatodb);
                    break;
                case "5":
                    List<Szolgaltatas> szolgaltatasdb = new SzolgaltatasController().GetSzolgaltatasList();
                    new SzolgaltatasView().ShowSzolgaltatasList(szolgaltatasdb);
                    break;
                case "6":
                    List<Szamla> szamladb = new SzamlaController().GetSzamlaList();
                    new SzamlaView().ShowSzamlaList(szamladb);
                    break;
                case "7":
                    Console.Write("Rövid Név: ");
                    string rnev = Console.ReadLine();

                    Console.Write("Név: ");
                    string tnev = Console.ReadLine();

                    Console.Write("Ügyfélszolgálat: ");
                    string ugyf = Console.ReadLine();

                    Szolgaltato szolgaltato = new Szolgaltato(rnev, tnev, ugyf);
                    Console.WriteLine(new SzolgaltatoController().CreateSzolgaltato(szolgaltato));

                    break;
                case "999":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
