namespace AdventOfCode._2019.Days
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode._2019.Components;
    using AdventOfCode.Shared;

    public class DayTwo : Day
    {
        public DayTwo() : base()
        {
            Date = 2;
        }

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
                    computer = new Computer();
                    computer.LoadProgram(Input);
                    computer.LoadAlarmCode(code);
                    computer.Run();
                    if(computer.Program[0] == 19690720)
                    {
                        PartTwo = code;
                        return;
                    }
                }



            // var rawCommands = Input.Split(',').ToList();
            
            // var commands = rawCommands.Select(c => int.Parse(c)).ToList();

            // for(int i = 0; i < commands.Count(); i += 4)
            // {
            //     if(commands[i] == 99) {break;}
            //     switch(commands[i])
            //     {
            //         case 1:
            //             commands[commands[i + 3]] = commands[commands[i + 1]] + commands[commands[i + 2]];
            //             break;
            //         case 2:
            //             commands[commands[i + 3]] = commands[commands[i + 1]] * commands[commands[i + 2]];
            //             break;
            //         case 99:
                        
            //             break;
            //     }
            // }

            // // PartOne = ComputerStatic.Compute(Input);
            // PartTwo = ComputerStatic.Compute(Input, 19690720);
        }
    }
}