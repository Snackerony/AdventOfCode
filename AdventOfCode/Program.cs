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
            List<string> input = GetInput();
            List<int> lengths = new List<int>() { 2,3,4,7};
            int counter = 0;
            foreach (string line in input)
            {
                string[] parts = line.Split('|')[1].Split(' ');
                foreach (var item in parts)
                {
                    if(!String.IsNullOrEmpty(item) && lengths.Contains(item.Count())){
                        counter++;
                    }
                }
            }
            Console.WriteLine($"{counter}");
            Console.ReadLine();
        }
    }
}
