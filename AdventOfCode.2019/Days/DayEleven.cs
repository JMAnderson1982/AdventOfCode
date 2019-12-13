namespace AdventOfCode._2019.Days
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode._2019.Components;
    using AdventOfCode.Shared;
    class DayEleven : Day
    {
        public DayEleven() : base(11) { }

        public override void TheNeedful()
        {
            var robot = new Robot();

            robot.Computer.LoadProgram(Input);
            robot.Run();

            PartOne = robot.History.Count().ToString();
            robot = new Robot();
            robot.Computer.LoadProgram(Input);

            robot.Run(1);

            PartTwo = robot.VisualizeIt();
        }
    }
}