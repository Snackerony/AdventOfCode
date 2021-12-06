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
            List<Fields> fields = GenerateFields(input);
            List<string> winningBoard = new List<string>();
            for (int i = 5; i < winningNumbers.Count; i++)
            {
                bool willBreak = false;
                foreach (var item in fields)
                {
                    if (!item.didFinish && (CheckHorizintal(item.field, drawnNumbers) || CheckVertical(item.field, drawnNumbers))) {
                        if (fields.FindAll(m => m.didFinish == false).Count == 1)
                        {
                            Fields lastField = fields.Find(m => m.didFinish == false);
                            winningBoard = lastField.field;
                            willBreak = true;
                            break;
                        }
                        item.didFinish = true;
                    }
                }
                if (willBreak) break;
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

        private static List<Fields> GenerateFields(List<string> input)
        {
            int id = 1;
            List<Fields> vs = new List<Fields>();
            Fields field = new Fields();
            field.id = id;
            id++;
            List<string> fields = new List<string>();
            foreach (string line in input)
            {
                if (String.IsNullOrEmpty(line))
                {
                    field.field = fields;
                    field.didFinish = false;
                    vs.Add(field);
                    fields = new List<string>();
                    field = new Fields();
                    field.id = id;
                    id++;
                }
                else
                {
                    fields.Add(line);
                }
            }
            field.field = fields;
            field.didFinish = false;
            vs.Add(field);
            return vs;
        }
    }

    class Fields
    {
        public int id;
        public List<string> field;
        public bool didFinish;
    }
}
