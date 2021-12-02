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
            int depth = 0;
            int forward = 0;
            foreach (var item in input)
            {
                string[] line = item.Split(' ');
                switch (line[0]) {
                    case "forward":
                        forward += int.Parse(line[1]);
                        break;
                    case "down":
                        depth += int.Parse(line[1]);
                        break;
                    case "up":
                        depth -= int.Parse(line[1]);
                        break;
                        default:
                        break;
                }
            }
            Console.WriteLine($"{depth * forward}");
            Console.ReadKey();  

        }
    }
}
