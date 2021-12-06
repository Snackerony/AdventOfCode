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
            List<FromTo> fromTos = GetPoints(input);
            List<PointCount> pointCounts = DrawLines(fromTos);
            Console.WriteLine(pointCounts.FindAll(m => m.count > 1).Count);
            Console.ReadKey();
        }

        private static List<PointCount> DrawLines(List<FromTo> fromTos)
        {
            List<PointCount> points = new List<PointCount>();
            foreach (var item in fromTos)
            {
                if(item.fromPoint.x == item.toPoint.x)
                {
                    for (int i = Math.Min(item.fromPoint.y, item.toPoint.y); i <= Math.Max(item.fromPoint.y, item.toPoint.y); i++)
                    {
                        PointCount foundPoint = points.Find(m => m.point.x == item.fromPoint.x && m.point.y == i);
                        if(foundPoint == null)
                        {
                            PointCount pointCount = new PointCount();
                            Point point = new Point();
                            point.x = item.fromPoint.x;
                            point.y = i;
                            pointCount.point = point;
                            pointCount.count = 1;
                            points.Add(pointCount);
                        }
                        else
                        {
                            foundPoint.count++;
                        }
                    }
                }
                else if (item.fromPoint.y == item.toPoint.y)
                {

                    for (int i = Math.Min(item.fromPoint.x, item.toPoint.x); i <= Math.Max(item.fromPoint.x, item.toPoint.x); i++)
                    {
                        PointCount foundPoint = points.Find(m => m.point.y == item.fromPoint.y && m.point.x == i);
                        if (foundPoint == null)
                        {
                            PointCount pointCount = new PointCount();
                            Point point = new Point();
                            point.y = item.fromPoint.y;
                            point.x = i;
                            pointCount.point = point;
                            pointCount.count = 1;
                            points.Add(pointCount);
                        }
                        else
                        {
                            foundPoint.count++;
                        }
                    }
                }
                else
                {
                    Point currentPoint = new Point();
                    currentPoint.x = item.fromPoint.x;
                    currentPoint.y = item.fromPoint.y;
                    while (true)
                    {
                        PointCount foundPoint = points.Find(m => m.point.y == currentPoint.y && m.point.x == currentPoint.x);
                        if (foundPoint == null)
                        {
                            PointCount pointCount = new PointCount();
                            Point point = new Point();
                            point.y = currentPoint.y;
                            point.x = currentPoint.x;
                            pointCount.point = point;
                            pointCount.count = 1;
                            points.Add(pointCount);
                        }
                        else
                        {
                            foundPoint.count++;
                        }
                        if (currentPoint.x == item.toPoint.x && currentPoint.y == item.toPoint.y) break;
                        if (currentPoint.y != item.toPoint.y)
                        {
                            if (currentPoint.y < item.toPoint.y)
                                currentPoint.y++;
                            else
                                currentPoint.y--;
                        }
                        if (currentPoint.x != item.toPoint.x)
                        {
                            if (currentPoint.x < item.toPoint.x)
                                currentPoint.x++;
                            else
                                currentPoint.x--;
                        }                        
                    }
                }
            }
            return points;
        }

        private static List<FromTo> GetPoints(List<string> input)
        {
            List<FromTo> points = new List<FromTo>();
            foreach (var item in input)
            {
                string[] split = item.Replace(" ->", "").Split(' ');
                Point fromPoint = new Point()
                {
                    x = int.Parse(split[0].Split(',')[0]),
                    y = int.Parse(split[0].Split(',')[1])
                };
                Point toPoint = new Point()
                {
                    x = int.Parse(split[1].Split(',')[0]),
                    y = int.Parse(split[1].Split(',')[1])
                };
                FromTo point = new FromTo();
                point.fromPoint = fromPoint;
                point.toPoint = toPoint;
                points.Add(point);
            }
            return points;
        }
    }

    class Point
    {
        public int x;
        public int y;
    }

    class FromTo
    {
        public Point fromPoint;
        public Point toPoint;
    }

    class PointCount {
        public Point point;
        public int count;
    }
}
