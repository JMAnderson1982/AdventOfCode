
namespace AdventOfCode._2019.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    [Obsolete]
    public class ComputerStatic
    {
        public static string Compute(string input)
        {
            var commands = GetCommands(input);
            
            Compute(ref commands);

            return commands[0].ToString();
        }

        public static string Compute(string input, List<int> inputs)
        {
            var commands = GetCommands(input);

            return Compute(ref commands, inputs);
        }

        public static string Compute(string input, int target)
        {
            var commandCount = GetCommands(input).Count;

            for(int noun = 0; noun < commandCount; noun++)
            {
                for(int verb = 0; verb < commandCount; verb++)
                {
                    var commands = GetCommands(input);
                    commands[1] = noun;
                    commands[2] = verb;
                    Compute(ref commands);
                    if(commands[0] == target)
                    {
                        return (noun * 100 + verb).ToString();
                    }
                }
            }
            return string.Empty;
        }

        private static string Compute(ref List<int> commands, List<int> inputs = null)
        {
            var output = string.Empty;
            var commandLength = 2;
            for(int i = 0; i < commands.Count(); i += commandLength)
            {
                var opCode = commands[i] % 100;
                var parameter1Mode = commands[i] /   100 % 10;
                var parameter2Mode = commands[i] /  1000 % 10;
                var parameter3Mode = commands[i] / 10000 % 10;

                var operandOne = GenerateOperand(commands, parameter1Mode, i + 1);
                var operandTwo = GenerateOperand(commands, parameter2Mode, i + 2);
                var operandThree = GenerateOperand(commands, parameter3Mode, i + 3);

                switch(opCode)
                {
                    case 1:
                        commands[commands[i + 3]] = operandOne + operandTwo;
                        commandLength = 4;
                        break;
                    case 2:
                        commands[commands[i + 3]] = operandOne * operandTwo;
                        commandLength = 4;
                        break;
                    case 3:
                        commands[commands[i + 1]] = inputs.First();
                        inputs.RemoveAt(0);
                        commandLength = 2;
                        break;
                    case 4:
                        output += $"{commands[commands[i + 1]].ToString()} ";
                        commandLength = 2;
                        break;
                    case 5:
                        commandLength = 3;
                        if(operandOne != 0)
                        {
                            i = operandTwo;
                            commandLength = 0;
                        }
                        break;
                    case 6:
                        commandLength = 3;
                        if(operandOne == 0)
                        {
                            i = operandTwo;
                            commandLength = 0;
                        }
                        break;
                    case 7: 
                        if(operandOne < operandTwo)
                            commands[commands[i + 3]] = 1;
                        else
                            commands[commands[i + 3]] = 0;
                        commandLength = 4;
                        break;
                    case 8:
                        if(operandOne == operandTwo)
                            commands[commands[i + 3]] = 1;
                        else
                            commands[commands[i + 3]] = 0;
                        commandLength = 4;
                        break;
                    case 99:
                        return output;
                }            
            }    
            throw new ArgumentException("Program does not include 'break' instruction");
        }

        private static int GenerateOperand(List<int> commands, int parameter, int index)
        {   try{
                switch(parameter)
                {
                    case 0:
                        return commands[commands[index]];
                    case 1:
                        return commands[index];
                    default:
                        return 0;
                }
            }
            catch{
                return 0;
            }
            
            throw new ArgumentException("Shits fucked up");
        }

        public static List<int> GetCommands(string input)
        {
            var rawCommands = input.Split(',').ToList();

            return rawCommands.Select(c => int.Parse(c)).ToList();
        }
    }
}