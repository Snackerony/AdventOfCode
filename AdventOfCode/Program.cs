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
            List<string> input = GetInput();
            foreach (var item in input)
            {
                var currentNumber = int.Parse(item);
                if(currentNumber > previousNumber)
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
