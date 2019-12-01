using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Shared
{

    public class Advent
    {
        public List<Day> NewDays { get; set; }
        
        public int Year { get; set; }

        public Advent()
        {
            NewDays = new List<Day>();
        }

        public void ShowResults()
        {
            Console.WriteLine($"\t\tAdvent of Code {Year}");   
            
            foreach(var day in NewDays.OrderBy(d => d.Date))
            {
                if(day == null) { continue; }

                Console.WriteLine($"{day.Date}\t{day.PartOne}\t{day.PartTwo}");
            }
        }
    }
}
