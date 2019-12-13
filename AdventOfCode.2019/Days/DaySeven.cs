namespace AdventOfCode._2019.Days
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode._2019.Components;
    using AdventOfCode.Shared;
    using AdventOfCode.Shared.Extensions;

    class DaySeven : Day
    {
        public DaySeven() : base(7) {}

        public override void TheNeedful()
        {
            //Input = "3,15,3,16,1002,16,10,16,1,16,15,15,4,15,99,0,0";
            var computer = new Computer();
            computer.LoadProgram(Input);
            
            var output = computer.Run(new List<long> {4,0});
            computer.LoadProgram(Input);
            output = computer.Run(new List<long> {3,output[0]});
            computer.LoadProgram(Input);
            output = computer.Run(new List<long> {2,output[0]});
            computer.LoadProgram(Input);
            output = computer.Run(new List<long> {1,output[0]});
            computer.LoadProgram(Input);
            output = computer.Run(new List<long> {0,output[0]});

            PartOne = Amplify(GetPhases(), 0).ToString();

            var thrust = AmplifyFeedback(new List<long> {5,6,7,8,9});
            PartTwo = thrust.ToString();
        }

        public long Amplify(List<long> phases, long input)
        {
            var computer = new Computer();
            long max = input;
            for(int i = 0; i < phases.Count; i++)
            {
                var deltaPhases = new List<long>(phases);
                computer.LoadProgram(Input);
                var output = computer.Run(new List<long> {phases[i],input});
                deltaPhases.Remove(phases[i]);
                var nextPhase = Amplify(deltaPhases, output[0]);
                if(max < nextPhase)
                {
                    max = nextPhase;
                }
            }
            return max;
        }

        public long AmplifyFeedback(List<long> phases)
        {
            long max = 0;
            foreach(var phaseSet in Computer.GetPermutations(phases))
            {
                var ampA = new Computer();
                var ampB = new Computer();
                var ampC = new Computer();
                var ampD = new Computer();
                var ampE = new Computer();
                ampA.LoadProgram(Input);
                ampB.LoadProgram(Input);
                ampC.LoadProgram(Input);
                ampD.LoadProgram(Input);
                ampE.LoadProgram(Input);
                var inputA = new List<long> {phaseSet[0],0};
                var inputB = new List<long> {phaseSet[1]};
                var inputC = new List<long> {phaseSet[2]};
                var inputD = new List<long> {phaseSet[3]};
                var inputE = new List<long> {phaseSet[4]};
                try{
                while(true)
                {
                inputB.Add(ampA.Run(inputA).Last());
                inputC.Add(ampB.Run(inputB).Last());
                inputD.Add(ampC.Run(inputC).Last());
                inputE.Add(ampD.Run(inputD).Last());
                inputA.Add(ampE.Run(inputE).Last());
                }
                }
                catch {
                    var thrust = inputA.Last();
                    if(max < thrust)
                    {
                        max = thrust;
                    }
                }
            }
            return max;
        }

        public static List<List<int>> GetPermutations(List<int> list)
        {
            var permutations = new List<List<int>>();
            for(int i = 0; i < list.Count; i++)
            {
                var first = list[i];
                var subList = new List<int>(list);
                subList.Remove(first);
                var newList = GetPermutations(subList);
                newList.ForEach(l => l.Add(first));
                permutations.AddRange(newList);
            }
            if(permutations.Count() == 0)
            {
                permutations.Add(new List<int>());
            }
            return permutations;
        }

        public List<long> GetPhases()
        {
            return new List<long> {0,1,2,3,4};
        }
    }
}