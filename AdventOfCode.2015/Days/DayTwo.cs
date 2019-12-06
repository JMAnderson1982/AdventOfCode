namespace AdventOfCode._2015.Days
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode.Shared;

    public class DayTwo : Day
    {
        public DayTwo() : base(2) {}

        public override void TheNeedful()
        {
            var presents = Input.Split("\r\n");

            var surfaceArea = 0;
            var ribbonLength = 0;
            foreach(var presentRaw in presents)
            {
                var dims = presentRaw.Split('x');

                var present = new Present{
                                Length = int.Parse(dims[0]), 
                                Width = int.Parse(dims[1]),
                                Height = int.Parse(dims[2])};

                surfaceArea += present.GetNeededArea();
                ribbonLength += present.GetNeededRibbon();
            }

            PartOne = surfaceArea.ToString();
            PartTwo = ribbonLength.ToString();

        }

        private class Present
        {
            public int Length { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }

            public int GetNeededArea()
            {
                return GetSurfaceArea() + GetSmallestSideArea();
            }

            public int GetSurfaceArea()
            {
                return (Length * Width + Length * Height + Width * Height) * 2;
            }

            public int GetSmallestSideArea()
            {
                return GetVolume() / GetMaxDimension();
            }

            private int GetVolume()
            {
                return Length * Width * Height;
            }

            private int GetMaxDimension()
            {
                return (new int[] { Length, Width, Height }).Max();
            }

            public int GetNeededRibbon()
            {
                return GetVolume() + GetSmallestPerimeter();
            }

            private int GetSmallestPerimeter()
            {
                return 2 * (Length + Width + Height - GetMaxDimension());
            }
        }
    }
}