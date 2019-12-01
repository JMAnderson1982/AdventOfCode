
namespace AdventOfCode._2015
{
    using AdventOfCode._2015.Days;
    using AdventOfCode.Shared;
    class Program
    {
        static void Main(string[] args)
        {
            var advent = new Advent{ Year = 2015 };
            
            advent.NewDays.Add(new DayOne());
            advent.NewDays.Add(new DayTwo());
            advent.NewDays.Add(new DayThree());

            advent.ShowResults();
        }
    }
}
