﻿using AoC2024;

// var challenge = new Day10(Lines("day10.txt").ToArray());
// // Console.WriteLine(challenge.Part1());
// Console.WriteLine(challenge.Part2());
var challenge = new Day11(File.ReadAllText("day11.txt"));
Console.WriteLine(challenge.Part1());
return;

IEnumerable<string> Lines(string path)
{
    return File.ReadLines(path);
}


