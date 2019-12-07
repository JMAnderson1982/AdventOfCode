namespace AdventOfCode._2019.Days{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode._2019.Components;
    using AdventOfCode.Shared;

    public class DayFive : Day
    {
        public DayFive() : base(5) {}

        public override void TheNeedful()
        {
            var computer = new Computer();
            computer.LoadProgram(Input);
            var output = computer.Run(new List<int>{1});
            PartOne = output.Last().ToString();
            
            computer.LoadProgram(Input);
            PartTwo = computer.Run(new List<int>{5}).Last().ToString(); 
        }


    }

}