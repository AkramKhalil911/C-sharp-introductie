using System;
using Personen;
using System.Collections.Generic;
using static System.Console;

namespace opdracht_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Invullen();
            PersonenWeergeven();
        }

        private static List<Persoon> _Personen = new List<Persoon>();

        private static void Invullen()
        {
            _Personen.Add(new Persoon("Akram", "Khalil", 17, new DateTime(2003, 5, 4), "man", 174, 81));
            _Personen.Add(new Medewerker("Akram", "Khalil", 17, new DateTime(2003, 5, 4), "man", 174, 90, "werknemer", "Lidl"));
            _Personen.Add(new Medewerker("Willem", "Houte", 18, new DateTime(2003, 1, 9), "man", 210, 81, "directeur", "Nike"));
            _Personen.Add(new Medewerker("Piet", "Laan", 50, new DateTime(1981, 4, 1), "man", 164, 90, "werknemer", "Google Cloud"));
            _Personen.Add(new Medewerker("Sem", "Pong", 22, new DateTime(1999, 4, 1), "man", 204, 110, "directeur", "Stock market"));
        }

        private static void PersonenWeergeven()
        {
            foreach ( var i in _Personen)
            {
                Console.WriteLine(i.WieBenIk());    
                Console.Write(Environment.NewLine);
            }
        }
    }
}
