using System.Text.RegularExpressions;

namespace AoC2024;

public partial class Day5
{
    private readonly Dictionary<int, List<int>> _rules = new();
    private readonly string[] _input;
    
    public Day5(string[] input)
    {
        _input = input;
        // setup all the rules
        foreach (var line in input)
        {
            var numbers = Regex.Matches(line, @"\d+");

            if (numbers.Count == 0)
                return;
            
            var first = int.Parse(numbers[0].ToString());
            var second = int.Parse(numbers[1].ToString());
            
            if (_rules.ContainsKey(first))
                _rules[first].Add(second);
            else
                _rules[first] = [second];
        }
    }

    public int Part1()
    {
        var result = 0;
        foreach (var line in _input)
        {
            if (!line.Contains(','))
                continue;

            var entry = line.Split(",").Select(int.Parse).ToList();
            if (IsEntryValid(entry))
              result += entry[entry.Count / 2];
        }
        
        return result;
    }
    
    public int Part2()
    {
        var result = 0;
        foreach (var line in _input)
        {
            if (!line.Contains(','))
                continue;

            var entry = line.Split(",").Select(int.Parse).ToList();
            var corrected = false;
            while (!IsEntryValid(entry))
            {
                FixEntry(entry);
                corrected = true;
            }

            if (corrected)
                result += entry[entry.Count / 2];
        }

        return result;
    }

    private bool IsEntryValid(List<int> entry)
    {
        for(var i = 0; i < entry.Count; i++)
        {
            if (_rules.ContainsKey(entry[i]) && _rules[entry[i]].Any(rule => entry.Take(i).Contains(rule)))
                return false;
        }

        return true;
    }
    
    // return true if it's already correct
    private bool FixEntry(List<int> entry)
    {
        var result = true;
            for (var i = 0; i < entry.Count; i++)
            {
                var brokenRule = -1;
                if (_rules.ContainsKey(entry[i]) && _rules[entry[i]].Any(rule =>
                    {
                        brokenRule = rule;
                        return entry.Take(i).Contains(rule);
                    }))
                {
                    var indexToSwap = entry.FindIndex(v => v == brokenRule);
                    (entry[i], entry[indexToSwap]) = (entry[indexToSwap], entry[i]);
                    return false;
                }
        }
        
        return result;
    }
}