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
            int addedNumber = 0;
            foreach (string line in input)
            {
                List<NumbersInChars> chars = new List<NumbersInChars>();
                List<string> parts = line.Split('|')[0].Split(' ').ToList();
                parts.Remove("");
                chars.Add(new NumbersInChars(1, parts.Find(i => i.Count() == 2).ToCharArray().ToList()));
                parts.Remove(parts.Find(i => i.Count() == 2));

                chars.Add(new NumbersInChars(4, parts.Find(i => i.Count() == 4).ToCharArray().ToList()));
                parts.Remove(parts.Find(i => i.Count() == 4));

                chars.Add(new NumbersInChars(7, parts.Find(i => i.Count() == 3).ToCharArray().ToList()));
                parts.Remove(parts.Find(i => i.Count() == 3));

                chars.Add(new NumbersInChars(8, parts.Find(i => i.Count() == 7).ToCharArray().ToList()));
                parts.Remove(parts.Find(i => i.Count() == 7));

                chars.Add(new NumbersInChars(9, parts.Find(i => i.Count() == 6 && CompareLists(i.ToCharArray().ToList(), chars.Find(m => m.value == 4).chars)).ToCharArray().ToList()));
                parts.Remove(parts.Find(i => i.Count() == 6 && CompareLists(i.ToCharArray().ToList(), chars.Find(m => m.value == 4).chars)));
                
                chars.Add(new NumbersInChars(0, parts.Find(i => i.Count() == 6 && CompareLists(i.ToCharArray().ToList(), chars.Find(m => m.value == 1).chars)).ToCharArray().ToList()));
                parts.Remove(parts.Find(i => i.Count() == 6 && CompareLists(i.ToCharArray().ToList(), chars.Find(m => m.value == 1).chars)));
                
                chars.Add(new NumbersInChars(6, parts.Find(i => i.Count() == 6).ToCharArray().ToList()));
                parts.Remove(parts.Find(i => i.Count() == 6));
                
                chars.Add(new NumbersInChars(3, parts.Find(i => i.Count() == 5 && CompareLists(i.ToCharArray().ToList(), chars.Find(m => m.value == 1).chars)).ToCharArray().ToList()));
                parts.Remove(parts.Find(i => i.Count() == 5 && CompareLists(i.ToCharArray().ToList(), chars.Find(m => m.value == 1).chars)));
               
                chars.Add(new NumbersInChars(5, parts.Find(i => i.Count() == 5 && CompareLists(chars.Find(m => m.value == 9).chars, i.ToCharArray().ToList())).ToCharArray().ToList()));
                parts.Remove(parts.Find(i => i.Count() == 5 && CompareLists(chars.Find(m => m.value == 9).chars, i.ToCharArray().ToList())));
                chars.Add(new NumbersInChars(2, parts.First().ToCharArray().ToList()));

                List<string> numbers = line.Split('|')[1].Split(' ').ToList();
                numbers.Remove("");
                string searchedNumber = "";
                foreach (string number in numbers)
                {
                    foreach (var item in chars)
                    {
                        if(item.chars.Count == number.Count() && CompareLists(item.chars, number.ToCharArray().ToList()))
                        {
                            searchedNumber += item.value.ToString();
                        }
                    }
                }
                addedNumber += int.Parse(searchedNumber);
                
            }
            Console.WriteLine($"{addedNumber}");
            Console.ReadLine();
        }

        static bool CompareLists(List<char> firstList, List<char> secondList)
        {
            return secondList.All(i => firstList.Contains(i));
        }
    }
    class NumbersInChars
    {
        public NumbersInChars(int value, List<char> chars)
        {
            this.value = value;
            this.chars = chars;
        }
        public int value;
        public List<char> chars;
    }
}
