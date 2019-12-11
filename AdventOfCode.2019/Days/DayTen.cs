namespace AdventOfCode._2019.Days
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode.Shared;
    class DayTen : Day
    {
        public DayTen() : base(10) { }

        public override void TheNeedful()
        {

            Input = @".#..#
.....
#####
....#
...##";
            var grid = new Grid();
            grid.Populate(Input);

            grid.DisplayMap();
        }

        public class Grid 
        {
            public int Height => Points.Max(p => p.Y) + 1;
            public int Width => Points.Max(p => p.X) + 1;
            public List<Point> Points { get; set; } = new List<Point>();

            public void Populate(string map)
            {
                var rows = map.Split("\r\n");
                for( int y = 0; y < rows.Count(); y++)
                {
                    int x = 0;
                    foreach(var loc in rows[y])
                    {
                        Points.Add( new Point{ X = x, Y = y, HasAsteroid = loc == '#', CanSee = 0 });
                        x++;
                    }
                }

                foreach(var point in Points.Where(p => p.HasAsteroid))
                {
                    FindVisible(point);
                }
            }

            public void DisplayMap()
            {
                for(int y = 0; y < Height; y++)
                {
                    for(int x = 0; x < Width; x++)
                    {
                        Console.Write(Points
                                        .Where(p => x == p.X && y == p.Y)
                                        .Select(p => p.HasAsteroid ? p.CanSee.ToString() : ".").First());
                    }
                    Console.Write("\n");
                }
                    
            }

            public void FindVisible(Point point)
            {
                var otherPoints = Points.Where(p => p.X != point.X || p.Y != point.Y);
                foreach(var otherPoint in otherPoints)
                {
                    var xOffset = otherPoint.X - point.X;
                    var yOffset = otherPoint.Y - point.Y;
                }
            }

            public List<int> GetCommonFactors(int x, int y)
            {
                var factors = new List<int>();
                )

                return factors;
            }
        }
        public class Point{
            public int X { get; set; }
            public int Y { get; set; }
            public bool HasAsteroid { get; set; }
            public int CanSee { get; set; }
        }
    }
}