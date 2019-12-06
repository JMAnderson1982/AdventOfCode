namespace AdventOfCode._2019.Days
{
    using AdventOfCode.Shared;
    class DayFour : Day
    {
        public DayFour() : base()
        {
            Date = 4;
        }

        public override void TheNeedful()
        {
            var min = 402328;
            var max = 864247;

            var validCount = 0;
            var limitedValidCount = 0;

            for( int i = min; i <= max; i++)
            {
                var asString = i.ToString();

                if(!(asString[0] != asString[1] 
                    && asString[1] != asString[2] 
                    && asString[2] != asString[3]
                    && asString[3] != asString[4]
                    && asString[4] != asString[5])
                    && asString[0] <= asString[1]
                    && asString[1] <= asString[2]
                    && asString[2] <= asString[3]
                    && asString[3] <= asString[4]
                    && asString[4] <= asString[5]
                    )
                    { validCount++; }
                
                if(
                    HasExactDuplicate(asString)
                    && asString[0] <= asString[1]
                    && asString[1] <= asString[2]
                    && asString[2] <= asString[3]
                    && asString[3] <= asString[4]
                    && asString[4] <= asString[5])  
                    { limitedValidCount++; }
            }
            PartOne = validCount.ToString();
            PartTwo = limitedValidCount.ToString();

        }

        public bool HasExactDuplicate(string input)
        {
            for(int i = 0; i < 10; i++)
            {
            var letter = i.ToString();

            if(input.Contains($"{letter}{letter}")
                && !input.Contains($"{letter}{letter}{letter}"))
                {return true;}
            }
            return false;
  }

        public override void SetInput()
        {
            return;
        }
    }
}