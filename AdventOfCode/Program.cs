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
            int length = input[0].ToCharArray().Length;
            string gamma = "";
            string epsilon = "";
            for (int i = 0; i < length; i++)
            {
                int zeroCount = 0;
                int oneCount = 0;
                foreach (var item in input)
                {
                    if (item.ToCharArray()[i] == '0')
                    {
                        zeroCount++;
                    }
                    else 
                    { 
                        oneCount++; 
                    }
                }
                if(zeroCount > oneCount)
                {
                    gamma += "0";
                    epsilon += "1";
                }
                else
                {
                    gamma += "1";
                    epsilon += "0";
                }
            }
            int solution = Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2);
            Console.WriteLine(solution);
            Console.ReadKey();  

        }
    }
}
