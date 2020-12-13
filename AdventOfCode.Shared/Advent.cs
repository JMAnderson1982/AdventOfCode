using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Shared
{

    public class Advent
    {
        public List<Day> Days { get; set; }
        
        public int Year { get; set; }

        public Advent()
        {
            Days = new List<Day>();
        }

        public void ShowResults()
        {
            Console.WriteLine($"\t\tAdvent of Code {Year}\n{"Part One".PadLeft(18)}{"Part Two".PadLeft(30)}\n");   
            
            foreach(var day in Days.OrderBy(d => d.Date))
            {
                if(day == null) { continue; }

                Console.WriteLine($"{day.Date.ToString().PadLeft(2)}{day.PartOne.ToString().PadLeft(12)} ({day.First.TotalMilliseconds.ToString().PadLeft(7)}ms) {day.PartTwo.ToString().PadLeft(17)} ({day.Second.TotalMilliseconds.ToString().PadLeft(7)}ms)");
            }
        }
    }
}
