namespace AdventOfCode.Shared
{   
    using System;
    
    [Obsolete]
    public class Result 
    {
        public string NewPartOne { get; set; }
        public string NewPartTwo { get; set; }
        
        public Result()
        {
            NewPartOne = "--";
            NewPartTwo = "--";
        }
    }
}