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
            List<string> inputCopy = new List<string>();
            foreach (var item in input)
            {
                inputCopy.Add(item);
            }
            FindGamma(length, ref gamma, inputCopy);
            FindEpsilon(length, ref epsilon, inputCopy);
            int solution = Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2);
            Console.WriteLine(solution);
            Console.ReadKey();

        }

        private static void FindGamma(int length, ref string gamma, List<string> inputCopy)
        {
            for (int i = 0; i < length; i++)
            {
                int zeroCount = 0;
                int oneCount = 0;
                foreach (var item in inputCopy)
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
                if (zeroCount > oneCount)
                {
                    inputCopy = inputCopy.FindAll(item => item.ToCharArray()[i] == ('0'));
                }
                else
                {
                    inputCopy = inputCopy.FindAll(item => item.ToCharArray()[i] == ('1'));
                }
                if (inputCopy.Count == 1)
                {
                    gamma = inputCopy[0];
                    break;
                }
            }
        }

        private static void FindEpsilon(int length, ref string epsilon, List<string> inputCopy)
        {
            for (int i = 0; i < length; i++)
            {
                int zeroCount = 0;
                int oneCount = 0;
                foreach (var item in inputCopy)
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
                if (zeroCount > oneCount)
                {
                    inputCopy = inputCopy.FindAll(item => item.ToCharArray()[i] == ('1'));
                }
                else
                {
                    inputCopy = inputCopy.FindAll(item => item.ToCharArray()[i] == ('0'));
                }
                if (inputCopy.Count == 1)
                {
                    epsilon = inputCopy[0];
                    break;
                }
            }
        }
    }
}
