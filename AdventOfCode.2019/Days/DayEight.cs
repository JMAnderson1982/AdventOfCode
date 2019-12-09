namespace AdventOfCode._2019.Days
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AdventOfCode.Shared;

    class DayEight : Day
    {
        public DayEight() :base(8) {}
        public override void TheNeedful()
        {
            var pixels = Input.ToCharArray().Select(p => int.Parse(p.ToString())).ToList();
            int width = 25;
            int height = 6;
            
            var image = new Image{
                Height = height,
                Width =width
            };


            var layers = new List<Layer>();
            for(int i = 0; i < pixels.Count(); i += width * height)
            {
                var p = pixels.GetRange(i, width * height);
                var layer = new Layer();
                for(int j = 0; j < width * height; j++)
                {
                    layer.Pixels.Add( new Pixel{ Value = p[j], X = j % width, Y = j / width});
                }
                layers.Add( layer );
            }
            
            var meta = layers.Select( l => new { a = l.Pixels.Count(p => p.Value == 0), b = l.Pixels.Count(p => p.Value == 1) * l.Pixels.Count(p => p.Value == 2)}).ToList();
            PartOne = meta.OrderBy(m => m.a).FirstOrDefault().b.ToString();

            var visible = layers.First();
            foreach(var layer in layers)
            {
                foreach( var pixel in layer.Pixels)
                {
                    var vPixel = visible.Pixels.FirstOrDefault(p => p.X == pixel.X && p.Y == pixel.Y);

                    if(vPixel.Value == 2) vPixel.Value = pixel.Value;
                }
            }
            var sb = new StringBuilder();
            sb.AppendLine();
            for(int y = 0; y < height; y++)
            {   
                for (int x = 0; x < width; x++)
                {   
                    var value = visible.Pixels.First(p => p.X == x && p.Y == y).Value;
                    sb.Append(value == 1 ? value.ToString() : " ");
                }
                sb.AppendLine();
            }
            PartTwo = sb.ToString();
        }

        public class Image
        {   
            public int Height { get; set; }
            public int Width { get; set; }
            public List<Layer> Layers {get; set;}   

            public void AddPixels(string input)
            {
                var values = input.ToCharArray().Select(p => int.Parse(p.ToString())).ToList();

            }
        }

        public class Layer
        {
            public int Height { get; set; }
            public int Width { get; set; }

            public List<Pixel> Pixels {get; set;} = new List<Pixel>();
        }

        public class Pixel
        {
            public int X { get; set; }
            public int Y { get; set; }

            public int Value { get; set; }
        }
    }
}