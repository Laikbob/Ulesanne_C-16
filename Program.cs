using System;
using System.Collections.Generic;

namespace ÜlesandedApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Juhuslike arvude ruudud
            Console.WriteLine("=== 1. Juhuslikud arvud ja ruudud ===");
            Ülesanded.GenereeriRuudud(-100, 100);

            // 2. Viie arvu analüüs
            Console.WriteLine("\n=== 2. Viie arvu analüüs ===");
            double[] arvud = Ülesanded.Tekstist_arvud();
            Ülesanded.AnalüüsiArve(arvud);

            // 3. Nimed ja vanused
            Console.WriteLine("\n=== 3. Nimed ja vanused ===");
            List<Inimene> inimesed = new List<Inimene>();
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Sisesta nimi {i + 1}: ");
                string nimi = Console.ReadLine();
                Console.Write($"Sisesta vanus {i + 1}: ");
                int vanus = int.Parse(Console.ReadLine());
                inimesed.Add(new Inimene { Nimi = nimi, Vanus = vanus });
            }
            Ülesanded.Statistika(inimesed);

            // 4. "Osta elevant ära!"
            Console.WriteLine("\n=== 4. Osta elevant ära! ===");
            Ülesanded.KuniMärksõnani("osta", "Osta elevant ära!");

            // 5. Arvamise mäng
            Console.WriteLine("\n=== 5. Arvamise mäng ===");
            Ülesanded.ArvaArv();
        }
    }
}
