using System;

namespace opdracht2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] nummers = new int[3,3];
            int counter = 0;

            for (int i = 0; i < nummers.GetLength(0); i++)
            {
                for (int j = 0; j < nummers.GetLength(1); j++)
                {
                    nummers[j, i] = (i * nummers.GetLength(0)) + (j + 1);
                    Console.Write("{0} ", nummers[ j, i ]);
                }
                Console.Write(Environment.NewLine);
            }
            
            for (int i = 0; i < nummers.GetLength(0); i++)
            {
                for (int j = 0; j < nummers.GetLength(1); j++)
                {
                    counter = counter + nummers[j, i];   
                }
            }
            Console.WriteLine("De som is " + counter);
        }
    }
}
