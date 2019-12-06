namespace AdventOfCode._2019.Days{
    using System;
    using System.Collections.Generic;
    using AdventOfCode._2019.Components;
    using AdventOfCode.Shared;

    public class DayFive : Day
    {
        public DayFive() : base(5) {}

        public override void TheNeedful()
        {
            // Console.WriteLine(Computer.Compute("3,9,8,9,10,9,4,9,99,-1,8", new List<int>{ 7 }));
            // Console.WriteLine(Computer.Compute("3,9,8,9,10,9,4,9,99,-1,8", new List<int>{ 8 }));
            // Console.WriteLine(Computer.Compute("3,9,8,9,10,9,4,9,99,-1,8", new List<int>{ 9 }));

            // Console.WriteLine(Computer.Compute("3,9,7,9,10,9,4,9,99,-1,8", new List<int>{ 7 }));
            // Console.WriteLine(Computer.Compute("3,9,7,9,10,9,4,9,99,-1,8", new List<int>{ 8 }));
            // Console.WriteLine(Computer.Compute("3,9,7,9,10,9,4,9,99,-1,8", new List<int>{ 9 }));

            // Console.WriteLine(Computer.Compute("3,3,1108,-1,8,3,4,3,99", new List<int>{ 7 }));
            // Console.WriteLine(Computer.Compute("3,3,1108,-1,8,3,4,3,99", new List<int>{ 8 }));
            // Console.WriteLine(Computer.Compute("3,3,1108,-1,8,3,4,3,99", new List<int>{ 9 }));

            // Console.WriteLine(Computer.Compute("3,3,1107,-1,8,3,4,3,99", new List<int>{ 7 }));
            // Console.WriteLine(Computer.Compute("3,3,1107,-1,8,3,4,3,99", new List<int>{ 8 }));
            // Console.WriteLine(Computer.Compute("3,3,1107,-1,8,3,4,3,99", new List<int>{ 9 }));

            // Console.WriteLine(Computer.Compute("3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9", new List<int>{ 0 }));
            // Console.WriteLine(Computer.Compute("3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9", new List<int>{ 1 }));
            
            // Console.WriteLine(Computer.Compute("3,3,1105,-1,9,1101,0,0,12,4,12,99,1", new List<int>{ 0 }));
            // Console.WriteLine(Computer.Compute("3,3,1105,-1,9,1101,0,0,12,4,12,99,1", new List<int>{ 1 }));

            PartOne = ComputerStatic.Compute(Input, new List<int>{ 1 });
            PartTwo = ComputerStatic.Compute(Input, new List<int>{ 5 });
        }


    }

}