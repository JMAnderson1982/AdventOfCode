
namespace AdventOfCode._2015
{
    using AdventOfCode._2015.Days;
    using AdventOfCode.Shared;
    class Program
    {
        static void Main(string[] args)
        {
            var advent = new Advent{ Year = 2015 };
            
            advent.Days.Add(new DayOne());
            advent.Days.Add(new DayTwo());
            advent.Days.Add(new DayThree());

            advent.ShowResults();
        }
    }
}
