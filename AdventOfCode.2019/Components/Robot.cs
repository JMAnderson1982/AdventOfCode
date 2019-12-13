namespace AdventOfCode._2019.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AdventOfCode.Shared.Extensions;

    public class Robot
    {
        public Computer Computer { get; set; } = new Computer();

        public Position Current { get; set; } = new Position();

        public Direction Facing { get; set; } = Direction.North;

        public List<Position> History { get; set; } = new List<Position>();

        private int __XDirectionOffset { get { switch(Facing)
                                                {
                                                    case Direction.East:
                                                        return 1;
                                                    case Direction.West:
                                                        return -1;
                                                    case Direction.North:
                                                    case Direction.South:
                                                    default:
                                                        return 0;
                                            }}}
                                            
        private int __YDirectionOffset { get { switch(Facing)
                                                {
                                                    case Direction.North:
                                                        return 1;
                                                    case Direction.South:
                                                        return -1;
                                                    case Direction.East:
                                                    case Direction.West:
                                                    default:
                                                        return 0;
                                            }}}

        public void Run(int initialColor = 0)
        {
            Current.Color = initialColor;
            while(Computer.Instruction != 99)
            {
                var instructions = Computer.Run(new List<long>{Current.Color});
                ProcessInstructions(instructions);

            }
        }

        public string VisualizeIt()
        {
            var sb = new StringBuilder();
            sb.AppendLine();
            for(int y = History.Select(h => h.Y).Max(); y >= History.Select(h => h.Y).Min(); y--)
            {
                for(int x = History.Select(h => h.X).Min(); x <= History.Select(h => h.X).Max(); x++)
                {
                    var cell = History.FirstOrDefault(h => h.X == x && h.Y == y);

                    sb.Append( cell == null || cell.Color == 0 ? " " : "1");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public void ProcessInstructions(List<long> instructions)
        {
            if(instructions.Count == 0)
                return;
            
            Current.Color = (int)instructions.Shift();
            History.RemoveAll( h => h.X == Current.X && h.Y == Current.Y);
            History.Add(Current);
            
            Facing = (Direction)(((int)instructions.Shift() == 1 ? (int)Facing + 1 : (int)Facing + 3) % 4);
            
            var newX = Current.X + __XDirectionOffset;
            var newY = Current.Y + __YDirectionOffset;
            Current = History.FirstOrDefault( c => c.X == Current.X + __XDirectionOffset 
                                                && c.Y == Current.Y + __YDirectionOffset);
            if(Current == null)
            {
                Current = new Position{ X = newX, Y = newY };
            }
        }
        
        

        public class Position
        {
            public int X { get; set; } = 0;
            public int Y { get; set; } = 0;
            public int Color { get; set; } = 0;
        }

        public enum Direction 
        {
            North = 0,
            East,
            South,
            West

        }
    }
}