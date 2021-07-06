using System;
using System.Collections.Generic;

namespace opdracht1
{
    class Program
    {
        static void Main(string[] args)
        {
            var stapel = new Stack<string>();
            VulStack(stapel, 5);
        }

        private static void VulStack(Stack<string> stapel, int aantal)
        {
            for (int i = 0; i < aantal; i++)
            {
                Console.Write($"Geef waarde nummer {i + 1}: ");
                var input = Console.ReadLine();
                stapel.Push(input);
            }

            PrintStack(stapel);
        }

        private static void PrintStack(Stack<string> stapel)
        {
            string[] woorden = {""};

            foreach ( var number in woorden)
            {
                string text = string.Join("\t", stapel);
                Console.WriteLine(text);
            }

            foreach (var number in woorden)
            {
                Console.Write($"Pak een waarde: ");
                var input2 = Console.ReadLine();
                var boven = stapel.Peek();

                if (input2 == boven)
                {
                    Console.WriteLine($"{boven} is de bovenste waarden");
                    Console.WriteLine($"De waarde {stapel.Pop()} is weggehaald");
                }
                else if (stapel.Contains(input2))
                {
                    Console.WriteLine($"{input2} zit in de lijst");
                }
                else
                {
                    Console.WriteLine($"{input2} is geen waarde");
                }
            }

            foreach (var number in woorden)
            {
                string text = string.Join("\t", stapel);
                Console.WriteLine(text);
            }
        }
    }
}
