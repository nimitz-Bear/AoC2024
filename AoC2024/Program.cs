using AoC2024;

var challenge = new Day2(Lines("day2.txt").ToArray());
Console.WriteLine(challenge.Part1());
challenge = new Day2(Lines("day2.txt").ToArray());
Console.WriteLine(challenge.Part2());

IEnumerable<string> Lines(string path)
{
    return File.ReadLines(path);
}

