namespace AdventOfCode._2019.Days
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode.Shared;

    public class DayTwo : Day
    {
        public DayTwo() : base()
        {
            Date = 2;
        }

        public override void TheNeedful()
        {
            var rawCommands = Input.Split(',').ToList();
            
            var commands = rawCommands.Select(c => int.Parse(c)).ToList();

            for(int i = 0; i < commands.Count(); i += 4)
            {
                if(commands[i] == 99) {break;}
                switch(commands[i])
                {
                    case 1:
                        commands[commands[i + 3]] = commands[commands[i + 1]] + commands[commands[i + 2]];
                        break;
                    case 2:
                        commands[commands[i + 3]] = commands[commands[i + 1]] * commands[commands[i + 2]];
                        break;
                    case 99:
                        
                        break;
                }
            }
            PartOne = commands[0].ToString();

            const int target = 19690720;

            for(int noun = 0; noun < commands.Count(); noun++)
            {
                for(int verb = 0; verb < commands.Count(); verb++)
                {
                    ResetInput();
                    commands = rawCommands.Select(c => int.Parse(c)).ToList();
                    commands[1] = noun;
                    commands[2] = verb;
                    for(int k = 0; k < commands.Count(); k += 4)
                    {
                        if(commands[k] == 99) {break;}
                        switch(commands[k])
                        {
                            case 1:
                                commands[commands[k + 3]] = commands[commands[k + 1]] + commands[commands[k + 2]];
                                break;
                            case 2:
                                commands[commands[k + 3]] = commands[commands[k + 1]] * commands[commands[k + 2]];
                                break;
                            case 99:
                                
                                break;
                        }
                    }
                    if(commands[0] == target)
                    {
                        PartTwo = (noun * 100 + verb).ToString();
                        return;
                    }
                }
            }

        }
    }
}