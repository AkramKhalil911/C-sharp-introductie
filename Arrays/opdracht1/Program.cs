using System;

namespace opdracht1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] woorden = {"Peter", "is", "de", "broer", "van", "Hans"};
            string[] niks = {""};

            foreach (string woord in niks)
            {
                string change1 = string.Join(" ", woorden);
                Console.WriteLine(change1);

                string namechange;
                namechange = woorden[0];
                woorden[0] = woorden[5];
                woorden[5] = namechange;

                string change2 = string.Join(" ", woorden);
                Console.WriteLine(change2);
            }
        }
    }
}
