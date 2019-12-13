namespace AdventOfCode._2019.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode.Shared.Extensions;

    public class Computer
    {
        public int Address { get; set; } = 0;

        public long RelativeBase { get; set; } = 0;

        public Dictionary<long,long> Program { get; set; } = new Dictionary<long,long>();

        public int Instruction => (int)Program[Address];
        private int __Opcode => Instruction % 100;
        private long __ParamOne => Program[Address + 1];
        private long __ModeOne => Instruction / 100 % 10;
        private long __ParamTwo => Program[Address + 2];
        private long __ModeTwo => Instruction / 1000 % 10;
        private long __ParamThree => Program[Address + 3];
        private long __ModeThree => Instruction / 10000 % 10;

        private long __OperandOne { get {switch(__ModeOne)
                                    { 
                                        case 0: 
                                            return Program.GetAndCreate(__ParamOne); 
                                        case 1: 
                                            return __ParamOne;
                                        case 2:
                                            return Program.GetAndCreate(__ParamOne + RelativeBase);
                                        default:
                                            throw new NotImplementedException($"Mode {__ModeOne}");
                                    }}}
        private long __OperandTwo { get {switch(__ModeTwo)
                                    { 
                                        case 0: 
                                            return Program.GetAndCreate(__ParamTwo); 
                                        case 1: 
                                            return __ParamTwo;
                                        case 2:
                                            return Program.GetAndCreate(__ParamTwo + RelativeBase);
                                        default:
                                            throw new NotImplementedException($"Mode {__ModeTwo}");
                                    }}}
        
        private long __OperandThree { get {switch(__ModeThree)
                                    { 
                                        case 0: 
                                            return Program.GetAndCreate(__ParamThree); 
                                        case 1: 
                                            return __ParamThree;
                                        case 2:
                                            return Program.GetAndCreate(__ParamThree + RelativeBase);
                                        default:
                                            throw new NotImplementedException($"Mode {__ModeThree}");
                                    }}}

        public void LoadProgram(string program)
        {
            Address = 0;
            RelativeBase = 0;
            Program = program.Split(',').Select((v,i) => new {v, i})
                                        .ToDictionary(kvp => (long)kvp.i, kvp => long.Parse(kvp.v));
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

        public List<long> Run(List<long> input = null)
        {       
            var output = new List<long>();
            while(__Opcode != 99)
            {
                var stepLength = GetInstructionSize(__Opcode);     
                switch(__Opcode)    
                {
                    case 1: 
                        Program[(int)__ParamThree + (__ModeThree == 0 ? 0 : RelativeBase)] = __OperandOne + __OperandTwo;
                        break;
                    case 2:
                        Program[(int)__ParamThree + (__ModeThree == 0 ? 0 : RelativeBase)] = __OperandOne * __OperandTwo;
                        break;
                    case 3:
                        if(input.Count == 0)
                        { return output; }
                        Program[(int)__ParamOne + (__ModeOne == 0 ? 0 : RelativeBase)] = input.Shift();
                        break;
                    case 4:
                        output.Add(__OperandOne);
                        break;
                    case 5:
                        if(__OperandOne != 0)
                        {
                            Address = (int)__OperandTwo;
                            continue;
                        }
                        break;
                    case 6:
                        if(__OperandOne == 0)
                        {
                            Address = (int)__OperandTwo;
                            continue;
                        }
                        break;
                    case 7:
                        Program[(int)__ParamThree + (__ModeThree == 0 ? 0 : RelativeBase)] = __OperandOne < __OperandTwo ? 1 : 0;
                        break;
                    case 8:
                        Program[(int)__ParamThree + (__ModeThree == 0 ? 0 : RelativeBase)] = __OperandOne == __OperandTwo ? 1 : 0;
                        break;
                    case 9:
                        RelativeBase += __OperandOne;
                        break;
                    default:
                        throw new NotImplementedException($"Shits fucked: {Instruction}");
                
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
                case 9:
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

        public static List<List<long>> GetPermutations(List<long> list)
        {
            var permutations = new List<List<long>>();
            for(int i = 0; i < list.Count; i++)
            {
                var first = list[i];
                var subList = new List<long>(list);
                subList.Remove(first);
                var newList = GetPermutations(subList);
                newList.ForEach(l => l.Add(first));
                permutations.AddRange(newList);
            }
            if(permutations.Count() == 0)
            {
                permutations.Add(new List<long>());
            }
            return permutations;
        }
    }
}