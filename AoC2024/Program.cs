using AoC2024;

// var challenge = new Day2(Lines("day2.txt").ToArray());
// Console.WriteLine(challenge.Part1());
// challenge = new Day2(Lines("day2.txt").ToArray());
// Console.WriteLine(challenge.Part2());

var challenge = new Day3();
Console.WriteLine(challenge.Part1(File.ReadAllText("day3.txt")));
Console.WriteLine(challenge.Part2(File.ReadAllText("day3.txt")));
    
IEnumerable<string> Lines(string path)
{
    return File.ReadLines(path);
}

