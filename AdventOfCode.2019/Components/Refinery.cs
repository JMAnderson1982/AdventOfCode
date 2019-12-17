namespace AdventOfCode._2019.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Refinery
    {
        public List<Reaction> Reactions { get; set; } = new List<Reaction>();
        public Supplies Storage { get; set; } = new Supplies();
        public long OreConsumed { get; set; } = 0;

        public void LoadReactions(string input)
        {
            var lines = input.Split("\n");

            foreach(var line in lines)
            {
                var stuffs = line.Split(" => ");
                
                stuffs[0].Split(", ").ToDictionary(s => s.Split(" ")[1]);
                
                var reaction = new Reaction{
                    Result = new Tuple<string,long>(stuffs[1].Split(" ")[1], int.Parse(stuffs[1].Split(" ")[0])),
                    Reagents = stuffs[0].Split(", ").ToDictionary(s => s.Split(" ")[1], s => long.Parse(s.Split(" ")[0]))
                };

                Reactions.Add(reaction);
            }

            
        }

        public long GetMaxFuelFromOre(long v)
        {
            Reset();
            MakeFuel(1);
            var orePerFuel = OreConsumed;
            Reset();
            while(OreConsumed < v - orePerFuel)
            {    
                var oreLeft = v - OreConsumed;
                //MakeFuel(Storage["FUEL"] + 1);
                MakeFuel(Math.Max((Storage["FUEL"] + oreLeft / orePerFuel),1));
                
            }
            return Storage["FUEL"];
        }

        public void Reset()
        {
            Storage = new Supplies();
            OreConsumed = 0;
        }

        public void MakeFuel(long desired = 1)
        {
            MakeReagent("FUEL", desired);
        }

        public void MakeReagent(string name, long amount)
        {
            if(name == "ORE")
            {
                Storage["ORE"] += amount;
                OreConsumed += amount;
                return;
            }

            var reaction = Reactions.FirstOrDefault(r => r.Result.Item1 == name);

            var needed = amount - Storage[name];

            if(needed > 0)
            {
                var reactionCount = Math.Max((long)Math.Ceiling((double)needed / (double)reaction.Result.Item2),1);
                foreach(var reagent in reaction.Reagents)
                {
                    MakeReagent(reagent.Key, reagent.Value * reactionCount);
                    Storage[reagent.Key] -= reagent.Value * reactionCount;
                }
                Storage[name] += reaction.Result.Item2 * reactionCount;
            }

            

            // while(Storage[name] < amount)
            // {
            //     foreach(var reagent in reaction.Reagents)
            //     {
            //         MakeReagent(reagent.Key, reagent.Value);
            //         Storage[reagent.Key] -= reagent.Value;
            //     }
            //     Storage[reaction.Result.Item1] += reaction.Result.Item2;
            // }
        }

        public class Supplies
        {
            public Dictionary<string, long> Materials { get; set; } = new Dictionary<string, long>();

            public long this[string key]
            {
                get { return Materials.ContainsKey(key) ? Materials[key] : 0;}
                set { Materials[key] = value; }
            }
        }

        public class Reaction
        {
            public Dictionary<string, long> Reagents { get; set; }
            public Tuple<string, long> Result  {get; set; }
        }
    }
}