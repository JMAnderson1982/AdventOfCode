namespace AdventOfCode.Tests._2019
{
    using AdventOfCode._2019.Components;
    using Xunit;
    public class ComputerStaticTests
    {
        [Theory,
        InlineData("1,0,0,0",4 ),
        InlineData("1,2,3,4,5", 5)
        ]
        public void GetCommands(string commands, int expectedCount)
        {
            var ops = ComputerStatic.GetCommands(commands);
            Assert.Equal(ops.Count, expectedCount);
        }

        [Theory,
        InlineData("1,9,10,3,2,3,11,0,99,30,40,50","3500"),
        InlineData("1,0,0,0,99", "2"),
        InlineData("2,3,0,3,99", "2"),
        InlineData("2,4,4,5,99,0", "2"),
        InlineData("1,1,1,4,99,5,6,0,99", "30")]
        public void Day2_1Examples(string initial, string final)
        {
            Assert.Equal(final, ComputerStatic.Compute(initial));
        }
        
    }

}