namespace AdventOfCode.Shared
{
    public abstract class Day
    {
        public string PartOne { get; set; }
        public string PartTwo { get; set; }
        public string Input { get; set; }
        public int Date { get; set; }

        public Day()
        {
            PartOne = "--";
            PartTwo = "--";

            ResetInput();

            TheNeedful();
        }
        public virtual void TheNeedful()
        {

        }

        public void ResetInput()
        {
            var dayAsString = this.GetType().Name;
            try{
                Input = System.IO.File.ReadAllText($"Input/{dayAsString}.txt");
            }
            catch {}
        }
    }
}