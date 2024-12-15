using AoC2024;

var challenge = new Day14(Lines("day14.txt").ToArray());
Console.WriteLine(challenge.Part1());
challenge = new Day14(Lines("day14.txt").ToArray());
Console.WriteLine(challenge.Part2());
return;

IEnumerable<string> Lines(string path) => File.ReadLines(path);


