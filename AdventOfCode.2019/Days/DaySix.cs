namespace AdventOfCode._2019.Days{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode.Shared;

    public class DaySix : Day
    {
        public DaySix() : base()
        {
            Date = 6;
        }

        public override void TheNeedful()
        {
            // var defs = TestMap.Split("\r\n");
            // var defs = TestMap2.Split("\r\n");
            var defs = Input.Split("\r\n");

            var map = new Map();

            foreach( var def in defs ) 
            {
                var objects = def.Split(')');
                map.Orbits.Add( new Orbit{ Name = objects[1], ParentName = objects[0]});
            }
            map.Link();

            PartOne = map.GetOrbitalCount().ToString();
            PartTwo = map.GetTransferCount("YOU", "SAN").ToString();
        }

        private class Map
        {
            public List<Orbit> Orbits { get; set; }

            public Orbit Center { get; set; }

            public Map()
            {
                Orbits = new List<Orbit>();
            }

            public void Link(){
                foreach(var orbit in Orbits)
                {
                    var parent = Orbits.FirstOrDefault(o => o.Name == orbit.ParentName);
                    if(parent == null)
                        parent = Center = new Orbit{Name = orbit.ParentName, Distance = 0};
                    orbit.Parent = parent;
                }

                foreach(var orbit in Orbits)
                {
                    if(orbit.Distance == null)
                        orbit.Distance = 1 + GetDistance(orbit.Parent);
                }
            }

            public int GetDistance(Orbit orbit)
            {
                return orbit.Distance != null ? (int)orbit.Distance : GetDistance(orbit.Parent) + 1;
            }

            public int GetOrbitalCount()
            {
                return Orbits.Sum(o => o.Distance ?? 0);
            }

            public int GetTransferCount(string source, string dest)
            {
                var sourceNode = Orbits.FirstOrDefault(o => o.Name == source).Parent;
                var destNode = Orbits.FirstOrDefault(o => o.Name == dest).Parent;
                var commonNode = FindFirstCommonNode(sourceNode, destNode);

                return (int)sourceNode.Distance + (int)destNode.Distance - 2 * (int)commonNode.Distance;
            }

            private Orbit FindFirstCommonNode(Orbit source, Orbit dest)
            {
                var sourceTree = new List<Orbit>{source};

                while(sourceTree.Last().Parent != null)
                {
                    sourceTree.Add(sourceTree.Last().Parent);
                }

                while(dest.Parent != null)
                {
                    if(sourceTree.Contains(dest))
                    {
                        return dest;
                    }
                    dest = dest.Parent;
                }
                throw new Exception("Shits fucked yo");
            }
        }

        private class Orbit
        {
            public string Name { get; set; }

            public string ParentName { get; set; }

            public Orbit Parent { get; set; }

            public int? Distance { get; set; }
        }

        private string TestMap => @"COM)B
B)C
C)D
D)E
E)F
B)G
G)H
D)I
E)J
J)K
K)L";
    

    private string TestMap2 => @"COM)B
B)C
C)D
D)E
E)F
B)G
G)H
D)I
E)J
J)K
K)L
K)YOU
I)SAN";
    }
}