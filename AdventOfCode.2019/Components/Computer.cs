namespace AdventOfCode._2019.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode.Shared.Extensions;

    public class Computer
    {
        public int Address { get; set; } = 0;

        public List<int> Program { get; set; } = new List<int>();

        private int __Instruction => Program[Address];
        private int __Opcode => __Instruction % 100;
        private int __ParamOne => Program[Address + 1];
        private int __ModeOne => __Instruction / 100 % 10;
        private int __ParamTwo => Program[Address + 2];
        private int __ModeTwo => __Instruction / 1000 % 10;
        private int __ParamThree => Program[Address + 3];
        private int __ModeThree => __Instruction / 10000 % 10;

        private int __OperandOne => __ModeOne == 0 ? Program[__ParamOne] : __ParamOne;
        private int __OperandTwo => __ModeTwo == 0 ? Program[__ParamTwo] : __ParamTwo;
        private int __OperandThree => __ModeThree == 0 ? Program[__ParamThree] : __ParamThree;
        

        public void LoadProgram(string program)
        {
            Address = 0;
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

        public List<int> Run(List<int> input = null)
        {       
            var output = new List<int>();
            while(__Opcode != 99)
            {
                var stepLength = GetInstructionSize(__Opcode);     
                switch(__Opcode)    
                {
                    case 1: 
                        Program[__ParamThree] = __OperandOne + __OperandTwo;
                        break;
                    case 2:
                        Program[__ParamThree] = __OperandOne * __OperandTwo;
                        break;
                    case 3:
                        try{Program[__ParamOne] = input.Shift();}
                        catch{return output;}
                        break;
                    case 4:
                        output.Add(__OperandOne);
                        break;
                    case 5:
                        if(__OperandOne != 0)
                        {
                            Address = __OperandTwo;
                            continue;
                        }
                        break;
                    case 6:
                        if(__OperandOne == 0)
                        {
                            Address = __OperandTwo;
                            continue;
                        }
                        break;
                    case 7:
                        Program[__ParamThree] = __OperandOne < __OperandTwo ? 1 : 0;
                        break;
                    case 8:
                        Program[__ParamThree] = __OperandOne == __OperandTwo ? 1 : 0;
                        break;
                        
                    default:
                        throw new NotImplementedException($"Shits fucked: {__Instruction}");
                
                }
                Address += stepLength;
            }
            return output;
        }

        public int GetInstructionSize(int opCode)
        {
            switch(opCode)
            {
                case 99:
                    return 1;
                case 3:
                case 4:
                    return 2;
                case 5:
                case 6:
                    return 3;
                case 1:
                case 2:
                case 7:
                case 8:
                    return 4;
                default:
                    throw new NotImplementedException();
            }
        }

        public static List<List<int>> GetPermutations(List<int> list)
        {
            var permutations = new List<List<int>>();
            for(int i = 0; i < list.Count; i++)
            {
                var first = list[i];
                var subList = new List<int>(list);
                subList.Remove(first);
                var newList = GetPermutations(subList);
                newList.ForEach(l => l.Add(first));
                permutations.AddRange(newList);
            }
            if(permutations.Count() == 0)
            {
                permutations.Add(new List<int>());
            }
            return permutations;
        }
    }
}