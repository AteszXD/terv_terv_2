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
            Console.WriteLine("1. Szolgáltatók listáza");
            Console.WriteLine("2. Szolgáltatások listázása");
            Console.WriteLine("3. Számlák listázása");
            Console.WriteLine("4. Szolgáltató felvétele");
            Console.WriteLine("5. Szolgáltatás felvétele");
            Console.WriteLine("6. Számla felvétele");
            Console.WriteLine("996. Random szolgáltató kiírása");     // View teszt
            Console.WriteLine("997. Random szolgáltatás kiírása");    // View teszt
            Console.WriteLine("998. Random számla kiírása");          // View teszt
            Console.WriteLine("999. Kilépés");                        // Kilépés...
            Console.WriteLine();

            string valasz = Console.ReadLine();
            Console.WriteLine();

            switch (valasz)
            {
                case "1":
                    List<Szolgaltato> szolgaltatodb = new SzolgaltatoController().GetSzolgaltatoList();
                    new SzolgaltatoView().ShowSzolgaltatoList(szolgaltatodb);
                    break;
                case "2":
                    List<Szolgaltatas> szolgaltatasdb = new SzolgaltatasController().GetSzolgaltatasList();
                    new SzolgaltatasView().ShowSzolgaltatasList(szolgaltatasdb);
                    break;
                case "3":
                    List<Szamla> szamladb = new SzamlaController().GetSzamlaList();
                    new SzamlaView().ShowSzamlaList(szamladb);
                    break;
                case "4":
                    Console.Write("Rövid Név: ");
                    string rnev = Console.ReadLine();

                    Console.Write("Név: ");
                    string tnev = Console.ReadLine();

                    Console.Write("Ügyfélszolgálat: ");
                    string ugyf = Console.ReadLine();

                    Szolgaltato szolgaltato = new Szolgaltato(rnev, tnev, ugyf);
                    Console.WriteLine(new SzolgaltatoController().CreateSzolgaltato(szolgaltato));

                    break;
                case "5":
                    int id = -1; // Amúgy se fogja használni

                    Console.Write("Név: ");
                    string nev = Console.ReadLine();

                    Szolgaltatas szolgaltatas = new Szolgaltatas(id, nev);
                    Console.WriteLine(new SzolgaltatasController().CreateSzolgaltatas(szolgaltatas));

                    break;
                case "996":
                    List<Szolgaltato> _szolgaltatodb = new SzolgaltatoController().GetSzolgaltatoList();
                    Random random = new Random();
                    int i = random.Next(_szolgaltatodb.Count);
                    new SzolgaltatoView().ShowSzolgaltato(_szolgaltatodb[i]);
                    break;
                case "997":
                    List<Szolgaltatas> _szolgaltatasdb = new SzolgaltatasController().GetSzolgaltatasList();
                    random = new Random();
                    i = random.Next(_szolgaltatasdb.Count);
                    new SzolgaltatasView().ShowSzolgaltatas(_szolgaltatasdb[i]);
                    break;
                case "998":
                    List<Szamla> _szamladb = new SzamlaController().GetSzamlaList();
                    random = new Random();
                    i = random.Next(_szamladb.Count);
                    new SzamlaView().ShowSzamla(_szamladb[i]);
                    break;
                case "999":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
