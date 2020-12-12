﻿namespace AdventOfCode._2020
{
    using System;
    using AdventOfCode.Shared;

    class Program
    {
        static void Main(string[] args)
        {
            var advent = new Advent{ Year = 2019 };

            advent.Days.Add(new EncodingError());
            advent.Days.Add(new AdapterArray());
            advent.Days.Add(new SeatingSystem());
            advent.Days.Add(new RainRisk());
            
            advent.ShowResults();
        }
    }
}
