using System;

namespace opdracht1
{
    class Program
    {
        static void Main(string[] args)
        {
            Leesgeheelgetal();
        }
        private static void Leesgeheelgetal()
        {
            bool isGeheelGetal = false;
            int getal1 = default;
            int getal2 = default;
            do
            {
                Console.Write("Voer het 1e getal in: ");
                var test1 = Console.ReadLine();
                Console.Write("Voer het 2e getal in: ");
                var test2 = Console.ReadLine();
                try
                {
                    Console.Write("De som is: ");
                    getal1 = int.Parse(test1);
                    isGeheelGetal = true;
                    getal2 = int.Parse(test2);
                    isGeheelGetal = true;
                }
                catch
                {
                    Console.Write($"{getal1} is niet een nummer");
                    Console.Write($"{getal2} is niet een nummer");
                }
            } while (!isGeheelGetal);
            Som(getal1, getal2);
            Verschil(getal1, getal2);
            Product(getal1, getal2);
        }
        
        private static void Som(int getal1, int getal2)
        {
            int som = getal1 + getal2;
            Console.WriteLine($"De som van {getal1} + {getal2} = {som}");
        }

        private static void Verschil(int getal1, int getal2)
        {
            int som = getal1 - getal2;
            Console.WriteLine($"De som van {getal1} - {getal2} = {som}");
        }
        private static void Product(int getal1, int getal2)
        {
            int som = getal1 * getal2;
            Console.WriteLine($"De som van {getal1} x {getal2} = {som}");
        }
    }
}
