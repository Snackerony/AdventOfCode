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
            List<int> input = GetInput().First().Split(',').ToList().ConvertAll(int.Parse);
            List<CrabCounter> counter = new List<CrabCounter>();
            input.Sort();
            for (int i = input.First(); i <= input.Last(); i++)
            {
                int singleCounter = 0;
                foreach (var item in input)
                {
                    int maxMove = Math.Max(i, item) - Math.Min(i, item);
                    for (int j = 1; j <= maxMove; j++)
                    {
                        singleCounter += j;
                    }
                }
                counter.Add(new CrabCounter(singleCounter, i));
            }
            counter.Sort((i,j) => i.fuel.CompareTo(j.fuel));
            Console.WriteLine($"{counter.First().position} {counter.First().fuel}");
            Console.ReadLine();
        }
    }
    class CrabCounter
    {
        public CrabCounter(int fuel, int position)
        {
            this.fuel = fuel;
            this.position = position;
        }
        public int fuel;
        public int position;
    }
}
