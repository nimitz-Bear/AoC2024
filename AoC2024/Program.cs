using AoC2024;

var challenge = new Day19(Lines("Day19.txt").ToArray());
Console.WriteLine(challenge.Part1());

return;

IEnumerable<string> Lines(string path) => File.ReadLines(path);


