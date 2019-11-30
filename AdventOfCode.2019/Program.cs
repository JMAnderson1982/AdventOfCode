namespace AdventOfCode._2019
{

    using AdventOfCode._2019.Days;
    using AdventOfCode.Shared;
    class Program
    {
        static void Main(string[] args)
        {
            var advent = new Advent{ Year = 2019 };
            
            advent.Days[0] = DayOne.GetDay();
            // advent.Days[1] = DayTwo.GetDay();
            // advent.Days[2] = DayThree.GetDay();

            advent.ShowResults();
        }
    }

}
