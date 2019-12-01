namespace AdventOfCode._2019.Days
{
    using System;
    using AdventOfCode.Shared;

    class DayOne
    {
        public static Day GetDay()
        {
            var day = new Day();
            
            var masses = System.IO.File.ReadAllText("Input/DayOne.txt").Split("\r\n");

            var fuelForRawMass = 0;
            var totalFuel = 0;

            foreach( var massString in masses)
            {
                var mass = int.Parse(massString);

                fuelForRawMass += mass / 3 - 2;
                totalFuel += GetFuelForMass(mass);
            }

            day.NewPartOne = fuelForRawMass.ToString();
            day.NewPartTwo = totalFuel.ToString();
            return day;
        }

        private static int GetFuelForMass(int mass)
        {
            var fuel = mass / 3 - 2;

            if(fuel < 0)
            {
                return 0;
            }

            return fuel + GetFuelForMass(fuel);
        }
    }    
}