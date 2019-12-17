namespace AdventOfCode._2019.Days
{
    using AdventOfCode._2019.Components;
    using AdventOfCode.Shared;
    class DayFourteen : Day
    {
        public DayFourteen() : base(14) { }

        public override void TheNeedful()
        {
            var refinery = new Refinery();
            refinery.LoadReactions(Input);
            refinery.MakeFuel();

            PartOne = refinery.OreConsumed.ToString();

            refinery.Reset();
            
            PartTwo = refinery.GetMaxFuelFromOre(1000000000000).ToString();;
            
        }
    }
}