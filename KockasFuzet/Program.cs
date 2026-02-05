using System;
using System.Collections.Generic;
using KockasFuzet.Models;
using KockasFuzet.Views;
using KockasFuzet.Controllers;
using System.Globalization;

namespace KockasFuzet
{
    internal class Program
    {
        static void Main(string[] _)
        {
            Console.WriteLine("------- Listázás -------");
            Console.WriteLine("1. Szolgáltatók listáza");
            Console.WriteLine("2. Szolgáltatások listázása");
            Console.WriteLine("3. Számlák listázása");
            Console.WriteLine();
            Console.WriteLine("------- Felvétel -------");
            Console.WriteLine("4. Szolgáltató felvétele");
            Console.WriteLine("5. Szolgáltatás felvétele");
            Console.WriteLine("6. Számla felvétele");
            Console.WriteLine();
            Console.WriteLine("------- Módosítás -------");
            Console.WriteLine("7. Szolgáltató módosítása");
            Console.WriteLine("8. Szolgáltatás módosítása");
            Console.WriteLine("9. Számla módosítása");
            Console.WriteLine();
            Console.WriteLine("------- Törlés -------");
            Console.WriteLine("10. Szolgáltató törlése");
            Console.WriteLine("11. Szolgáltatás törlése");
            Console.WriteLine("12. Számla törlése");
            Console.WriteLine();
            Console.WriteLine("------- Debug -------");
            Console.WriteLine("996. Random szolgáltató kiírása");     // View teszt
            Console.WriteLine("997. Random szolgáltatás kiírása");    // View teszt
            Console.WriteLine("998. Random számla kiírása");          // View teszt
            Console.WriteLine("999. Kilépés");                        // Kilépés...
            Console.WriteLine();

            string valasz = Console.ReadLine();
            Console.WriteLine();

            switch (valasz)
            {
                #region Listázás
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
                #endregion
                #region Felvétel
                case "4":
                    Console.WriteLine(new SzolgaltatoController().CreateSzolgaltato(SzolgaltatoBekeres()));
                    break;

                case "5":
                    Console.WriteLine(new SzolgaltatasController().CreateSzolgaltatas(SzolgaltatasBekeres()));
                    break;

                case "6":
                    Console.WriteLine(new SzamlaController().CreateSzamla(SzamlaBekeres()));
                    break;
                #endregion

                #region Módosítás
                case "7":
                    Console.WriteLine(new SzolgaltatoController().UpdateSzolgaltato(SzolgaltatoBekeres()));
                    break;
                
                case "8":
                    Console.WriteLine(new SzolgaltatasController().UpdateSzolgaltatas(SzolgaltatasBekeres()));
                    break;

                case "9":
                    Console.WriteLine(new SzamlaController().UpdateSzamla(SzamlaBekeres()));
                    break;
                #endregion

                #region Törlés
                case "10":
                    Console.WriteLine(new SzolgaltatoController().DeleteSzolgaltato());
                    break;

                case "11":
                    Console.WriteLine(new SzolgaltatasController().DeleteSzolgaltatas());
                    break;

                case "12":
                    Console.WriteLine(new SzamlaController().DeleteSzamla());
                    break;

                #endregion

                #region Debug
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
                #endregion
            }

            Szamla SzamlaBekeres()
            {
                int idSzamla = -1; // Amúgy se fogja használni

                int szolgAzon;
                while (true)
                {
                    Console.Write("Szolgáltatás azonosító: ");
                    try
                    {
                        szolgAzon = int.Parse(Console.ReadLine());
                        if (szolgAzon > 0)
                        {
                            break;
                        }
                        throw new Exception();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Ide pozitív szám kell");
                    }
                }

                Console.Write("Szolgáltató rövid neve: ");
                string szolgRovid = Console.ReadLine();

                DateTime tol;
                while (true)
                {
                    Console.Write("Tol (ÉÉÉÉ-HH-NN): ");
                    try
                    {
                        tol = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Érvénytelen dátum!");
                    }
                }

                DateTime ig;
                while (true)
                {
                    Console.Write("Ig (ÉÉÉÉ-HH-NN): ");
                    try
                    {
                        ig = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Érvénytelen dátum!");
                    }
                }

                int osszeg;
                while (true)
                {
                    Console.Write("Összeg (Ft): ");
                    try
                    {
                        osszeg = int.Parse(Console.ReadLine());
                        if (osszeg > 0)
                        {
                            break;
                        }
                        throw new Exception();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Ide pozitív szám kell");
                    }
                }

                DateTime hatarido;
                while (true)
                {
                    Console.Write("Határidő (ÉÉÉÉ-HH-NN): ");
                    try
                    {
                        hatarido = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Érvénytelen dátum!");
                    }
                }

                Console.Write("Befizetve (ÉÉÉÉ-HH-NN, Üres ha még nem): ");
                string inp = Console.ReadLine();
                DateTime befizetve;
                if (string.IsNullOrEmpty(inp)) // 1494. november 6
                {
                    befizetve = DateTime.ParseExact("1494-11-06", "yyyy-MM-dd", CultureInfo.InvariantCulture);
                }
                else
                {
                    while (true)
                    {
                        try
                        {
                            befizetve = DateTime.ParseExact(inp, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                            break;
                        }
                        catch (Exception)
                        {
                            Console.Write("Befizetve (ÉÉÉÉ-HH-NN, Üres ha még nem): ");
                            Console.WriteLine("Érvénytelen dátum!");
                        }
                    }
                }

                Console.Write("Megjegyzés: ");
                string megjegyzes = Console.ReadLine();

                Szamla szamla = new Szamla(idSzamla, szolgAzon, szolgRovid, tol, ig, osszeg, hatarido, befizetve, megjegyzes);
                return szamla;
            }

            Szolgaltatas SzolgaltatasBekeres()
            {
                int idSzolg = -1; // Amúgy se fogja használni

                Console.Write("Név: ");
                string nev = Console.ReadLine();

                Szolgaltatas szolgaltatas = new Szolgaltatas(idSzolg, nev);
                return szolgaltatas;
            }

            Szolgaltato SzolgaltatoBekeres()
            {
                Console.Write("Rövid Név: ");
                string rnev = Console.ReadLine();

                Console.Write("Név: ");
                string tnev = Console.ReadLine();

                Console.Write("Ügyfélszolgálat: ");
                string ugyf = Console.ReadLine();

                Szolgaltato szolgaltato = new Szolgaltato(rnev, tnev, ugyf);
                return szolgaltato;
            }
        }
    }
}
