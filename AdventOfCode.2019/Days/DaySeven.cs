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
            
            var output = computer.Run(new List<int> {4,0});
            computer.LoadProgram(Input);
            output = computer.Run(new List<int> {3,output[0]});
            computer.LoadProgram(Input);
            output = computer.Run(new List<int> {2,output[0]});
            computer.LoadProgram(Input);
            output = computer.Run(new List<int> {1,output[0]});
            computer.LoadProgram(Input);
            output = computer.Run(new List<int> {0,output[0]});
            
            Console.WriteLine(output[0].ToString());

            PartOne = Amplify(GetPhases(), 0).ToString();

            var thrust = AmplifyFeedback(new List<int> {5,6,7,8,9});
            PartTwo = thrust.ToString();
            Console.WriteLine(thrust);
        }

        public int Amplify(List<int> phases, int input)
        {
            var computer = new Computer();
            int max = input;
            for(int i = 0; i < phases.Count; i++)
            {
                var deltaPhases = new List<int>(phases);
                computer.LoadProgram(Input);
                var output = computer.Run(new List<int> {phases[i],input});
                deltaPhases.Remove(phases[i]);
                var nextPhase = Amplify(deltaPhases, output[0]);
                if(max < nextPhase)
                {
                    max = nextPhase;
                }
            }
            return max;
        }

        public int AmplifyFeedback(List<int> phases)
        {
            int max = 0;
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
                var inputA = new List<int> {phaseSet[0],0};
                var inputB = new List<int> {phaseSet[1]};
                var inputC = new List<int> {phaseSet[2]};
                var inputD = new List<int> {phaseSet[3]};
                var inputE = new List<int> {phaseSet[4]};
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

        public List<int> GetPhases()
        {
            return new List<int>{0,1,2,3,4};
        }
    }
}