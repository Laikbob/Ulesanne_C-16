using System;
using System.Collections.Generic;
using System.Linq;

namespace ÜlesandedApp
{
    public class Inimene
    {
        public string Nimi { get; set; }
        public int Vanus { get; set; }
    }

    public static class Ülesanded
    {
        // 1. Juhuslike arvude ruudud
        public static int[] GenereeriRuudud(int min, int max)
        {
            Random rnd = new Random();
            int n = rnd.Next(min, max + 1);
            int m = rnd.Next(min, max + 1);
            Console.WriteLine($"Genereeritud arvud: {n}, {m}");

            int start = Math.Min(n, m);
            int end = Math.Max(n, m);

            int[] ruudud = new int[end - start + 1];

            for (int i = 0; i < ruudud.Length; i++)
            {
                int arv = start + i;
                ruudud[i] = arv * arv;
                Console.WriteLine($"{arv} → {ruudud[i]}");
            }

            return ruudud;
        }

        // 2. Viie arvu analüüs
        public static (double summa, double keskmine, double korrutis) AnalüüsiArve(double[] arvud)
        {
            double summa = arvud.Sum();
            double korrutis = 1;
            foreach (double arv in arvud) korrutis *= arv;
            double keskmine = summa / arvud.Length;

            Console.WriteLine($"Summa: {summa}, Keskmine: {keskmine:F2}, Korrutis: {korrutis}");
            return (summa, keskmine, korrutis);
        }

        public static double[] Tekstist_arvud()
        {
            double[] arvud = new double[5];
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Sisesta arv {i + 1}: ");
                arvud[i] = double.Parse(Console.ReadLine());
            }
            return arvud;
        }

        // 3. Nimed ja vanused
        public static (int summa, double keskmine, Inimene vanim, Inimene noorim) Statistika(List<Inimene> inimesed)
        {
            int summa = inimesed.Sum(i => i.Vanus);
            double keskmine = inimesed.Average(i => i.Vanus);
            Inimene vanim = inimesed.OrderByDescending(i => i.Vanus).First();
            Inimene noorim = inimesed.OrderBy(i => i.Vanus).First();

            Console.WriteLine($"Kokku vanust: {summa}, Keskmine: {keskmine:F2}");
            Console.WriteLine($"Vanim: {vanim.Nimi} ({vanim.Vanus}), Noorim: {noorim.Nimi} ({noorim.Vanus})");
            return (summa, keskmine, vanim, noorim);
        }

        // 4. "Osta elevant ära!"
        public static void KuniMärksõnani(string märksõna, string fraas)
        {
            List<string> sisestused = new List<string>();
            string sisend;
            do
            {
                Console.WriteLine(fraas);
                sisend = Console.ReadLine();
                sisestused.Add(sisend);
            } while (sisend != märksõna);

            Console.WriteLine("Kõik sisestused:");
            foreach (var s in sisestused)
            {
                Console.WriteLine(s);
            }
        }

        // 5. Arvamise mäng
        public static void ArvaArv()
        {
            Random rnd = new Random();
            bool uuesti;

            do
            {
                int arv = rnd.Next(1, 101);
                bool võit = false;

                for (int i = 1; i <= 5; i++)
                {
                    Console.Write($"Katse {i}/5: ");
                    int pakkumine = int.Parse(Console.ReadLine());

                    if (pakkumine == arv)
                    {
                        Console.WriteLine("Õige! 🎉");
                        võit = true;
                        break;
                    }
                    else if (pakkumine < arv)
                        Console.WriteLine("Liiga väike!");
                    else
                        Console.WriteLine("Liiga suur!");
                }

                if (!võit)
                    Console.WriteLine($"Vale! Õige arv oli {arv}");

                Console.Write("Mängime uuesti? (jah/ei): ");
                uuesti = Console.ReadLine().ToLower() == "jah";

            } while (uuesti);
        }
    }
}
