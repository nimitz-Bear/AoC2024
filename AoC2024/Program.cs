using System.Net.Mime;
using System.Reflection;
using AoC2024;


var challenge = new Day1(Lines(Directory.GetCurrentDirectory()+"/Day1.txt").ToArray());
Console.WriteLine(challenge.Part1());
challenge = new Day1(Lines(Directory.GetCurrentDirectory()+"/Day1.txt").ToArray());
Console.WriteLine(challenge.Part2());

IEnumerable<string> Lines(string path)
{
    return File.ReadLines(path);
}

