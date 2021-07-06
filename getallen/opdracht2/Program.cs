using System;

namespace opdracht2
{
    class Program
    {
        static void Main(string[] args)
        {
            Leesgehalte();
        }

        private static void Leesgehalte()
        {
            bool Geheelgetal = false;
            int getal = default;
            do
            {
                Console.Write("voer een getal onder de 4 in: ");
                var uitslag = Console.ReadLine();
                try
                {
                    getal = int.Parse(uitslag);
                    Geheelgetal = true;
                }
                catch
                {
                    Console.Write($"Er is iets misgegaan probeer het aub opnieuw");
                    Console.Write(Environment.NewLine);
                }
            } while (!Geheelgetal);
           GeefKaart(getal);
        }

        private static void GeefKaart(int getal)
        {
            if (getal == 1)
            {
                Console.Write($"U heeft {getal} gekozen. Dat is ruiten");
            }
            if (getal == 2)
            {
                Console.Write($"U heeft {getal} gekozen. Dat is harten");
            }
            if (getal == 3)
            {
                Console.Write($"U heeft {getal} gekozen. Dat is klaveren");
            }
            if (getal == 4)
            {
                Console.Write($"U heeft {getal} gekozen. Dat is schoppen");
            }
            if (getal > 4)
            {
                Console.Write($"Voer een getal onder de 4 in!");
            }
        }
    }
}
