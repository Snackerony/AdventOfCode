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
            List<int> winningNumbers = input[0].Split(',').ToList().ConvertAll(int.Parse);
            List<int> drawnNumbers = new List<int>();
            drawnNumbers.Add(winningNumbers[0]);
            drawnNumbers.Add(winningNumbers[1]);
            drawnNumbers.Add(winningNumbers[2]);
            drawnNumbers.Add(winningNumbers[3]);
            drawnNumbers.Add(winningNumbers[4]);
            input.RemoveAt(0);
            input.RemoveAt(0);
            List<List<string>> fields = GenerateFields(input);
            List<string> winningBoard = new List<string>();
            for (int i = 5; i < winningNumbers.Count; i++)
            {
                if(drawnNumbers.Last() == 53)
                {
                    Console.WriteLine("Here");
                }
                bool skip = false;
                foreach (var item in fields)
                {
                    if (CheckHorizintal(item, drawnNumbers) || CheckVertical(item, drawnNumbers)) {
                        winningBoard = item;
                        skip = true; 
                        break; 
                    }
                }
                if (skip) break;
                drawnNumbers.Add((int)winningNumbers[i]);
            }
            int count = CountFields(winningBoard, drawnNumbers); 
            Console.WriteLine($"Solution: {count * drawnNumbers.Last()}");
            Console.ReadKey();
        }

        private static int CountFields(List<string> fields, List<int> drawnNumbers)
        {
            int counter = 0;
            foreach (var item in fields)
            {
                var numbers = item.Split(' ').ToList().FindAll(i => !string.IsNullOrEmpty(i));
                foreach (var num in numbers)
                {
                    if (!drawnNumbers.Contains(int.Parse(num)))
                    {
                        counter += int.Parse(num);
                    }
                }
            }
            return counter;
        }

        private static bool CheckVertical(List<string> fields, List<int> drawnNumbers)
        {
            List<List<int>> fieldList = new List<List<int>>();
            foreach (var item in fields)
            {
                fieldList.Add(item.Split(' ').ToList().FindAll(i => !string.IsNullOrEmpty(i)).ConvertAll(int.Parse));
            }
            bool didFinish = true;
            for (int i = 0; i < fieldList[0].Count; i++) 
            {
                didFinish = true;
                foreach (var item in fieldList)
                {
                    if (!drawnNumbers.Contains(item[i]))
                    {
                        didFinish = false;
                    }
                }
                if (didFinish)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool CheckHorizintal(List<string> fields, List<int> drawnNumbers)
        {
            bool didFinish = true;
            foreach (var item in fields)
            {
                didFinish = true;
                var numbers = item.Split(' ').ToList().FindAll(i => !string.IsNullOrEmpty(i));
                foreach (var num in numbers)
                {
                    if (!drawnNumbers.Contains(int.Parse(num)))
                    {
                        didFinish = false;
                    }
                }
                if (didFinish)
                {
                    return true;
                }
            }
            return false;
        }

        private static List<List<string>> GenerateFields(List<string> input)
        {
            List<List<string>> vs = new List<List<string>>();
            List<string> fields = new List<string>();
            foreach (string line in input)
            {
                if (String.IsNullOrEmpty(line))
                {
                    vs.Add(fields);
                    fields = new List<string>();
                }
                else
                {
                    fields.Add(line);
                }
            }
            vs.Add(fields);
            return vs;
        }
    }
}
