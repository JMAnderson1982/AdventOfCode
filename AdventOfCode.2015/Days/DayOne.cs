namespace AdventOfCode._2015.Days
{
    using System;
    using AdventOfCode.Shared;

    class DayOne
    {
        public static Result GetDay()
        {
            var day = new Result();
            var elevator = new Elevator();
            var commands = System.IO.File.ReadAllText("Input/DayOne.txt");

            elevator.parseCommands(commands);

            day.NewPartOne = elevator.Floor;
            day.NewPartTwo = elevator.BasementIndex;

            return day;
        }

        private class Elevator
        {
            private int __floor;

            public string Floor => __floor.ToString();

            public int __basementIndex;

            public string BasementIndex => __basementIndex.ToString();

            public Elevator()
            {
                __floor = 0;
                __basementIndex = 0;
            }


            public void parseCommands(string input)
            {
                int i = 0;
                foreach(var command in input)
                {
                    i++;
                    switch(command)
                    {
                        case '(':
                            __floor++;
                            break;
                        case ')':
                            __floor--;
                            break;
                        default:
                            throw new ArgumentException($"Invalid character in input: {command}");
                    }

                    if(__basementIndex == 0 && __floor < 0)
                    {
                        __basementIndex = i;
                    }
                }
            }
        }
    }    
}