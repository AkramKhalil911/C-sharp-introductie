using System;

namespace Personen
{
    public class Persoon
    {
        public Persoon(string voornaam, string achternaam, int leeftijd, DateTime DT, string geslacht, int lengte, Double gewicht)
        {
            Voornaam = voornaam;
            Achternaam = achternaam;
            Leeftijd = leeftijd;
            Geboortedatum = DT;
            Geslacht = geslacht;
            Lengte = lengte;
            Gewicht = gewicht;
        }

        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public int Leeftijd { get; set; }
        public DateTime Geboortedatum { get; private set; }
        public string Geslacht { get; set; }

        private int _lengte = 20;
        public int Lengte
        {
            get
            {
                return _lengte;
            }
            set
            {
                if (value > 20)
                {
                    _lengte = value;
                }
            }
        }

        private Double _gewicht = 1.5;
        public Double Gewicht
        {
            get
            {
                return _gewicht;
            }
            set
            {
                if (value >= 1.5 && value <= 321.6)
                {
                    _gewicht = value;
                }
            }
        }
        public virtual string WieBenIk()
        {
            return $"Mijn naam is {Voornaam} {Achternaam} en ik ben {Leeftijd} jaar oud {Geboortedatum}. Ik ben een {Geslacht} en ben {Lengte}cm lang" +
                $" en weeg {Gewicht}kg";
        }
    }
}
