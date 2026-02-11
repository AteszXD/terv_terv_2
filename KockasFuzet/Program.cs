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
            //WriteCentered("------- Listázás -------");
            //WriteCentered("1. Szolgáltatók listáza");
            //WriteCentered("2. Szolgáltatások listázása");
            //WriteCentered("3. Számlák listázása");
            //WriteCentered("\n");
            //WriteCentered("------- Felvétel -------");
            //WriteCentered("4. Szolgáltató felvétele");
            //WriteCentered("5. Szolgáltatás felvétele");
            //WriteCentered("6. Számla felvétele");
            //WriteCentered("\n");
            //WriteCentered("------- Módosítás -------");
            //WriteCentered("7. Szolgáltató módosítása");
            //WriteCentered("8. Szolgáltatás módosítása");
            //WriteCentered("9. Számla módosítása");
            //WriteCentered("\n");
            //WriteCentered("------- Törlés -------");
            //WriteCentered("10. Szolgáltató törlése");
            //WriteCentered("11. Szolgáltatás törlése");
            //WriteCentered("12. Számla törlése");
            //WriteCentered("\n");
            //WriteCentered("------- Debug -------");
            //WriteCentered("996. Random szolgáltató kiírása");     // View teszt
            //WriteCentered("997. Random szolgáltatás kiírása");    // View teszt
            //WriteCentered("998. Random számla kiírása");          // View teszt
            //WriteCentered("999. Kilépés");                        // Kilépés...
            //WriteCentered("\n");

            //string valasz = Console.ReadLine();
            //WriteCentered("\n");

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
                            if (currentPoint > 0)
                            {
                                currentPoint -= 1;
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            {
                                if (currentPoint < 12)
                                {
                                    currentPoint += 1;
                                }
                            }
                            break;
                        //case ConsoleKey.RightArrow:
                        //    if (currentPoint < 12)
                        //    {
                        //        currentPoint += 1;
                        //    }
                        //    break;
                        //case ConsoleKey.LeftArrow:
                        //    if (currentPoint > 0)
                        //    {
                        //        currentPoint -= 1;
                        //    }
                        //    break;
                    }
                } while (!selected);
                switch (currentPoint)
                {
                    #region Listázás
                    case 0:
                        Console.Clear();
                        WriteCentered("--- SZOLGÁLTATÓK LISTÁZÁTA ---");
                        List<Szolgaltato> szolgaltatodb = new SzolgaltatoController().GetSzolgaltatoList();
                        new SzolgaltatoView().ShowSzolgaltatoList(szolgaltatodb);
                        WriteCentered("Enterrel tovább...");
                        Console.ReadLine();
                        break;

                    case 1:
                        Console.Clear();
                        WriteCentered("--- SZOLGÁLTATÁSOK LISTÁZÁTA ---");
                        List<Szolgaltatas> szolgaltatasdb = new SzolgaltatasController().GetSzolgaltatasList();
                        new SzolgaltatasView().ShowSzolgaltatasList(szolgaltatasdb);
                        WriteCentered("Enterrel tovább...");
                        Console.ReadLine();
                        break;

                    case 2:
                        Console.Clear();
                        WriteCentered("--- SZÁMLÁK LISTÁZÁTA ---");
                        List<Szamla> szamladb = new SzamlaController().GetSzamlaList();
                        new SzamlaView().ShowSzamlaList(szamladb);
                        WriteCentered("Enterrel tovább...");
                        Console.ReadLine();
                        break;
                    #endregion

                    #region Felvétel
                    case 3:
                        Console.Clear();
                        WriteCentered("--- SZOLGÁLTATÓ RÖGZÍTÉSE ---");
                        WriteCentered(new SzolgaltatoController().CreateSzolgaltato(SzolgaltatoBekeres()));
                        WriteCentered("Enterrel tovább...");
                        Console.ReadLine();
                        break;

                    case 4:
                        Console.Clear();
                        WriteCentered("--- SZOLGÁLTATÁS RÖGZÍTÉSE ---");
                        WriteCentered(new SzolgaltatasController().CreateSzolgaltatas(SzolgaltatasBekeres()));
                        WriteCentered("Enterrel tovább...");
                        Console.ReadLine();
                        break;

                    case 5:
                        Console.Clear();
                        WriteCentered("--- SZÁMLA RÖGZÍTÉSE ---");
                        WriteCentered(new SzamlaController().CreateSzamla(SzamlaBekeres()));
                        WriteCentered("Enterrel tovább...");
                        Console.ReadLine();
                        break;
                    #endregion

                    #region Módosítás
                    case 6:
                        Console.Clear();

                        WriteCentered("--- SZOLGÁLTATÓ MÓDOSÍTÁSA ---");
                        szolgaltatodb = new SzolgaltatoController().GetSzolgaltatoList();
                        WriteCentered("\n");
                        new SzolgaltatoView().ShowSzolgaltatoList(szolgaltatodb);

                        WriteCentered("\n");
                        WriteCentered(new SzolgaltatoController().UpdateSzolgaltato(SzolgaltatoBekeres()));
                        WriteCentered("Enterrel tovább...");
                        Console.ReadLine();
                        break;

                    case 7:
                        Console.Clear();
                        WriteCentered("--- SZOLGÁLTATÁS MÓDOSÍTÁSA ---");

                        szolgaltatasdb = new SzolgaltatasController().GetSzolgaltatasList();
                        WriteCentered("\n");
                        new SzolgaltatasView().ShowSzolgaltatasList(szolgaltatasdb);
                        WriteCentered("\n");

                        WriteCentered(new SzolgaltatasController().UpdateSzolgaltatas(SzolgaltatasBekeres()));
                        WriteCentered("Enterrel tovább...");
                        Console.ReadLine();
                        break;

                    case 8:
                        Console.Clear();
                        WriteCentered("--- SZÁMLA MÓDOSÍTÁSA ---");

                        szamladb = new SzamlaController().GetSzamlaList();
                        WriteCentered("\n");
                        new SzamlaView().ShowSzamlaList(szamladb);
                        WriteCentered("\n");

                        WriteCentered(new SzamlaController().UpdateSzamla(SzamlaBekeres()));
                        WriteCentered("Enterrel tovább...");
                        Console.ReadLine();
                        break;
                    #endregion

                    #region Törlés
                    case 9:
                        Console.Clear();
                        WriteCentered("--- SZOLGÁLTATÓ TÖRLÉSE ---");
                        WriteCentered(new SzolgaltatoController().DeleteSzolgaltato());
                        WriteCentered("Enterrel tovább...");
                        Console.ReadLine();
                        break;

                    case 10:
                        Console.Clear();
                        WriteCentered("--- SZOLGÁLTATÁS TÖRLÉSE ---");
                        WriteCentered(new SzolgaltatasController().DeleteSzolgaltatas());
                        WriteCentered("Enterrel tovább...");
                        Console.ReadLine();
                        break;

                    case 11:
                        Console.Clear();
                        WriteCentered("--- SZÁMLA TÖRLÉSE ---");
                        WriteCentered(new SzamlaController().DeleteSzamla());
                        WriteCentered("Enterrel tovább...");
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
                        WriteCentered("Enterrel tovább...");
                        Console.ReadLine();
                        break;

                    case 14:
                        List<Szolgaltatas> _szolgaltatasdb = new SzolgaltatasController().GetSzolgaltatasList();
                        random = new Random();
                        i = random.Next(_szolgaltatasdb.Count);
                        new SzolgaltatasView().ShowSzolgaltatas(_szolgaltatasdb[i]);
                        WriteCentered("Enterrel tovább...");
                        Console.ReadLine();
                        break;

                    case 15:
                        List<Szamla> _szamladb = new SzamlaController().GetSzamlaList();
                        random = new Random();
                        i = random.Next(_szamladb.Count);
                        new SzamlaView().ShowSzamla(_szamladb[i]);
                        WriteCentered("Enterrel tovább...");
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
                try
                {
                    szolgAzon = int.Parse(ReadCentered("Szolgáltatás azonosító: "));
                    if (szolgAzon > 0)
                    {
                        break;
                    }
                    throw new Exception();
                }
                catch (Exception)
                {
                    WriteCentered("Ide pozitív szám kell");
                }
            }

            string szolgRovid = ReadCentered("Szolgáltató rövid neve: ");

            DateTime tol;
            while (true)
            {
                try
                {
                    tol = DateTime.ParseExact(ReadCentered("Tol (ÉÉÉÉ-HH-NN): "), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    break;
                }
                catch (Exception)
                {
                    WriteCentered("Érvénytelen dátum!");
                }
            }

            DateTime ig;
            while (true)
            {
                try
                {
                    ig = DateTime.ParseExact(ReadCentered("Ig (ÉÉÉÉ-HH-NN): "), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    break;
                }
                catch (Exception)
                {
                    WriteCentered("Érvénytelen dátum!");
                }
            }

            int osszeg;
            while (true)
            {
                try
                {
                    osszeg = int.Parse(ReadCentered("Összeg (Ft): "));
                    if (osszeg > 0)
                    {
                        break;
                    }
                    throw new Exception();
                }
                catch (Exception)
                {
                    WriteCentered("Ide pozitív szám kell");
                }
            }

            DateTime hatarido;
            while (true)
            {
                try
                {
                    hatarido = DateTime.ParseExact(ReadCentered("Határidő (ÉÉÉÉ-HH-NN): "), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    break;
                }
                catch (Exception)
                {
                    WriteCentered("Érvénytelen dátum!");
                }
            }

            string inp = ReadCentered("Befizetve (ÉÉÉÉ-HH-NN, Üres ha még nem): ");
            DateTime befizetve;
            if (string.IsNullOrEmpty(inp))
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
                        WriteCentered("Érvénytelen dátum!");
                    }
                }
            }

            string megjegyzes = ReadCentered("Megjegyzés: ");

            Szamla szamla = new Szamla(idSzamla, szolgAzon, szolgRovid, tol, ig, osszeg, hatarido, befizetve, megjegyzes);
            return szamla;
        }

        static Szolgaltatas SzolgaltatasBekeres()
        {
            int idSzolg = -1; // Amúgy se fogja használni

            string nev = ReadCentered("Név: ");

            Szolgaltatas szolgaltatas = new Szolgaltatas(idSzolg, nev);
            return szolgaltatas;
        }

        static Szolgaltato SzolgaltatoBekeres()
        {
            
            string rnev = ReadCentered("Rövid Név: ");
            
            string tnev = ReadCentered("Név: ");
            
            string ugyf = ReadCentered("Ügyfélszolgálat: ");

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
            { "Kilépés", "", "" }};

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
                            WriteCentered($"> {menuPontok[i, j]}".PadRight(oszlopSzelesseg));
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            WriteCentered($"  {menuPontok[i, j]}".PadRight(oszlopSzelesseg));
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
        
        public static void WriteCentered(string text)
        {
            int width = Console.WindowWidth;
            int leftPadding = (width - text.Length) / 2;
            if (leftPadding < 0) leftPadding = 0;

            Console.WriteLine(new string(' ', leftPadding) + text);
        }

        public static string ReadCentered(string prompt)
        {
            int width = Console.WindowWidth;
            int leftPadding = ((width - prompt.Length) / 2) - 15; // A 15 egy általános érték (új sor miatt)
            if (leftPadding < 0) leftPadding = 0;

            Console.Write(new string(' ', leftPadding) + prompt);
            return Console.ReadLine();
        }
    }
}
