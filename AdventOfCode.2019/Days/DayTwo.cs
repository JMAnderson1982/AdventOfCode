namespace AdventOfCode._2019.Days
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode._2019.Components;
    using AdventOfCode.Shared;

    public class DayTwo : Day
    {
        public DayTwo() : base(2) {}

        public override void TheNeedful()
        {
            var computer = new Computer();

            computer.LoadProgram(Input);
            computer.LoadAlarmCode("1202");

            computer.Run();
            PartOne = computer.Program[0].ToString();

            for( int noun = 0; noun < 100; noun++)
                for( int verb = 0; verb < 100; verb++)
                {
                    var code = $"{noun.ToString("D2")}{verb.ToString("D2")}";
                    computer.LoadProgram(Input);
                    computer.LoadAlarmCode(code);
                    computer.Run();
                    if(computer.Program[0] == 19690720)
                    {
                        PartTwo = code;
                        return;
                    }
                }
        }
    }
}