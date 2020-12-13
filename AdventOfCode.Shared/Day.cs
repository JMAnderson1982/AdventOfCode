using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdventOfCode.Shared
{
    public abstract class Day
    {
        public string PartOne { get; set; }
        public string PartTwo { get; set; }
        public string Input { get; set; }
        public int Date { get; set; }
        
        public TimeSpan First { get; set; }
        public TimeSpan Second { get; set; }

        public Day(int date)
        {
            Date = date;
            PartOne = "--";
            PartTwo = "--";

            ResetInput().Wait();
            try{ TheNeedful(); }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public virtual void TheNeedful()
        {

        }
        public virtual void SetInput(){}

        public async Task ResetInput()
        {
            var dayAsString = this.GetType().Name;
            

            try{
                using( var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Cookie", "session=53616c7465645f5fcc1dfcc61fccbb4ade57925b3c7018f89453d251b4de6d15de001b8bbe47daa2ff5867576bb937ec");
                    Input = (await client.GetStringAsync($"https://adventofcode.com/2019/day/{Date}/input")).Trim();
                    
                }
                return;
            }
            catch {}
        }
    }
}