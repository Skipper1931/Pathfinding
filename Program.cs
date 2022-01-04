using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

class Program {
    public static void Main(string[] args) {
        Console.WriteLine($"Loading input from {args[0]}...");
        ImgGraph g = new ImgGraph(Image.Load(args[0]).CloneAs<Rgba32>());
        Console.WriteLine("Input loaded.");
        Console.WriteLine("Pathfinding... ");
        g.Pathfind();
        Console.WriteLine("Saving output...");
        g.ToImage().Save(args[1]);
        Console.WriteLine("Output saved to " + args[1]);
    }
}