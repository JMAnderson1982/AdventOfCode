
namespace AdventOfCode._2015
{
    using AdventOfCode._2015.Days;
    using AdventOfCode.Shared;
    class Program
    {
        static void Main(string[] args)
        {
            var advent = new Advent{ Year = 2015 };
            
            advent.Days[0] = DayOne.GetDay();
            advent.Days[1] = DayTwo.GetDay();
            advent.Days[2] = DayThree.GetDay();

            advent.ShowResults();
        }
    }
}
