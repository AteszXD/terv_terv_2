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
            Console.WriteLine("3. Kilépés");

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
                    //List<Szolgaltato> szolgaltatok = new List<Szolgaltato>()
                    //{
                    //    new Szolgaltato()
                    //    {
                    //        RovidNev = "ABC",
                    //        Nev = "Helyi kis ABC",
                    //        Ugyfelszolgalat = "Miskolc, Búza tér 2/B"
                    //    },
                    //    new Szolgaltato()
                    //    {
                    //        RovidNev = "DEF",
                    //        Nev = "Nem Helyi nem kis DEF",
                    //        Ugyfelszolgalat = "Nem Miskolc, Fű körút 25/Y"
                    //    },
                    //    new Szolgaltato()
                    //    {
                    //        RovidNev = "GHI",
                    //        Nev = "Hallod én ehhez nem vagyok elég kreatív",
                    //        Ugyfelszolgalat = "Valami"
                    //    }
                    //};
                    //new SzolgaltatoView().ShowSzolgaltatoList(szolgaltatok);
                    List<Szolgaltato> szolgaltatodb = new SzolgaltatoController().GetSzolgaltatoList();
                    new SzolgaltatoView().ShowSzolgaltatoList(szolgaltatodb);
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
