namespace AdventOfCode._2019
{
    using System;
    using AdventOfCode._2019.Days;
    using AdventOfCode.Shared;
    class Program
    {
        static void Main(string[] args)
        {
            var now = DateTime.Now;
            var advent = new Advent{ Year = 2019 };

            advent.NewDays.Add(new DayOne());
            advent.NewDays.Add(new DayTwo());
            advent.NewDays.Add(new DayThree());
            advent.NewDays.Add(new DayFour());
            advent.NewDays.Add(new DayFive());
            advent.NewDays.Add(new DaySix());
            // advent.NewDays.Add(new DaySeven());
            advent.NewDays.Add(new DayEight());

            advent.ShowResults();
            Console.WriteLine($"\n{(DateTime.Now - now).TotalMilliseconds}ms");
        }
    }

}
