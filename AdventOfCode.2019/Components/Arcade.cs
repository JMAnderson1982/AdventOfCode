namespace AdventOfCode._2019.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AdventOfCode.Shared.Extensions;
    public class Arcade
    {
        public Computer Computer { get; set; } = new Computer();

        public List<Tile> Screen { get; set; } = new List<Tile>();

        public int Score { get; set; } = 0;

        public void Run(List<long> input = null)
        {
            //Console.Clear();
            if(input == null) {input = new List<long>();}
            var i = new List<long>();
            while( Computer.Instruction != 99 )
            {
                
                if(input.Count() > 0)
                {
                    i.Add(input.Shift());
                }

                var output = Computer.Run(i);

                var lastBallPosition = Screen.FirstOrDefault(s => s.Contents == Type.Ball);

                while(output.Count() != 0)
                {
                    var x = (int)output.Shift();
                    var y = (int)output.Shift();
                    var value = (int)output.Shift();
                    if(x == -1)
                    {
                        Score = value;
                    }
                    else{
                        Screen.RemoveAll(s => s.X == x && s.Y == y);
                        Screen.Add(new Tile {X = x, Y = y, Contents = (Type)value});
                        // Console.SetCursorPosition(x + 90,y);
                        // Console.Write(TypeToChar((Type)value));
                    }
                }
                var newBallPosition = Screen.FirstOrDefault(s => s.Contents == Type.Ball);
                var newPaddlePosition = Screen.FirstOrDefault(s => s.Contents == Type.Paddle);

                if(newPaddlePosition.X > newBallPosition.X)
                {
                    i.Add(-1);
                       
                }
                else if(newPaddlePosition.X < newBallPosition.X)
                {
                    i.Add(1);
                }
                else
                {
                    i.Add(0);
                }



                //Console.WriteLine(DrawScreen());
            }

            // Console.SetCursorPosition(0,25);
        }
        
        public int TileTypeCount(Type type)
        {
            return Screen.Count(s => s.Contents == type);
        }

        public void FreePlay()
        {
            Computer.Program[0] = 2;
        }

        public string DrawScreen()
        {
            var sb = new StringBuilder();
            sb.AppendLine();

            for( int y = 0; y <= Screen.Select(s => s.Y).Max(); y++)
            {
                for ( int x = 0; x <= Screen.Select(s => s.X).Max(); x++)
                {
                    switch(Screen.FirstOrDefault(s => s.X == x && s.Y == y)?.Contents)
                    {
                        case Type.Empty:
                            sb.Append(" ");
                            break;
                        case Type.Wall:
                            sb.Append("W");
                            break;
                        case Type.Block:
                            sb.Append("-");
                            break;
                        case Type.Paddle:
                            sb.Append("_");
                            break;
                        case Type.Ball:
                            sb.Append("o");
                            break;
                        default:
                            break;
                    }
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public char TypeToChar(Type type)
        {
            switch(type)
            {
                case Type.Empty:
                    return ' ';
                case Type.Wall:
                    return 'W';
                case Type.Block:
                    return '-';
                case Type.Paddle:
                    return '_';
                case Type.Ball:
                    return 'o';
                default:
                    return ' ';
            }
        }

        public class Tile
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Type Contents { get; set; }
        }
        public enum Type
        {
            Empty = 0,
            Wall,
            Block,
            Paddle,
            Ball
        }
    }
}