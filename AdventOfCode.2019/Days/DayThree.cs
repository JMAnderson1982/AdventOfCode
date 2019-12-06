namespace AdventOfCode._2019.Days
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode.Shared;

    class DayThree : Day
    {
        public DayThree() :base(3) {}
        public override void TheNeedful()
        {
            var wires = Input.Split("\n");

            var redLines = MakeList(wires[0]);
            var blueLines = MakeList(wires[1]);

            var intersections = new List<Location>();

            foreach( var red in redLines.Where(r => r.X1 == r.X2))
            {
                foreach (var blue in blueLines.Where(b => b.Y1 == b.Y2))
                {
                    if(    ( ( red.Y1 <= blue.Y1 && red.Y2 >= blue.Y1) || (red.Y1 >= blue.Y1 && red.Y2 <= blue.Y1) )
                        && ( ( blue.X1 <= red.X1 && blue.X2 >= red.X1) || (blue.X1 >= red.X1 && blue.X2 <= red.X1) )
                    )
                    {
                        var i = new Location{ 
                            X = red.X1, 
                            Y = blue.Y1, 
                            Distance = red.Distance + Math.Abs(red.Y1 - blue.Y1) + blue.Distance + Math.Abs(red.X1 - blue.X1) 
                        };
                        intersections.Add( i );
                    }
                }
            }

            foreach( var red in redLines.Where(r => r.Y1 == r.Y2))
            {
                foreach (var blue in blueLines.Where(b => b.X1 == b.X2))
                {
                    if(    ( ( red.X1 <= blue.X1 && red.X1 >= blue.X2) || (red.X1 >= blue.X1 && red.X1 <= blue.X2 ) )
                        && ( ( blue.Y1 <= red.Y1 && blue.Y2 >= red.Y1) || (blue.Y1 >= red.Y1 && blue.Y2 <= red.Y1 ) )
                    )
                    {
                        intersections.Add( new Location{ 
                            X = blue.X1, 
                            Y = red.Y1,
                            Distance = red.Distance + Math.Abs(red.X1 - blue.X1) + blue.Distance + Math.Abs(red.Y1 - blue.Y1)
                             } );
                    }
                }
            }

            var nearest = intersections.Select(i => Math.Abs(i.X) + Math.Abs(i.Y) ).Min();
            var shortest = intersections.Select( i => i.Distance).Min();

            PartOne = nearest.ToString();
            PartTwo = shortest.ToString();            
        }

        private List<Line> MakeList(string wire)
        {
            var list = new List<Line>();
            var location = new Location{ X = 0, Y = 0 };
            var distance = 0;

            foreach( var segment in wire.Split(',') )
            {   
                var line = new Line{
                    X1 = location.X,
                    Y1 = location.Y
                };
                var direction = segment[0];
                var length = int.Parse(segment.Substring(1));
                
                switch(direction)
                {
                    case 'U':
                        location.Y += length;
                        break;
                    case 'D':
                        location.Y -= length;
                        break;
                    case 'L':
                        location.X -= length;
                        break;
                    case 'R':
                        location.X += length;
                        break;
                }
                line.X2 = location.X;
                line.Y2 = location.Y;
                line.Distance = distance;
                distance += length;
                list.Add(line);
            }

            return list;
        }

        private class Location
        {
            public int Distance { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
        }

        private class Line
        {
            public int Distance { get; set; }
            public int X1 { get; set; }
            public int X2 { get; set; }
            public int Y1 { get; set; }
            public int Y2 { get; set; }
        }
    }    
}