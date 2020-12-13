namespace AdventOfCode._2020
{
    using System;
    using System.Linq;
    using AdventOfCode.Shared;

    public class SeatingSystem : Day
    {
        public SeatingSystem() : base(11) {}

        public override void TheNeedful()
        {
            var startTime = DateTime.Now;

            var testResultOne = ArrangeSeats(TestInput);
            if(testResultOne != 37)
            {
                throw new Exception("You suck");
            }
            PartOne = ArrangeSeats(MainInput).ToString();
            
            var midTime = DateTime.Now;
            First = midTime - startTime;


            var testResultTwo = ArrangeSeatsTwo(TestInput);
            if(testResultTwo != 26)
            {
                throw new Exception("You suck (Part Two)");
            }
            PartTwo = ArrangeSeatsTwo(MainInput).ToString();
            Second = DateTime.Now - midTime;
        }

        private int ArrangeSeats(string input)
        {
            var rows = input.Split("\r\n");
            var width = rows.First().Count();
            var length = rows.Count();
            var seatMap = new char[length,width];
            for(var i = 0; i < length; i++)
            {
                for(var j = 0; j < width; j++)
                {
                    seatMap[i,j] = rows[i][j];
                }
            }
            var changes = 1;

            while(changes != 0)
            {
                changes = 0;

                var newSeatMap = new char[length,width];

                for(var i = 0; i < length; i++)
                {
                    for(var j = 0; j < width; j++)
                    {
                        var adjacentCount = 0;
                        switch(seatMap[i,j])
                        {
                            case '.':
                                newSeatMap[i,j] = '.';
                                break;
                            case '#':
                                if( i != 0 && seatMap[i - 1, j] == '#')
                                { adjacentCount++; }
                                if( j != 0 && seatMap[i, j - 1] == '#')
                                { adjacentCount++; }
                                if( i < length - 1 && seatMap[i + 1, j] == '#')
                                { adjacentCount++; }
                                if( j < width - 1 && seatMap[i, j + 1] == '#')
                                { adjacentCount++; }
                                
                                if( i != 0 && j != 0 && seatMap[i - 1, j - 1] == '#')
                                { adjacentCount++; }
                                if( i != 0 && j < width - 1 && seatMap[i - 1, j + 1] == '#')
                                { adjacentCount++; }
                                if( i != length - 1 && j != 0 && seatMap[i + 1, j - 1] == '#')
                                { adjacentCount++; }
                                if( i != length - 1 && j < width - 1 && seatMap[i + 1, j + 1] == '#')
                                { adjacentCount++; }

                                if(adjacentCount >= 4)
                                {
                                    newSeatMap[i,j] = 'L';
                                    changes += 1;
                                }
                                else 
                                {
                                    newSeatMap[i,j] = '#';
                                }
                                break;
                            case 'L':
                                if( i != 0 && seatMap[i - 1, j] == '#')
                                { adjacentCount++; }
                                if( j != 0 && seatMap[i, j - 1] == '#')
                                { adjacentCount++; }
                                if( i < length - 1 && seatMap[i + 1, j] == '#')
                                { adjacentCount++; }
                                if( j < width - 1 && seatMap[i, j + 1] == '#')
                                { adjacentCount++; }
                                
                                if( i != 0 && j != 0 && seatMap[i - 1, j - 1] == '#')
                                { adjacentCount++; }
                                if( i != 0 && j < width - 1 && seatMap[i - 1, j + 1] == '#')
                                { adjacentCount++; }
                                if( i != length - 1 && j != 0 && seatMap[i + 1, j - 1] == '#')
                                { adjacentCount++; }
                                if( i != length - 1 && j < width - 1 && seatMap[i + 1, j + 1] == '#')
                                { adjacentCount++; }

                                if(adjacentCount == 0)
                                {
                                    newSeatMap[i,j] = '#';
                                    changes += 1;
                                }
                                else 
                                {
                                    newSeatMap[i,j] = 'L';
                                }

                                break;
                        }
                    }
                }
                seatMap = newSeatMap;
            }

            return seatMap.Cast<char>().Count(s => s == '#');
        }
        private int ArrangeSeatsTwo(string input)
        {
            var rows = input.Split("\r\n");
            var width = rows.First().Count();
            var length = rows.Count();
            var seatMap = new char[length,width];
            for(var i = 0; i < length; i++)
            {
                for(var j = 0; j < width; j++)
                {
                    seatMap[i,j] = rows[i][j];
                }
            }
            var changes = 1;

            while(changes != 0)
            {
                changes = 0;

                var newSeatMap = new char[length,width];

                for(var i = 0; i < length; i++)
                {
                    for(var j = 0; j < width; j++)
                    {
                        var adjacentCount = 0;
                        switch(seatMap[i,j])
                        {
                            case '.':
                                newSeatMap[i,j] = '.';
                                break;
                            case '#':
                                if( i != 0 && seatMap[i - 1, j] == '#')
                                { adjacentCount++; }
                                if( j != 0 && seatMap[i, j - 1] == '#')
                                { adjacentCount++; }
                                if( i < length - 1 && seatMap[i + 1, j] == '#')
                                { adjacentCount++; }
                                if( j < width - 1 && seatMap[i, j + 1] == '#')
                                { adjacentCount++; }
                                
                                if( i != 0 && j != 0 && seatMap[i - 1, j - 1] == '#')
                                { adjacentCount++; }
                                if( i != 0 && j < width - 1 && seatMap[i - 1, j + 1] == '#')
                                { adjacentCount++; }
                                if( i != length - 1 && j != 0 && seatMap[i + 1, j - 1] == '#')
                                { adjacentCount++; }
                                if( i != length - 1 && j < width - 1 && seatMap[i + 1, j + 1] == '#')
                                { adjacentCount++; }

                                if(adjacentCount >= 5)
                                {
                                    newSeatMap[i,j] = 'L';
                                    changes += 1;
                                }
                                else 
                                {
                                    newSeatMap[i,j] = '#';
                                }
                                break;
                            case 'L':
                                if( i != 0 && seatMap[i - 1, j] == '#')
                                { adjacentCount++; }
                                if( j != 0 && seatMap[i, j - 1] == '#')
                                { adjacentCount++; }
                                if( i < length - 1 && seatMap[i + 1, j] == '#')
                                { adjacentCount++; }
                                if( j < width - 1 && seatMap[i, j + 1] == '#')
                                { adjacentCount++; }
                                
                                if( i != 0 && j != 0 && seatMap[i - 1, j - 1] == '#')
                                { adjacentCount++; }
                                if( i != 0 && j < width - 1 && seatMap[i - 1, j + 1] == '#')
                                { adjacentCount++; }
                                if( i != length - 1 && j != 0 && seatMap[i + 1, j - 1] == '#')
                                { adjacentCount++; }
                                if( i != length - 1 && j < width - 1 && seatMap[i + 1, j + 1] == '#')
                                { adjacentCount++; }

                                if(adjacentCount == 0)
                                {
                                    newSeatMap[i,j] = '#';
                                    changes += 1;
                                }
                                else 
                                {
                                    newSeatMap[i,j] = 'L';
                                }

                                break;
                        }
                    }
                }
                seatMap = newSeatMap;
            }

            return seatMap.Cast<char>().Count(s => s == '#');
        }

        private const string TestInput = @"L.LL.LL.LL
LLLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLLL
L.LLLLLL.L
L.LLLLL.LL";

        private const string MainInput = @"LLLLLLLLLLLLLL...LLL.LLLLLLLLL.LLLLLLLLLLLLLLLLLLL.LLLLLLLL.LLL.LLLLLLLLLLLLLLLLLLL.LLLLLLLLLLLLLL
LLLLLL.LLLLLLLL.L.LL.LLLLLLLLLLLLLLLLLLLLLLLLLLLLL..LLLLLLLLL.LLLLLLL.LLLLLLL.LLLLL.LLLLLLLLLLL.LL
LLLLLL.LLLLLLLL.L.LL.LLLLLLLLLLLL.L.L.LL.LLLLLLLLL.LLLLLL.L.LLLL.LLLL.LLLLLLLLLLLLL.LLLLLLLLLLLLLL
L.LLLL.LLLLLLLL.LLLL.LLLLLL.LLLLLLLLL.LLLLLL.LLLLL.LLLLLLLLLLLLLLLLLLLLLL.LLL.LLLLL.LL.LLLLLLLLLLL
LLL.LL.LLLLLLLLLLLLL..LLLL.LLLLLLLL.L.LLL.LL.LLLLL.LLLLLLLL.LLLLLLLLL.LLLLLLLLLLLLL.LLLLLLLLLLLLLL
L.....LLLLL.LL.L.L..L..L.L..LL...LLLLL.L...L..LLL.L.L..L...LLL.LL.L..LL...L......L.L.L.L.LLLLL....
LLLLLL.LLLLLLLLLLLLL.LLLLLLLLL.LLLLLL.LLLLL.LLLL.LLLLLLLLLL.LL..L.LLL.LLLLLLLLLLLLL.LLLLLLLLLLLLLL
LLLLLL.LLLLLL.L.LLLL.LLLLLLLLL.LLLLLL.LLLLLLLLLLLLLLLLLLLLL.LLLLLLLLL.LLLLLLL.LLLLL.L.L.LLLLLLLLLL
LLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLLLL.LLLLLL.LLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLL.LLLLL.LLLLLLLLLL.LLL
LLLLLL.LLLLLLLLLLLLL.LLLLLLLLL.LLLL.L.LLLLLL.LLLLLLLLLLLLLL.LLLLLLLLL.LLLLLLL.LLLLL.LLLLLLLLLLLLLL
.L.L...L.LL....L.......L...LLL.LL....L.LL.LLL...L........L..L.....L........L.LLL..L..LL.LL........
LLLLLL.LLLLLLLL.LLLL.LLLLLLLL...LLLLL.LLLLLL.LLLLL..LLLLLLLL.LLLLLLLL.L.LLLLL.LLLLL.LLLLLLLLLLLL.L
LLLLLL.LLL.LLLLLLLLL.LLLLLLLLLLLLLLLL.LLLLLL.LLLLL.LLLLLLLLLLLLLLLLLL.LLLLLLL.LLLLL.LLLLLLL.LLLLLL
LLLLLL.LLLLLLLLLLLLLLLLL.LLLLL.LLLLLL.LLLLLL.LLLL..LLLLLLLL.LLLLLLLLL.LLLLLLL.LLLLL.LLLLLLLLLLLLLL
LLLLLL.LLLLLLLL.L.LLLLLLLLLLLL.LLLLLLLLLLLLL.LLLLL.LLLLLLLLLL.LLLLLLL.LLLLLLL.LLLLL.LLLLLLLLLL.LLL
LL.LLL..LLLLLLLLLL.L.LLLLLLLLL.LLLL.L.LLLLLL.LLLLL..LLLLLLLLLLLLLLLLL.LLLLLLL.L.LLL.LLLLLLLLLLLLLL
LLLLLL.LLLLLLLL.LLLL.LLLLLLLLLLLLLLLL.LLLLLLLLLLLLLLLL.LLLLLLL..LLL.L.LLLLLLLLLLLLL.LLLLLLLLLLLLLL
LLLLL.LLLLLLLLLLLLLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLLL.LLLLLLLL.LLLLLLLL.LLLLLLLL.LLLLL.LLLLLLLLLLLLLL
.L.........LL.LL..L..LLLL...L.........L.LLL..L....L....LLL.....L..L.L..L........LL..LL..L.....L...
L.LLLL.LLLLLLLL.LLL..LLLLLLLLLLL.LLL..LLLLLL.LLLLL.LLLLLLLL.L..LLLLLL.LLLLLLLLL.LLL.LLLLLLLLLLLLLL
LLLLLLLLLLLLLLL.LLLL.LLLLLLLLLLLLLLLLLLLLLLL.LLLLL.LLLLLLLL.LLLLLLLLLLLLLLLLLLLLLLL.LLLLLLLLLLLLL.
LLLLLLLLL.LLLLL..LLLLLLLLLLLLLLLLLLLL.LLLLLL.LLLLL.LLLLLLLL.LLLLLLLLLLLLLLLLL.LLLLL.LLLL.LLLLLLLLL
LLLLLL.LLLLLLLLLLLLLLLLLLLLLLL.LLLLLL.LLLLLL.LLLLL.LLLLLLLL.LLL.LLLLL.LLLLLLL.LLLLLLLLL.LLLLLLLLLL
LLLLLL.LLLLLLLLLLLLLLLLLLLLLLL.LLLLLLLLLLLLL.LLLLL.LLLLLLLLLL.LLLLLLL.LLLLLLL.LLLLL.LLLLLLLLLLLLLL
LLL.LL.LLLLLLLL.LLL.LLLLLLLLLLLLLLLLLLLLLLLL.LLL.L.LLLLL.LL.LLLLLLLLL.LLLLLLLLLLLLL.LLLLLLLLLLLLLL
.....L....L.L...LL...LL..L.LL.....L............LL...LL..LL.L.L......LL........L.L..L....L....L..L.
L.LLLLLLLLLLLLLLLLLLLLLLLLLLLL.LLLLLL.LLLLLLLLLLLL.LLLLLLLL.LLLLLLL.L.LLLLLLL.LLLLL.LLLLLLLLLLLLLL
LLLLLLLLLLLLLLL.LLLL.LLLLLLLLL.LLLLLLLLLLLLL.LLLLL.LLLLLLLL..LLLLLLLLLLLLLLLL.LLLLL.LLLLLLLLLLLLLL
LLLLLL.LLLLLLLL.LLLL.LLLLLLLLL.LLLLLL.LLLLLLLLLLLL.LLLLLLLL.LLLLLLLLL.LLLLLLLLLLLLL.L.LLLLLLLLLLLL
L.LLLL..LLLLLLLLLLLLLLLLLLLLLL.LLLLLL.LLLLLLLLLLLLLLLLLLLLL.LLLLLLLLL.LLLLLLL.LLLLL.LLLLLLLLLLLLLL
LLLLLLL..LLLLLL.LLLLLLLLLLLLLLLLLLLLL.LLLLLLLLL.LL.LLLLLLLL.LLLLLLLL.LLLLLLLLLL.LLL.LLLLLLLLLLLLLL
LLLLLL.LLLLL.LLLLLLL.LLLLLLLLL.LLLLLL.LLLLLLLLLLLL.LLLLLLLL.LLLLLLLLL.LLLLLLL.LLLLL.LLLLLLLL.LLLLL
LLLLLLLL.LLLLLL.LLLL.LLLL.LLLL.LLLLL.LLLLLLLLLLLLL.LLLLLLLL.LLLLLLLLL.LLLLL.L.LLLLL.LLLLLLL.LLLLLL
LLLLL..LLLLLLLLLLLLLLLLLLLLL.L.LLLLLL.LLL.LL.LLLLL.LLLLLLLLLLLLLLLLLL.LLLLLLLLLLLLL.LLLLLLLLLLLLLL
L..L.L.L.L........L...L.L..LL....L.....L.L......L..L........LL........L......LL.LLL.L..LL...LL...L
LLLLLL.LLLLLLLL.LLLL.LLLL.LLLL.LLLLLLLLL.LLLLLLLLL.LLLLL.LL.LLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLL
LL.L.LLLLLLLLLL.LLLL.LLL.LLLLLLLLLLLL.LLLLLL.LLLLL..LLLLLLL.LLLLLLLLL.LLL.LLL.LLLLLLLLLLLLLLLLLLL.
LLLLLL.LLLLLLLL.LLLLLLLLLLLLLL.LLLLLL.LLLLLL.LLLLL.LLLLLLLL.LLLLL.LLL.LLLLLLL.LLLLL.LLLLLLLLLLLLLL
LLLLLL.LLLLLLLL.LLLLLLLLLLLLLL.LLLLLLLL.LLLLLLLLLLLLLLLL.LL.LLLLLLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLLLL
LLLLLL.LLLLLLLL.LLLL.LLLLLLLLL.LLLLLLLLLLLLL.LL.LL.LLLLLLLL.LLLLLLLLL.LLLLLLL.LLLLL.LLLLLLLLLLLLLL
LLLLLLLLLLLLLLLLLLLL.LLLLLLLLL.LLLLLL.LLLLLL.LLLLL.LLLLLLLLLLLLLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLL
LLLLLL.LLLLLLLL.LLLL.LLLLLLLLL.LLLLLLLLLLLLL.LLLLL.LLLLLLLL.LLLLLLLLL.LLLLLLLLLLLLL.LLLLLLLLLLLLLL
...LL.LL.L..LL..L.LLL........L...L.......L...L..L.LL.L.......L....L...L.....LLL.L..L.L..L.L..L....
LLLLLL.LLLLLLLL.LLLL.LLLLLLLLLLLLLLLLLLLLLLL.LLLLL.LLLLLL.L.LLLLLLLL..LLLLLLL.LLLLL.LLLLL.LLLLLLLL
LLLLLL.LLLLLLLLLLLLL.LLLLLLLLL.L.LLLL.LLLLLL.L.LLLLLLLLLLLLLLLLLLLL.L.LLLLL.L.LLLLLLLLL.LLLLLLLLLL
L..LLL.LLLLLLLLLLLLL.LLLLLLLLL.LLLLLL.LLLLLL.LLLLL.LLLLLLLL.LLL.LLLLL.LLLLLLLLLLLLLLLLLLLLL.LLLLLL
LLLLLL.LLLLLLLLLLLLL.LLLLLLLLL.LLLLLL.LLLLLL.LLLLL.LLLLLLLL.LLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLL
LLLLLL.LLLLLLLL.LLLL.LLLLLLLLL.LLLLLL..LLLLL.LLLLL.LLLLLLLLLLLLLLLLLL.LLLLLLL.LLLLLLLLLLLLLLLLLLLL
.LLLLL.LLLLLLLL.LLLL.LLLLLLLLLLLLLLLLL.LLLLL.LLLLL.LLLLLLLLLLLLLLLLLL.LLLLLLL.LLLLL.LLLLLLLLLLLLLL
L.LLLL.LLLLLLLL.LLLL.LLLLLLL.L.LLLLL..LLLLLL.LLLLL.LLLLLLLLLL.LLLLLLL.LL.LL.L.LLLLL.LLLLLLLLLLLLLL
LL.L...L.........L..L...LLL......L......L...L..L.L..LL..L.LLL.LL..L.LL..L.L.LL.L.L..LL..........L.
LLLLLLLLLLLLLLL.LLLLLLLLLLLLLL.LLLLLL.LLLLLL.LLLLL.LLLLLLLL.LLLLLL.LLLLLLLLLL.LLLLL.LLLLLLLLLLLLLL
LL.LLL..LLLLLLLLLLLL..LLLLLLLL.LLLLLL.L.LLLL.LLLLLLLLLLLLLL.L.LLLLLLL.LLLLLLL.LLLLLLLLLLLLLLLLLLLL
LLLLLL.LLLLLLLL.LLLL.LLLLLLLLL.LL.LLL.LLLLLL.LLLLL.L.LLLLLL.LLLLLLLLLLLLLL.LLLLLLLL.LLLLLLLLLLLLLL
LLLLL...LLLLLLLLLLLLLLLLLLLLLL.LL.LLL.LLLLLL.LLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLLL.LL.LLLLL.LLLLLLLL
LLLLLLLLLLLLLLL..LLL.LLLLLLLLL.LLLLLL.LLLLLLLLLLL..LLLLLLLL.LLLLLLLLL.LLLLLLL.LLLLL.LLLLLLLLLLLLLL
LLLLLLLLLLLLLL.LL.LLLLLLLLLLLL.LLLLLL.LLLLL..LLLLL.LLLLLLLL.L.LLLLL.L.LLLLLLL.LLLL..LLLLLLLLLLLLLL
LLLLLL.LL.LL.LL.LLLL.LLLLLLLLL.LLL.LL.LLL.LL.LLLLL.LLLLLLLL.LLLLLLLLL.LLLLLLL.LLLLL.LLLLLLLLLLLLLL
L.LLLL.L.LLLLLL.LLLLLLLLLLLLLL.L.LLLL.LLLLLL.LLLLL.LLLLLLLL.LLLLLLLLL.LLL.LL..LLLLL.LLLLLLLLLLLL.L
..L.....LLLL..L..L......LL.L.......L..LLL..L..L..LL.LLL....L..L.L..L...L.LL..L...L.L.......L......
LLLLLL.LLLLLLLL..L.LLLLLLLLLLLLLLLLLL.LLLLLL.LLLLL.LLLLLLLL.LL.LLLLLL.LLLLLLL.LL.LL.LLLLLLLLLLLLLL
LLLLLL.LLLLLLLLLLLLL.LLL.LLLLL.LLLLLLLLLLLLL.LLLLLLLLLLLLLL.LLLLLLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLLLL
LLLLLL.LLLLLLLL.LLLL.LLLLLLL.L.LLLL.LL.LLLLL.LLLL..LLLLLLLL.LLLLLLLLL.LLLLLLL.L.LLL.LLLLLLLLLLLLLL
LLLLLLLLLLLLLLL.LLLLLLLLLLLLLL.LLLLLL.LLLLLL.LLLLL.LLLLLLLLLLLLLLLLLL.LLLLLL..LLLLL.LLL.LLLLLL.L.L
LLL.LLLLLLLLLLL.LLLLLLLLLLLLLL.LLLLLL.LLLLLLL.LLLL.LLLLLLLL.LLL.LL.LL.LLLLLLL.LLLLL.LLLLLLLLLLLLLL
LLLLL..LLLLLLLL.LL.LLLLLLLLLLL.LLLLLL.LLLLLL.L.LLL.LLLLLLLLLLLLLLLLLL.LLLLLLLLLLLLL.LLLLLLLLLLLLLL
L..L...L.L.L....L....L.LLLL.L.....L..LL...L...L..LLL.L......LL...L..LLL..L.L..L....L.L.L...L..LL.L
LLLLLLLLLLLLLLL.LLLLLLLLLLLLL.LLLLLLLLLLLLLL..LLLL.LL.LLLLL.LLLLLLLL.LLLLLLLL.LLLLLLLLLLLLLLLLL.LL
LLLLLLLLLLLLLLL.LLLL.LLL.LLL.LLLLLLLLLLLLLLL.LLLLL.LLL.LLLL.LLLLLLLLL.LLLLLLL.LLLLL.LLLLLLLLLL.L.L
LLLLLL.LLL.LLLLL.LLL.L.LLLLLLL.LLLLLL.LLLLLL.LLLLL.LLLLLLLLLL.LL.LLL..LLLLLLL.LLLLL.LLLLL.LLLLLLLL
LLLLLL.LLLLLLLLLLLLL.LLLL.L.L..LLLLLLLLLLLLL.LLLLL.LLLLLLLLL.LLLLLLLL.LLLLLLL.LLLLL.LLLLLLLLLLLLLL
LLLLLLLLLLLLLLL.LLLL.LLLLLLLLL.LLLLLL.LLL.LLLLLL.LLLLLLLLLL.LL.LLLLLL.LL.LLLL.LLLLL.LLLLLLLL.LLL.L
.LLL.LLLLLLLL.L.LLLLLLLLLLLLLL.LLLLLL.LLLLLL.LLLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL
LLLLLL.LLLLLLLLLLLLL.LLLLLLLLL.LLLLLLLLLLLLL.LLLLL.LLLLLLLLLL.LLLLLLL..LLLLLL.LLLL.LLLLLLLLLLLLLLL
LL.LLL.L.LL.LLLL.....L...LL..L....LL.LLL.....L..L..L..L.............L.L.....L......LLL.L.....L.LL.
LLLLLL.LLLLLLLL.LLLLLLLLLLLLLLLLLLLLL.LLLLLL.LLLLL.LLLLLLLLLLLLLLLLLL.LLLLLLL.LLLLLLLLLLLLLL.LLLLL
LLLLLL.L.LLLLLL.LLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL.LLLL.LLLLLLLLLLLLLLL
LLLLLL.L.LLLLLL.LLLL.L.LLLLLLL.LLLLLLLLLLLLL.LLLLL.LLLLLLLL.LLLLLLLLL.LLLLLLL.LL.LLLLLLLLLLLLLLLLL
LLL.LLLLLLLL.LL.LLLL.LLLLLLLLL.LLLLLLLL..LLL.LLLLL.LLL.LLLL.LLLLLLLLL.LLLLLLL.LLLLL.LLLLLLLLLLLLLL
LLLLLLLLLLLLLLL.LLLLLLL.LLLLLL..LLLLLLLLLLLL.LLLLLLLLLLLLLL.LLL..LLLL.LLLLLLL.LLLLLLLLLLLLLLLLLLLL
.L....L...L.....LL.L..LL.L.L..LLL..L...L......LL..L..L.LL..L..LLLL..L...LLL.L.LLL.L.L...LL..L.L...
LLLLLL..LLLLLLLL.L.LLLLLLL.LLL..LLLLL.LLLLLL.LLLLLLLLLLLLLLLLLLLLLLLL.LLLLLL.LLLLLL.LLLLLLLLLL.LLL
LLLLLL.LLLLLLLL.LLLL.LLLLLLLLL.LLLLLL.LLLLLL.LLLLL.LLLLLLLL.LLLLLLLLL.LLLLLLL.LLLLL.LLLLLLLLLLLLLL
LLLLLL.LLLLLLLL.LLLL.LLLLLLLLLLLLLLLL.LL.L.LLLLLLL.LLLLLLLLLLLLLLLLLLL.LLLLLLLLLLLL.LLLLLLLLLLLLLL
LLLLLL.LLLLLLLL.LLLLLLLLLLLLLL.LLLLLL.LLLLLL.LL...LLL.LLLLL.LLLLLLLLLLLLLLLLL.LLLLL.LLLLLLLLLLLLL.
LLLL.L.LLLLLLLLLLL.L.LLLLL..LL.LLL.LL.LL.LLL.LLLLLLLLLLLLLLLLLLLLLLLL.LLLLLLL.LLLLL.LLLLLLLLLLLLLL
LLLLLL.LLLLLLLL.LLLL.LLLLLLLLL.LLLLLLLLLL.LL.LLLLL.LLLLLLLL.LLLLLLLLLLLL..LLL.LLLLL.LLLLLLLLLLL.LL
L.L.L.L.LL...L....L.L.L...L.L.....L....LL..L.L....LL..LL..L.......................L.L...L..L..L...
LLLLLL.LLLLLLLL.LLLLLLLLLLLL.L.LLLLLLLLLLLLL.L.LLLLLLLLLLLLLLLLLLLLLL.LLLLLL.LLLLLLLLLLLLLLLLLLLLL
LLLLLL.LL.LLLLL.LLL.LLL.LLLLL..LLL.LL.LLLLLL.LLLL..LLLLLL.L.LLLLLLLLLLLLLLLLL.LLLLL.LLLLLLLLLLLLLL
.LLLLL.LLLLLLLL.L.LL.LLLLL.LL.LLLLLLL.LLLLLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL.LLL
LLLLLLLLLLLLLLLLLLLLLLLLLLLLLL.LLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL.LLLLLL.LLLLLLLLLLLLLL
LLLLLLLLLLLLLLLLLLLL..LLLLL.LL.LLLLLL..LLLLL.LLLL.LLLLLLL.L.LLLLLLLLL.LLLLLLLLLLLLL..LLLLLLLLLLLLL
LLLLLLLLLLLLL.LLLLLL..LLLLLLLL.LLLLLL.LLLLLL.LLLLL.LLLLLLLLLLLLLLLLL.LLLLLLL.LLLLLL.LL.LLLLLL.LLLL
LLLLLL.LLLLLLLL.LLLLLLLLLLLLLLLLLLLLL.LLLLLL.LLLLLLLLLLLLLLLLLLLLLLLL.LLLLLLL.LLLLL.LLLLLLLLLLLLLL
LLLLLL.LLLLLLLL.LLLL.LLLLLLLLLLLLLLLL.LLLLLLLLLLLL..LLLLLLL.LLLLLLLLL.LLLLLLLLLLLLL.LLLLLLLLLLLLLL
LLLLLL.LLLLLLLL.LLLLLLLLL.LLLL.LLLLLLLLLLLLL.LLLLLLLLLLL..L.LLLLLLLLL.LLLL.LL.L..LL.LLLLLLLLLLLLLL";
    }
}