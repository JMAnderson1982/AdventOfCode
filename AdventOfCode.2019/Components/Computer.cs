namespace AdventOfCode._2019.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Computer
    {
        public int Address { get; set; } = 0;

        public List<int> Program { get; set; } = new List<int>();

        private int __OpCode => Program[Address];
        private int __ParamOne => Program[Address + 1];
        private int __ParamTwo => Program[Address + 2];
        private int __ParamThree => Program[Address + 3];

        public void LoadProgram(string program)
        {
            Program = program.Split(',').Select(c => int.Parse(c)).ToList();
        }

        public void LoadAlarmCode(string code)
        {
            var noun = int.Parse(code.Substring(0,2));
            var verb = int.Parse(code.Substring(2));

            Program[1] = noun;
            Program[2] = verb;
        }

        public string ExtractProgram()
        {
            return string.Join(',', Program);
        }

        public void Run()
        {       
            while(__OpCode != 99)
            {
                var stepLength = GetInstructionSize(__OpCode);     
                switch(__OpCode)    
                {
                    case 1: 
                        Add();
                        break;
                    case 2:
                        Mul();
                        break;
                    case 99:
                        return;
                    default:
                        throw new NotImplementedException($"Shits fucked: {__OpCode}");
                
                }
                Address += stepLength;
                Run();
            }
        }

        public void Add()
        {
            Program[__ParamThree] = Program[__ParamOne] + Program[__ParamTwo];
        }

        public void Mul()
        {
            Program[__ParamThree] = Program[__ParamOne] * Program[__ParamTwo];
        }

        public int GetInstructionSize(int opCode)
        {
            switch(opCode)
            {
                case 1:
                case 2:
                    return 4;
                case 99:
                    return 1;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}