namespace AdventOfCode._2019.Days
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using AdventOfCode.Shared;
    class DayTen : Day
    {
        public DayTen() : base(10) { }

        public bool UseFramebuffer = false;
        public override void TheNeedful()
        {

            // Input =   ".#..#\n"
            //         + ".....\n"
            //         + "#####\n"
            //         + "....#\n"
            //         + "...##";
            var grid = new Grid();
            grid.Populate(Input);

            PartOne = grid.MaxSeen.ToString();

            PartTwo = grid.NukeVisible(200);


        }

        public class Grid 
        {
            public decimal Height => Points.Max(p => p.Y) + 1;
            public decimal Width => Points.Max(p => p.X) + 1;
            public List<Point> Points { get; set; } = new List<Point>();

            public int MaxSeen => Points.Select(p => p.CanSee).Max();

            public void Populate(string map)
            {
                var rows = map.Split("\n");
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

                var maxPoint = Points.FirstOrDefault(p => p.CanSee == MaxSeen);
                maxPoint.HasLaser = true;
            }

            public void DisplayMap()
            {
                if(UseFramebuffer)
                {
                    for(int y = 0; y < Height; y++)
                    {
                        for(int x = 0; x < Width; x++)
                        {
                            try
                            {
                                Console.SetCursorPosition(x + 90, y);
                                Console.Write(Points
                                                .Where(p => x == p.X && y == p.Y)
                                                .Select(p => p.HasAsteroid ? p.HasLaser ? "L" : "#" : " ").First());
                            }
                            catch{return;}
                        }   
                    }
                }
            }

            public string NukeVisible(int count = 1)
            {
                var laser = Points.First(p => p.HasLaser);
                int nukeCount = 0;
                DisplayMap();
                while(true)
                {
                    var points = Points.Where(p => p.HasAsteroid && !p.HasLaser);
                    var asteroids = points
                        .GroupBy(p => new {
                            slope = p.X - laser.X == 0 ? 99 : (p.Y - laser.Y) / (p.X - laser.X),
                            XPos = p.X >= laser.X,
                            YPos = p.Y >= laser.Y})
                        .OrderByDescending(g => g.Key.XPos)
                        .ThenBy(g => g.Key.slope)
                        .ToList();
                    foreach(var asteroid in asteroids)
                    {
                        var target = asteroid.OrderBy(a => Math.Abs(a.X - laser.X))
                            .ThenBy(a => Math.Abs(a.Y - laser.Y))
                            .First();
                        target.HasAsteroid = false;
                        if(UseFramebuffer)
                        {
                            try{
                                Console.SetCursorPosition((int)target.X + 90, (int)target.Y);
                                Console.Write(" ");
                                Thread.Sleep(50);
                            } 
                            catch{}
                        }
                        nukeCount++;
                        if(nukeCount == count)
                        {
                            return $"{target.X * 100 + target.Y}";
                        }
                            
                            
                    }
                }
            }

            public void FindVisible(Point point)
            {
                var otherPoints = Points.Where(p => (p.X != point.X || p.Y != point.Y) && p.HasAsteroid);

                var asteroids = otherPoints
                        .GroupBy(p => new {
                            slope = p.Y - point.Y == 0 ? 99 : (p.X - point.X) / (p.Y - point.Y),
                            XPos = p.X > point.X,
                            YPos = p.Y > point.Y})
                        .ToList();

                point.CanSee = asteroids.Count;

                foreach(var otherPoint in otherPoints)
                {
                    var xOffset = otherPoint.X - point.X;
                    var yOffset = otherPoint.Y - point.Y;                    
                }
            }

            public class Point
            {
                public decimal X { get; set; }
                public decimal Y { get; set; }
                public bool HasAsteroid { get; set; }
                public int CanSee { get; set; }
                public bool HasLaser {get; set; }
            }
        }
    }
}