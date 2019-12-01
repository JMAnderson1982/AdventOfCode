﻿using System;

namespace AdventOfCode.Shared
{

    public class Advent
    {
        public Result[] Days { get; set; }

        public int Year { get; set; }

        public Advent()
        {
            Days = new Result[25];
        }

        public void ShowResults()
        {
            Console.WriteLine($"\t\tAdvent of Code {Year}");
            
            var i = 1;

            foreach(var day in Days)
            {
                if(day == null) { continue; }

                Console.WriteLine($"{i}\t{day.NewPartOne}\t{day.NewPartTwo}");
                
                i++;
            }
        }
    }
}