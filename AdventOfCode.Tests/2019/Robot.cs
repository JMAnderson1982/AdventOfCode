namespace AdventOfCode.Tests._2019
{
    using Xunit;
    using AdventOfCode._2019.Components;
    using System.Linq;

    public class RobotTests
    {
        public Robot Robot { get; set; } = new Robot();

        [Theory,
        InlineData("1,0;0,0;1,0;1,0;0,1;1,0;1,0",6)]
        public void VariousInputs(string directions, int historyCount)
        {
            var pairs = directions.Split(';');

            foreach(var pair in pairs)
            {
                var input = pair.Split(',').Select(p => long.Parse(p)).ToList();
                Robot.ProcessInstructions(input);
            }
            Assert.Equal(historyCount, Robot.History.Count);
        }
    }
}