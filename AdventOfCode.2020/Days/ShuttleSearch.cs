namespace AdventOfCode._2020
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode.Shared;

    public class ShuttleSearch : Day
    {
        public ShuttleSearch() : base(13) {}

        public override void TheNeedful()
        {
            var startTime = DateTime.Now;
            
            var testValue = FirstPart(TestInput);
            if(testValue != 295)
            {
                throw new Exception($"you suck ({testValue})") ;
            }
            var firstValue = FirstPart(MainInput);
            PartOne = firstValue.ToString();

            var midTime = DateTime.Now;
            First = midTime - startTime;

            var secondTestValue = SecondPart(TestInput) ;
            if(secondTestValue != 1068781)
            {
                throw new Exception($"you suck (Part two!) {secondTestValue}") ;
            }
            PartTwo = SecondPart(MainInput).ToString();
            Second = DateTime.Now - midTime;
        }

        private long FirstPart(string input)
        {
            var earliest = int.Parse(input.Split("\r\n").First());
            var trains = input.Split("\r\n").Last().Split(',').Where(s => s != "x").Select(s => int.Parse(s));

            var soonest = new Tuple<int,int>(earliest * 2,0);
            foreach (var train in trains)
            {
                var nextTimestamp = (earliest / train + 1) * train;
                if(nextTimestamp < soonest.Item1)
                { 
                    soonest = new Tuple<int,int>(nextTimestamp, train);
                }
            }

            return (soonest.Item1 - earliest) * soonest.Item2;
        }

        private long SecondPart(string input)
        {
            var raw = input.Split("\r\n").Last().Split(',');
            var trains = new Dictionary<long, long>();
            long counter = 0;
            foreach(var entry in raw)
            {
                if(entry != "x")
                {
                    trains.Add(counter, long.Parse(entry));
                }
                counter++;
            }

            long increment = 1;
            long timestamp = 0;

            foreach( var s in trains)
            {
                while(true)
                {
                    if( (timestamp + s.Key) % s.Value == 0)
                    {
                        increment *= s.Value;
                        break;
                    }

                    timestamp += increment;
                }
            }
           
            return timestamp;

            throw new Exception("Uh oh");
        }
        private const string TestInput = @"939
7,13,x,x,59,x,31,19";

        private const string MainInput = @"1000417
23,x,x,x,x,x,x,x,x,x,x,x,x,41,x,x,x,37,x,x,x,x,x,479,x,x,x,x,x,x,x,x,x,x,x,x,13,x,x,x,17,x,x,x,x,x,x,x,x,x,x,x,29,x,373,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,19";
    }
}