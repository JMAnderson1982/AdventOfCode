namespace AdventOfCode._2019.Days
{
    using System.Linq;
    using AdventOfCode.Shared;
    class DayFour : Day
    {
        public DayFour() : base(4) { }

        public override void TheNeedful()
        {
            var min = 402328;
            var max = 864247;

            var validCount = 0;
            var limitedValidCount = 0;

            for( int i = min; i <= max; i++)
            {
                var asString = i.ToString();

                if( IsAscending(asString) )
                {
                    if( HasDuplicate(asString) )
                    { validCount++; }
                
                    if( HasExactDuplicate(asString) )  
                    { limitedValidCount++; }
                }
            }

            PartOne = validCount.ToString();
            PartTwo = limitedValidCount.ToString();
        }

        public bool IsAscending(string input)
        {
            int last = 0;

            foreach( var c in input)
            {
                var digit = (int)char.GetNumericValue(c);
                if(digit < last)
                    return false;
                last = digit;
            }
            return true;
        }

        public bool HasDuplicate(string input)
        {
            return input.ToCharArray().GroupBy(i => i).Any(g => g.Count() >= 2);
        }

        public bool HasExactDuplicate(string input)
        {
            return input.ToCharArray().GroupBy(i => i).Any(g => g.Count() == 2);
        }

        public override void SetInput()
        {
            return;
        }
    }
}