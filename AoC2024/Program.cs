using AoC2024;

var challenge = new Day6(Lines("day6.txt").ToArray());
Console.WriteLine(challenge.Part2());
return;

IEnumerable<string> Lines(string path)
{
    return File.ReadLines(path);
}


