using System;
using System.Collections.Generic;

namespace opdracht2
{
    class Program
    {
        static void Main(string[] args)
        {
            Initialiseer();
            Simuleer();
        }

        private static Dictionary<string, Double> _voertuigenlijst;
        private static Queue<string> _file;

        private static void Initialiseer()
        {
            _file = new Queue<string>();
            _voertuigenlijst = new Dictionary<string, Double>();
            _voertuigenlijst.Add("Bus", 12);
            _voertuigenlijst.Add("Auto", 4);
            _voertuigenlijst.Add("Fiets", 2);
            _voertuigenlijst.Add("Vrachtwagen", 16);
            _voertuigenlijst.Add("Motor", 2);
            _voertuigenlijst.Add("Tractor", 5);
        }

        private static void Simuleer()
        {
            Haalkeuze();
        }

        private static void Haalkeuze()
        {
            Console.WriteLine("Kies uit de volgende opties: 1: voertuig toevoegen, 2: voertuig verwijderen, 3: stoppen.");

            Console.Write("Voer hier iets in: ");
            int switchCase = Convert.ToInt32(Console.ReadLine());

            if (switchCase > 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Probeer een getal onder de 3 te kiezen");
                Console.ForegroundColor = ConsoleColor.White;
                Simuleer();
            }

            switch (switchCase)
            {
                case 1:
                    Console.WriteLine("U heeft gekozen voor voertuig toevoegen.");
                    Voegtoe();
                    break;
                case 2:
                    Console.WriteLine("U heeft gekozen voor voertuigen verwijderen");
                    Verwijder();
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("U heeft gekozen om te stoppen");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }

        private static void Voegtoe()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("U kunt kiezen uit: ");
            foreach (KeyValuePair<string, Double> voertuig in _voertuigenlijst)
            {
                Console.WriteLine(voertuig.Key);
            }

            Console.Write("Kies uit de volgende opties:");
            var voertuigen = Console.ReadLine();

            if (voertuigen.Length > 1) 
            {
                voertuigen = char.ToUpper(voertuigen[0]) + voertuigen.Substring(1); 
            }

            if (_voertuigenlijst.ContainsKey(voertuigen))
            {
                Console.WriteLine($"U heeft gekozen voor {voertuigen}");
                _file.Enqueue(voertuigen);
                PrintFileGegevens();
            } 
            else
            {
                Console.WriteLine("helaas staat het voertuig niet in het lijst.");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Probeer het opnieuw!");
                Console.ForegroundColor = ConsoleColor.White;
                Voegtoe();
            }

        }

        private static void Verwijder()
        {
            Double lengte = 0;
            foreach (var voertuig in _file)
            {
                Double newlengte;

                if (_voertuigenlijst.TryGetValue(voertuig, out newlengte))
                {
                    lengte += newlengte;
                }
            }

            if (lengte == 0)
            {
                Console.WriteLine(Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: U heeft nog geen voertuigen toegevoegd om te verwijderen");
                Console.ForegroundColor = ConsoleColor.White;
                Simuleer();
            } 
            else if (lengte > 0)
            {
                Console.WriteLine(Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Een {_file.Peek()} is verwijderd van de file");
                Console.ForegroundColor = ConsoleColor.White;
                _file.Dequeue();
                PrintFileGegevens();
                Simuleer();
            }
        }

        private static void PrintFileGegevens()
        {
            Console.WriteLine(Environment.NewLine);
            Double lengte = 0;

            Console.WriteLine($"In de file zitten de volgende voertuigen: ");
            foreach (var voertuig in _file) 
            {
                Double newlengte;

                if (_voertuigenlijst.TryGetValue(voertuig, out newlengte))
                {
                    lengte += newlengte;
                }

                Console.Write($"[{voertuig}], ");
            }

            Console.WriteLine("\t");
            Console.WriteLine($"De file is momenteel {lengte} meter lang");
            Console.WriteLine(Environment.NewLine);
            Simuleer();
        }

    }
}
