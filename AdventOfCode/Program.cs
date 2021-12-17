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
            for (int i = 0; i < 80; i++)
            {
                int addCount = 0;
                for (int j = 0; j < input.Count; j++)
                {
                    if(input[j] == 0)
                    {
                        input[j] = 6;
                        addCount++;
                    }
                    else
                    {
                        input[j]--;
                    }
                }
                for (int k = 0; k < addCount; k++)
                {
                    input.Add(8);
                }                
            }
            Console.WriteLine(input.Count);
            Console.ReadLine();
        }       
    }
}
