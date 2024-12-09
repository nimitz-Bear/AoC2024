using AoC2024;

var challenge = new Day7(Lines("day7.txt").ToArray());
Console.WriteLine(challenge.Part1());

return;

IEnumerable<string> Lines(string path)
{
    return File.ReadLines(path);
}


