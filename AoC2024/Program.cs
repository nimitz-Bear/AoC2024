using AoC2024;

var challenge = new Day8(Lines("day8.txt").ToArray());
Console.WriteLine(challenge.Part1());
challenge =  new Day8(Lines("day8.txt").ToArray());
Console.WriteLine(challenge.Part2());
return;

IEnumerable<string> Lines(string path)
{
    return File.ReadLines(path);
}


