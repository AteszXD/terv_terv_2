using KockasFuzet.Controllers;
using KockasFuzet.Models;
using KockasFuzet.Views;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace KockasFuzet
{
    internal class Program
    {
        static void Main(string[] _)
        {
            #region Menüpontok RÉGI
            //Console.WriteLine("------- Listázás -------");
            //Console.WriteLine("1. Szolgáltatók listáza");
            //Console.WriteLine("2. Szolgáltatások listázása");
            //Console.WriteLine("3. Számlák listázása");
            //Console.WriteLine();
            //Console.WriteLine("------- Felvétel -------");
            //Console.WriteLine("4. Szolgáltató felvétele");
            //Console.WriteLine("5. Szolgáltatás felvétele");
            //Console.WriteLine("6. Számla felvétele");
            //Console.WriteLine();
            //Console.WriteLine("------- Módosítás -------");
            //Console.WriteLine("7. Szolgáltató módosítása");
            //Console.WriteLine("8. Szolgáltatás módosítása");
            //Console.WriteLine("9. Számla módosítása");
            //Console.WriteLine();
            //Console.WriteLine("------- Törlés -------");
            //Console.WriteLine("10. Szolgáltató törlése");
            //Console.WriteLine("11. Szolgáltatás törlése");
            //Console.WriteLine("12. Számla törlése");
            //Console.WriteLine();
            //Console.WriteLine("------- Debug -------");
            //Console.WriteLine("996. Random szolgáltató kiírása");     // View teszt
            //Console.WriteLine("997. Random szolgáltatás kiírása");    // View teszt
            //Console.WriteLine("998. Random számla kiírása");          // View teszt
            //Console.WriteLine("999. Kilépés");                        // Kilépés...
            //Console.WriteLine();

            //string valasz = Console.ReadLine();
            //Console.WriteLine();

            //switch (valasz)
            #endregion

            #region Switch-Case
            int currentPoint = 0;
            do
            {
                bool selected = false;
                do
                {
                    ShowMenu(currentPoint);
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Enter:
                            {
                                selected = true;
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            if (currentPoint > 2)
                            {
                                currentPoint -= 3;
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            {
                                if (currentPoint < 10)
                                {
                                    currentPoint += 3;
                                }
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (currentPoint < 12)
                            {
                                currentPoint += 1;
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (currentPoint > 0)
                            {
                                currentPoint -= 1;
                            }
                            break;
                    }
                } while (!selected);
                switch (currentPoint)
                {
                    #region Listázás
                    case 0:
                        Console.Clear();
                        Console.WriteLine("--- SZOLGÁLTATÓK LISTÁZÁTA ---");
                        List<Szolgaltato> szolgaltatodb = new SzolgaltatoController().GetSzolgaltatoList();
                        new SzolgaltatoView().ShowSzolgaltatoList(szolgaltatodb);
                        Console.WriteLine("Enterrel tovább...");
                        Console.ReadLine();
                        break;

                    case 1:
                        Console.Clear();
                        Console.WriteLine("--- SZOLGÁLTATÁSOK LISTÁZÁTA ---");
                        List<Szolgaltatas> szolgaltatasdb = new SzolgaltatasController().GetSzolgaltatasList();
                        new SzolgaltatasView().ShowSzolgaltatasList(szolgaltatasdb);
                        Console.WriteLine("Enterrel tovább...");
                        Console.ReadLine();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("--- SZÁMLÁK LISTÁZÁTA ---");
                        List<Szamla> szamladb = new SzamlaController().GetSzamlaList();
                        new SzamlaView().ShowSzamlaList(szamladb);
                        Console.WriteLine("Enterrel tovább...");
                        Console.ReadLine();
                        break;
                    #endregion

                    #region Felvétel
                    case 3:
                        Console.Clear();
                        Console.WriteLine("--- SZOLGÁLTATÓ RÖGZÍTÉSE ---");
                        Console.WriteLine(new SzolgaltatoController().CreateSzolgaltato(SzolgaltatoBekeres()));
                        Console.WriteLine("Enterrel tovább...");
                        Console.ReadLine();
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("--- SZOLGÁLTATÁS RÖGZÍTÉSE ---");
                        Console.WriteLine(new SzolgaltatasController().CreateSzolgaltatas(SzolgaltatasBekeres()));
                        Console.WriteLine("Enterrel tovább...");
                        Console.ReadLine();
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("--- SZÁMLA RÖGZÍTÉSE ---");
                        Console.WriteLine(new SzamlaController().CreateSzamla(SzamlaBekeres()));
                        Console.WriteLine("Enterrel tovább...");
                        Console.ReadLine();
                        break;
                    #endregion

                    #region Módosítás
                    case 6:
                        Console.Clear();

                        Console.WriteLine("--- SZOLGÁLTATÓ MÓDOSÍTÁSA ---");
                        szolgaltatodb = new SzolgaltatoController().GetSzolgaltatoList();
                        Console.WriteLine();
                        new SzolgaltatoView().ShowSzolgaltatoList(szolgaltatodb);

                        Console.WriteLine();
                        Console.WriteLine(new SzolgaltatoController().UpdateSzolgaltato(SzolgaltatoBekeres()));
                        Console.WriteLine("Enterrel tovább...");
                        Console.ReadLine();
                        break;

                    case 7:
                        Console.Clear();
                        Console.WriteLine("--- SZOLGÁLTATÁS MÓDOSÍTÁSA ---");

                        szolgaltatasdb = new SzolgaltatasController().GetSzolgaltatasList();
                        Console.WriteLine();
                        new SzolgaltatasView().ShowSzolgaltatasList(szolgaltatasdb);
                        Console.WriteLine();

                        Console.WriteLine(new SzolgaltatasController().UpdateSzolgaltatas(SzolgaltatasBekeres()));
                        Console.WriteLine("Enterrel tovább...");
                        Console.ReadLine();
                        break;

                    case 8:
                        Console.Clear();
                        Console.WriteLine("--- SZÁMLA MÓDOSÍTÁSA ---");

                        szamladb = new SzamlaController().GetSzamlaList();
                        Console.WriteLine();
                        new SzamlaView().ShowSzamlaList(szamladb);
                        Console.WriteLine();

                        Console.WriteLine(new SzamlaController().UpdateSzamla(SzamlaBekeres()));
                        Console.WriteLine("Enterrel tovább...");
                        Console.ReadLine();
                        break;
                    #endregion

                    #region Törlés
                    case 9:
                        Console.Clear();
                        Console.WriteLine("--- SZOLGÁLTATÓ TÖRLÉSE ---");
                        Console.WriteLine(new SzolgaltatoController().DeleteSzolgaltato());
                        Console.WriteLine("Enterrel tovább...");
                        Console.ReadLine();
                        break;

                    case 10:
                        Console.Clear();
                        Console.WriteLine("--- SZOLGÁLTATÁS TÖRLÉSE ---");
                        Console.WriteLine(new SzolgaltatasController().DeleteSzolgaltatas());
                        Console.WriteLine("Enterrel tovább...");
                        Console.ReadLine();
                        break;

                    case 11:
                        Console.Clear();
                        Console.WriteLine("--- SZÁMLA TÖRLÉSE ---");
                        Console.WriteLine(new SzamlaController().DeleteSzamla());
                        Console.WriteLine("Enterrel tovább...");
                        Console.ReadLine();
                        break;
                    #endregion

                    #region Kilépés
                    case 12:
                        Environment.Exit(0);
                        break;
                    #endregion

                    #region Debug
                    case 13:
                        List<Szolgaltato> _szolgaltatodb = new SzolgaltatoController().GetSzolgaltatoList();
                        Random random = new Random();
                        int i = random.Next(_szolgaltatodb.Count);
                        new SzolgaltatoView().ShowSzolgaltato(_szolgaltatodb[i]);
                        Console.WriteLine("Enterrel tovább...");
                        Console.ReadLine();
                        break;

                    case 14:
                        List<Szolgaltatas> _szolgaltatasdb = new SzolgaltatasController().GetSzolgaltatasList();
                        random = new Random();
                        i = random.Next(_szolgaltatasdb.Count);
                        new SzolgaltatasView().ShowSzolgaltatas(_szolgaltatasdb[i]);
                        Console.WriteLine("Enterrel tovább...");
                        Console.ReadLine();
                        break;

                    case 15:
                        List<Szamla> _szamladb = new SzamlaController().GetSzamlaList();
                        random = new Random();
                        i = random.Next(_szamladb.Count);
                        new SzamlaView().ShowSzamla(_szamladb[i]);
                        Console.WriteLine("Enterrel tovább...");
                        Console.ReadLine();
                        break;
                        #endregion
                }
            } while (currentPoint != 12);
            #endregion
        }

        static Szamla SzamlaBekeres()
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

        static Szolgaltatas SzolgaltatasBekeres()
        {
            int idSzolg = -1; // Amúgy se fogja használni

            Console.Write("Név: ");
            string nev = Console.ReadLine();

            Szolgaltatas szolgaltatas = new Szolgaltatas(idSzolg, nev);
            return szolgaltatas;
        }

        static Szolgaltato SzolgaltatoBekeres()
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

        static void ShowMenu(int cPoint)
        {
            string[,] menuPontok = {
        { "Szolgáltatók listázása", "Szolgáltatások listázása", "Számlák listázása" },
        { "Szolgáltatók rögzítése", "Szolgáltatások rögzítése", "Számlák rögzítése" },
        { "Szolgáltatók módosítása", "Szolgáltatások módosítása", "Számlák módosítása" },
        { "Szolgáltatók törlése",    "Szolgáltatások törlése",    "Számlák törlése" },
        { "Kilépés", "", "" }
    };

            Console.Clear();
            int elemSzam = 0;
            int oszlopSzelesseg = 30;

            for (int i = 0; i < menuPontok.GetLength(0); i++)
            {
                for (int j = 0; j < menuPontok.GetLength(1); j++)
                {
                    if (!string.IsNullOrEmpty(menuPontok[i, j])) 
                    {
                        if (elemSzam == cPoint)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"> {menuPontok[i, j]}".PadRight(oszlopSzelesseg));
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write($"  {menuPontok[i, j]}".PadRight(oszlopSzelesseg));
                        }
                    }

                    elemSzam++;
                }
                if (i < menuPontok.GetLength(0) - 1)
                {
                    Console.WriteLine();
                }
            }
            Console.ResetColor();
        }
    }
}
