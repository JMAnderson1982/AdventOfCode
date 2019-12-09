namespace AdventOfCode._2019.Days
{
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode._2019.Components;
    using AdventOfCode.Shared;
    class DayNine : Day
    {
        public DayNine() : base(9) { }

        public override void TheNeedful()
        {
            var computer = new Computer();

            computer.LoadProgram(Input);

            var result = computer.Run(new List<long> {1});


            PartOne = string.Join(" ", result);

            computer.LoadProgram(Input);

            result = computer.Run(new List<long> {2});
            
            PartTwo = string.Join(" ", result);
        }
    }
}