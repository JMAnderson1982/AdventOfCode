namespace AdventOfCode._2019.Days
{
    using System;
    using AdventOfCode.Shared;

    class DayOne : Day
    {
        public DayOne() :base(1) {}
        
        public override void TheNeedful()
        {
            var masses = Input.Split("\n");
            
            var fuelForRawMass = 0;
            var totalFuel = 0;

            foreach( var massString in masses)
            {
                if(massString == string.Empty) {continue;}
                var mass = int.Parse(massString);

                fuelForRawMass += mass / 3 - 2;
                totalFuel += GetFuelForMass(mass);
            }

            PartOne = fuelForRawMass.ToString();
            PartTwo = totalFuel.ToString();
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