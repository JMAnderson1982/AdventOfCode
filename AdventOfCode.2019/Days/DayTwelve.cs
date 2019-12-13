namespace AdventOfCode._2019.Days
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode._2019.Components;
    using AdventOfCode.Shared;
    using AdventOfCode.Shared.Extensions;
    class DayTwelve : Day
    {
        public DayTwelve() : base(12) { }

        public List<Moon> Moons { get; set; } = new List<Moon>();

        public List<State> XStates { get; set; } = new List<State>();
        public List<State> YStates { get; set; } = new List<State>();
        public List<State> ZStates { get; set; } = new List<State>();

        private int TotalStepCount;

        private int __XDuplicatePoint = 0;
        private int __YDuplicatePoint = 0;
        private int __ZDuplicatePoint = 0;

        public override void TheNeedful()
        {
            // Input = "<x=-1, y=0, z=2>\n"
            //         + "<x=2, y=-10, z=-7>\n"
            //         + "<x=4, y=-8, z=8>\n"
            //         + "<x=3, y=5, z=-1>";
            
            // Input = "<x=-8, y=-10, z=0>\n"
            //         + "<x=5, y=5, z=10>\n"
            //         + "<x=2, y=-7, z=3>\n"
            //         + "<x=9, y=-8, z=-3>";
            InitializeMoons();
            
            Step(1000);

            PartOne = Moons.Sum(m => m.Energy).ToString();

            InitializeMoons();
            
            
            SaveStates();
            
            

            while(!StatesDuplicated())
            {
                
                Step();
                SaveStates();
                TotalStepCount++;
                if(TotalStepCount % 10000 == 0)
                {
                    Console.WriteLine($"{TotalStepCount} - {__XDuplicatePoint} {__YDuplicatePoint} {__ZDuplicatePoint}");
                }
            }
            
            PartTwo = LCM(new long[] {__XDuplicatePoint, __YDuplicatePoint, __ZDuplicatePoint}).ToString();

            return;
        }

        public bool StatesDuplicated()
        {
            return(__XDuplicatePoint != 0 && __YDuplicatePoint != 0 && __ZDuplicatePoint != 0);
        }

        public void InitializeMoons()
        {
            TotalStepCount = 0;
            Moons = new List<Moon>();
            var inputs = Input.Split("\n");

            foreach(var input in inputs)
            {
                var coords = input.Trim( new char[] {'<','>'}).Split(", ");
                var x = int.Parse(coords[0].Substring(2));
                var y = int.Parse(coords[1].Substring(2));
                var z = int.Parse(coords[2].Substring(2));

                Moons.Add(new Moon{XPos = x, YPos = y, ZPos = z});
            }
        }

        public void SaveStates()
        {   var positions = Moons.Select(m => m.XPos).ToList();
            var velocities = Moons.Select(m=>m.XVel).ToList();

            var state = new State { XP1 = positions.Shift(),
                                     XP2 = positions.Shift(),
                                     XP3 = positions.Shift(),
                                     XP4 = positions.Shift(),
                                     XV1 = velocities.Shift(),
                                     XV2 = velocities.Shift(),
                                     XV3 = velocities.Shift(),
                                     XV4 = velocities.Shift() };
            if(__XDuplicatePoint == 0)
            {
                if(XStates.Any(x => x.XP1 == state.XP1
                                && x.XP2 == state.XP2
                                && x.XP3 == state.XP3
                                && x.XP4 == state.XP4
                                && x.XV1 == state.XV1
                                && x.XV2 == state.XV2
                                && x.XV3 == state.XV3
                                && x.XV4 == state.XV4 )) __XDuplicatePoint = TotalStepCount + 1;
                // else XStates.Add( state);
            }
            if(XStates.Count == 0){ XStates.Add(state); }
            


            positions = Moons.Select(m => m.YPos).ToList();
            velocities = Moons.Select(m => m.YVel).ToList();

            state = new State { XP1 = positions.Shift(),
                                    XP2 = positions.Shift(),
                                    XP3 = positions.Shift(),
                                    XP4 = positions.Shift(),
                                    XV1 = velocities.Shift(),
                                    XV2 = velocities.Shift(),
                                    XV3 = velocities.Shift(),
                                    XV4 = velocities.Shift() };
            

            if(__YDuplicatePoint == 0)
            {
                if(YStates.Any(y => y.XP1 == state.XP1
                                && y.XP2 == state.XP2
                                && y.XP3 == state.XP3
                                && y.XP4 == state.XP4
                                && y.XV1 == state.XV1
                                && y.XV2 == state.XV2
                                && y.XV3 == state.XV3
                                && y.XV4 == state.XV4 )) __YDuplicatePoint = TotalStepCount + 1 ;
                // else YStates.Add( state);
            }
            if(YStates.Count == 0){ YStates.Add(state); }

            positions = Moons.Select(m => m.ZPos).ToList();
            velocities = Moons.Select(m => m.ZVel).ToList();
            state = new State { XP1 = positions.Shift(),
                                    XP2 = positions.Shift(),
                                    XP3 = positions.Shift(),
                                    XP4 = positions.Shift(),
                                    XV1 = velocities.Shift(),
                                    XV2 = velocities.Shift(),
                                    XV3 = velocities.Shift(),
                                    XV4 = velocities.Shift() };
            
            if(__ZDuplicatePoint == 0)
            {
                if(ZStates.Any(z => z.XP1 == state.XP1
                                && z.XP2 == state.XP2
                                && z.XP3 == state.XP3
                                && z.XP4 == state.XP4
                                && z.XV1 == state.XV1
                                && z.XV2 == state.XV2
                                && z.XV3 == state.XV3
                                && z.XV4 == state.XV4 )) __ZDuplicatePoint = TotalStepCount + 1 ;
                // else ZStates.Add( state);
            }
            if(ZStates.Count == 0) { ZStates.Add(state); }
        }

        public void Step(int times = 1)
        {
            for(int i = 0; i < times; i++)
            {
                //Gravity
                foreach(var moon in Moons)
                {
                    foreach(var otherMoon in Moons)
                    {
                        if(moon.XPos > otherMoon.XPos) {moon.XVel--;}
                        if(moon.XPos < otherMoon.XPos) {moon.XVel++;}
                        if(moon.YPos > otherMoon.YPos) {moon.YVel--;}
                        if(moon.YPos < otherMoon.YPos) {moon.YVel++;}
                        if(moon.ZPos > otherMoon.ZPos) {moon.ZVel--;}
                        if(moon.ZPos < otherMoon.ZPos) {moon.ZVel++;}
                    }
                }
                //Velocity
                foreach(var moon in Moons)
                {
                    moon.XPos += moon.XVel;
                    moon.YPos += moon.YVel;
                    moon.ZPos += moon.ZVel;
                }
            }
        }

        static long LCM(long[] numbers)
        {
            return numbers.Aggregate(lcm);
        }
        static long lcm(long a, long b)
        {
            return Math.Abs(a * b) / GCD(a, b);
        }
        static long GCD(long a, long b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        public class State
        {
            public int XP1 { get; set; }
            public int XP2 { get; set; }
            public int XP3 { get; set; }
            public int XP4 { get; set; }
            public int XV1 { get; set; }
            public int XV2 { get; set; }
            public int XV3 { get; set; }
            public int XV4 { get; set; }
        }

        public class Moon
        {
            public int XPos { get; set; }
            public int YPos { get; set; }
            public int ZPos { get; set; }
            public int XVel { get; set; } = 0;
            public int YVel { get; set; } = 0;
            public int ZVel { get; set; } = 0;

            public int PEnergy => Math.Abs(XPos) + Math.Abs(YPos) + Math.Abs(ZPos);
            public int KEnergy => Math.Abs(XVel) + Math.Abs(YVel) + Math.Abs(ZVel);

            public int Energy => PEnergy * KEnergy;
        }
    }
}