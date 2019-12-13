namespace AdventOfCode._2019.Days
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode._2019.Components;
    using AdventOfCode.Shared;
    class DayThirteen : Day
    {
        public DayThirteen() : base(13) { }

        public override void TheNeedful()
        {
            var arcade = new Arcade();
            arcade.Computer.LoadProgram(Input);
            arcade.Run();
            
            PartOne = arcade.TileTypeCount(Arcade.Type.Block).ToString();
            
            arcade = new Arcade();
            arcade.Computer.LoadProgram(Input);
            arcade.FreePlay();
            arcade.Run();
            
            PartTwo = $"{arcade.Score.ToString()} - {arcade.TileTypeCount(Arcade.Type.Block).ToString()} blocks left";
        }
    }
}