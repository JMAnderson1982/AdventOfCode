namespace AdventOfCode.Tests._2019
{
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
        InlineData("1,9,10,3,2,3,11,0,99,30,40,50","3500,9,10,70,2,3,11,0,99,30,40,50"),
        InlineData("1,0,0,0,99", "2,0,0,0,99"),
        InlineData("2,3,0,3,99", "2,3,0,6,99"),
        InlineData("2,4,4,5,99,0", "2,4,4,5,99,9801"),
        InlineData("1,1,1,4,99,5,6,0,99", "30,1,1,4,2,5,6,0,99")]
        public void Day2_1Examples(string initial, string final)
        {
            Computer.LoadProgram(initial);
            Computer.Run();
            Assert.Equal(final, Computer.ExtractProgram());
        }

        [Theory,
        InlineData(1,4),
        InlineData(2,4),
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

    }
}