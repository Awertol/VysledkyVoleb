using System;
using System.Collections.Generic;
using System.Linq;

namespace VysledkyVoleb
{
    class Program
    {
        public static List<Strana> listStran = new List<Strana>();
        static void Main(string[] args)
        {
            bool zadavaniZapnuto = true;
            do
            {
                Strana strana = new Strana();
                Console.WriteLine("Zadej název strany: ");
                strana.Nazev = Console.ReadLine();
                strana.ZiskHlasu = 0;
                listStran.Add(strana);
                Console.WriteLine("Chceš zadat další stranu? y/n");
                string inputPokracovani = Console.ReadLine().ToLower();
                if(inputPokracovani == "n")
                {
                    zadavaniZapnuto = false;
                }
            }
            while (zadavaniZapnuto);
            bool generovaniZapnuto = false;
            do
            {
                VygenerujProcenta(listStran);
                foreach (Strana strana in listStran)
                {
                    Console.WriteLine($"Zisk strany {strana.Nazev} je {strana.ZiskHlasu} %");
                }
                Console.WriteLine("Chceš procenta generovat znovu? y/n");
                string inputPokracovani = Console.ReadLine().ToLower();
                if (inputPokracovani == "y")
                {
                    generovaniZapnuto = true;
                }
            }
            while (generovaniZapnuto);
            Console.ReadKey();
        }
        public static void VygenerujProcenta(List<Strana> stranas)
        {
            stranas = stranas.OrderBy(i => Guid.NewGuid()).ToList();
            int pocitadlo = 0;
            Random gnč = new Random();
            int pocetStran = stranas.Count;
            int celekHlasu = 100;
            foreach(Strana strana in stranas)
            {
                int vygenerovanyPocetHlasu = gnč.Next(0, celekHlasu);
                celekHlasu = celekHlasu - vygenerovanyPocetHlasu;
                strana.ZiskHlasu = vygenerovanyPocetHlasu;
                pocitadlo++;
                if(pocitadlo == pocetStran)
                {
                    strana.ZiskHlasu += celekHlasu;
                }
            }
        }
    }
    class Strana
    {
        public string Nazev
        {
            get;
            set;
        }
        public int ZiskHlasu
        {
            get;
            set;
        }
    }
}
