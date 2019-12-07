namespace AdventOfCode.Tests._2019
{
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode._2019.Components;
    using Xunit;
    
    public class ComputerTests
    {
        public Computer Computer { get; set; }
        
        
        public ComputerTests()
        {
            Computer = new Computer();
        }

        [Fact]
        public void InitialState()
        {
            Assert.Equal(0, Computer.Address);
            Assert.Equal(0, Computer.Program.Count);
        }

        [Theory,
        //Day 2, Part 1
        InlineData("1,9,10,3,2,3,11,0,99,30,40,50","3500,9,10,70,2,3,11,0,99,30,40,50"),
        InlineData("1,0,0,0,99", "2,0,0,0,99"),
        InlineData("2,3,0,3,99", "2,3,0,6,99"),
        InlineData("2,4,4,5,99,0", "2,4,4,5,99,9801"),
        InlineData("1,1,1,4,99,5,6,0,99", "30,1,1,4,2,5,6,0,99"),
        //Day 5, Part 1
        InlineData("1002,4,3,4,33", "1002,4,3,4,99"),
        InlineData("1101,100,-1,4,0", "1101,100,-1,4,99")]
        
        public void StateExamples(string initial, string final)
        {
            Computer.LoadProgram(initial);
            Computer.Run();
            Assert.Equal(final, Computer.ExtractProgram());
        }

        [Theory,
        InlineData("3,9,8,9,10,9,4,9,99,-1,8", "7", "0"),
        InlineData("3,9,8,9,10,9,4,9,99,-1,8", "8", "1"),
        InlineData("3,9,8,9,10,9,4,9,99,-1,8", "9", "0"),
        InlineData("3,9,7,9,10,9,4,9,99,-1,8", "7", "1"),
        InlineData("3,9,7,9,10,9,4,9,99,-1,8", "8", "0"),
        InlineData("3,9,7,9,10,9,4,9,99,-1,8", "9", "0"),
        InlineData("3,3,1108,-1,8,3,4,3,99", "7", "0"),
        InlineData("3,3,1108,-1,8,3,4,3,99", "8", "1"),
        InlineData("3,3,1108,-1,8,3,4,3,99", "9", "0"),
        InlineData("3,3,1107,-1,8,3,4,3,99", "7", "1"),
        InlineData("3,3,1107,-1,8,3,4,3,99", "8", "0"),
        InlineData("3,3,1107,-1,8,3,4,3,99", "9", "0"),
        InlineData("3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9", "0", "0"),
        InlineData("3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9", "1", "1"),
        InlineData("3,3,1105,-1,9,1101,0,0,12,4,12,99,1", "0", "0"),
        InlineData("3,3,1105,-1,9,1101,0,0,12,4,12,99,1", "1", "1"),
        InlineData("3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99", "7", "999"),
        InlineData("3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99", "8", "1000"),
        InlineData("3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99", "9", "1001"),
        ]
        public void OutputExamples(string program, string inputString, string output )
        {
            Computer.LoadProgram(program);
            var input = inputString.Split(',').Select(i => int.Parse(i)).ToList();
            var result = Computer.Run(input);
            Assert.Equal(output, string.Join(',', result));
        }

        [Theory,
        InlineData(1,4),
        InlineData(2,4),
        InlineData(3,2),
        InlineData(4,2),
        InlineData(5,3),
        InlineData(6,3),
        InlineData(7,4),
        InlineData(8,4),
        InlineData(99,1)]
        public void GetInstructionSize(int opCode, int expectedSize)
        {
            Assert.Equal(expectedSize, Computer.GetInstructionSize(opCode));
        }

        [Theory,
        InlineData("1202", 12, 2),
        InlineData("7834", 78, 34)]
        public void LoadAlarmCode(string code, int noun, int verb)
        {
            Computer.LoadProgram("1,9,10,3,2,3,11,0,99,30,40,50");
            Computer.LoadAlarmCode(code);
            Assert.Equal(noun, Computer.Program[1]);
            Assert.Equal(verb, Computer.Program[2]);
        }
        [Theory,
        InlineData("0,1", "1,0;0,1"),
        InlineData("0,1,2", "2,1,0;1,2,0;2,0,1;0,2,1;1,0,2;0,1,2")]
        public void GetPermutations(string input, string output)
        {
            var result = Computer.GetPermutations(input.Split(",").Select(i => int.Parse(i)).ToList());
            
            var result2 = result.Select(r => string.Join(',',r));

            Assert.Equal(output, string.Join(';', result2));

        }
    }
}