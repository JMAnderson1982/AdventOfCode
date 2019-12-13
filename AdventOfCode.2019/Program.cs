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

            advent.Days.Add(new DayOne());
            advent.Days.Add(new DayTwo());
            advent.Days.Add(new DayThree());
            advent.Days.Add(new DayFour());
            advent.Days.Add(new DayFive());
            advent.Days.Add(new DaySix());
            advent.Days.Add(new DaySeven());
            advent.Days.Add(new DayEight());
            advent.Days.Add(new DayNine());

            advent.Days.Add(new DayEleven());
            advent.Days.Add(new DayTwelve());
            advent.Days.Add(new DayThirteen());


            advent.ShowResults();
            Console.WriteLine($"\n{(DateTime.Now - now).TotalMilliseconds}ms");
        }
    }

}
