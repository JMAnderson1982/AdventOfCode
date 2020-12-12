namespace AdventOfCode._2020
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode.Shared;

    public class AdapterArray : Day
    {
        public AdapterArray() : base(10) {}

        public override void TheNeedful()
        {
            var testValue = FirstPart(TestInput);
            if(testValue != 220)
            {
                throw new Exception($"you suck ({testValue})") ;
            }
            var firstValue = FirstPart(MainInput);
            PartOne = firstValue.ToString();

            var secondTestValue = SecondPart(TestInput);
            if(secondTestValue != 62)
            {
                throw new Exception("you suck (Part two!)") ;
            }
            PartTwo = SecondPart(MainInput).ToString();
        }

        private int FirstPart(string input)
        {
            var adapters = input.Split("\r\n").Select(i => int.Parse(i)).OrderBy(i => i).ToList();
            adapters.Insert(0,0);
            var differenceOfOne = 0;
            var differenceOfThree = 1;
            // switch(adapters[0])
            // {
            //     case 1:
            //         differenceOfOne++;
            //         break;
            // }
            for(var i = 0; i < adapters.Count() - 1; i++)
            {
                var diff = adapters[i + 1] - adapters[i];
                switch(diff)
                {
                    case 1:
                        differenceOfOne++;
                        break;
                    case 3:
                        differenceOfThree++;
                        break;
                }
            }

            return differenceOfOne * differenceOfThree;
        }

        private int SecondPart(string input)
        {
            throw new NotImplementedException();
        }

        private const string TestInput = @"28
33
18
42
31
14
46
20
48
47
24
23
49
45
19
38
39
11
1
32
25
35
8
17
7
9
4
2
34
10
3";

        private const string MainInput = @"26
97
31
7
2
10
46
38
112
54
30
93
18
111
29
75
139
23
132
85
78
99
8
113
87
57
133
41
104
98
58
90
13
91
20
68
103
127
105
114
138
126
67
32
145
115
16
141
1
73
45
119
51
40
35
150
118
53
80
79
65
135
74
47
128
64
17
4
84
83
147
142
146
9
125
94
140
131
134
92
66
122
19
86
50
52
108
100
71
61
44
39
3
72";
    }
}
