using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personen
{
    public class Medewerker : Persoon
    {
        public Medewerker(string voornaam, string achternaam, int leeftijd, DateTime DT, string geslacht, int lengte, Double gewicht, string rol, string bijzaken)
            : base(voornaam, achternaam, leeftijd, DT, geslacht, lengte, gewicht)
        {
            Rol = rol;
            Bijzaken = bijzaken;
        }

        public string Rol { get; set; }
        public string Bijzaken { get; set; }

        public override string WieBenIk()
        {
            var wieBenIk = base.WieBenIk();
            return $"{wieBenIk} en mijn rol is {Rol} en ik werk bij {Bijzaken}";
        }
    }
}
