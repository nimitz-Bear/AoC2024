using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AoC2024;

public class Day3
{
    public int Part1(string input)
    {
        var result = 0;
        var matches = Regex.Matches(input, @"mul\(\d{1,3},\d{1,3}\)");
        
        foreach (Match match in matches)
        {
            var numbers = Regex.Matches(match.Value, @"\d+");
            result += int.Parse(numbers[0].Value) * int.Parse(numbers[1].Value);
        }

        return result;
    }

    public int Part2(string input)
    {
        var result = 0;
        var matches = Regex.Matches(input, @"mul\(\d{1,3},\d{1,3}\)");
        var dos = FindAll(input, "do()");
        var donts = FindAll(input, "don't()");
                    
        foreach (Match match in matches)
        {
            var latestDo = Max(dos.Where(x => x < match.Index));
            var latestDont = Max(donts.Where(x => x < match.Index));
            
            var numbers = Regex.Matches(match.Value, @"\d+");
            if (latestDo > latestDont || (latestDo == 0 && latestDont == 0))
                result += int.Parse(numbers[0].Value) * int.Parse(numbers[1].Value);
        }

        return result;
    }

    private int Max(IEnumerable<int> numbers)
    {
        if (!numbers.Any())
            return 0;

        return numbers.Max();
    }
    
    
    private static List<int> FindAll(string text, string textToFind)
    {
        List<int> positions = [];
        var index = text.IndexOf(textToFind, StringComparison.Ordinal);
        while (index != -1)
        {
            positions.Add(index);
            index = text.IndexOf(textToFind, index + 1, StringComparison.Ordinal);
        }
        Console.WriteLine(positions.Count);
        return positions;
    }
}