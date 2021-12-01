using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCode
{
    internal class Program
    {
        private static List<string> GetInput()
        {
            return File.ReadAllLines("input.txt").ToList();
        }

        static void Main(string[] args)
        {
            var previousNumber = int.MaxValue;
            int counter = 0;
            string[] input = GetInput().ToArray();
            for (int i = 0; i < input.Length; i++)
            {
                if (i + 2 >= input.Length) break;
                var currentNumber = int.Parse(input[i]) + int.Parse(input[i + 1]) + int.Parse(input[i + 2]);
                if (currentNumber > previousNumber)
                {
                    counter++;
                }
                previousNumber = currentNumber;
            }
            Console.WriteLine(counter.ToString());
            Console.ReadKey();
        }
    }
}
