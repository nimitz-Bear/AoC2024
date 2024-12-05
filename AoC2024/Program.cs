using System.Diagnostics;
using AoC2024;

var challenge = new Day5(Lines("day5.txt").ToArray());
Console.WriteLine(challenge.Part1());
Console.WriteLine(challenge.Part2());

    
IEnumerable<string> Lines(string path)
{
    return File.ReadLines(path);
}

