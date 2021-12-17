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
            int days = 256;
            List<int> input = GetInput().First().Split(',').ToList().ConvertAll(int.Parse);
            List<FishCountSaver> saver = new List<FishCountSaver>();
            long fishCount = 0;
            foreach (var item in input)
            {
                if (saver.Find(m => m.startFishes == item && m.daysLeft == days) == null)
                {
                    long prod = ProducesFish(item, days, ref saver);
                    saver.Add(new FishCountSaver()
                    {
                        producedFishes = prod,
                        startFishes = item,
                        daysLeft = days
                    });
                }
                fishCount += saver.Find(m => m.startFishes == item && m.daysLeft == days).producedFishes;
            }
            Console.WriteLine(fishCount);
            Console.ReadLine();
        }

        static long ProducesFish(int lifeCycle, int daysLeft, ref List<FishCountSaver> saver)
        {
            long fishes = 1;
            while (daysLeft > 0)
            {
                if (lifeCycle == 0)
                {
                    lifeCycle = 6;
                    if (saver.Find(m => m.startFishes == 8 && m.daysLeft == (daysLeft - 1)) == null)
                    {
                        long prod = ProducesFish(8, (daysLeft - 1), ref saver);
                        saver.Add(new FishCountSaver()
                        {
                            producedFishes = prod,
                            startFishes = 8,
                            daysLeft = (daysLeft - 1)
                        });
                    }
                    fishes += saver.Find(m => m.startFishes == 8 && m.daysLeft == (daysLeft - 1)).producedFishes;
                }
                else
                {
                    lifeCycle--;
                }
                daysLeft--;
            }
            //Console.WriteLine(lifeCycle);
            return fishes;
        }
    }

    class FishCountSaver
    {
        public int startFishes;
        public long producedFishes;
        public int daysLeft;
    }
}
