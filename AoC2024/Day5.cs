using System.Text.RegularExpressions;

namespace AoC2024;

public partial class Day5
{
    private Dictionary<int, List<int>> _rules = new();
    private string[] _input;
    
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
            
            if (_rules.ContainsKey(second))
                _rules[second].Add(first);
            else
                _rules[second] = [first];
        }
    }

    public int Part1()
    {
        var result = 0;
        foreach (var line in _input)
        {
            if (!line.Contains(','))
                continue;

            var entry = MyRegex().Matches(line).Select(m => int.Parse(m.Value)).ToList();
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

            var entry = MyRegex().Matches(line).Select(m => int.Parse(m.Value)).ToList();
            if (!FixEntry(entry))
            {
                result += entry[entry.Count / 2];
            }
               
        }

        return result;
    }

    private bool IsEntryValid(List<int> entry)
    {
        for(var i = 0; i < entry.Count; i++)
        {
            // look at the last few elements, check if any of them violate a previous rule
            if (_rules.ContainsKey(entry[i]) && _rules[entry[i]].Any(rule => entry.Skip(i + 1).Contains(rule)))
                return false;
            
            // look at first `i` elements and see if any violate a next rule
            // if (_next.ContainsKey(entry[i]) && _next[entry[i]].Any(rule => entry.Take(i).Contains(rule)))
            //     return false;
        }

        return true;
    }
    
    // return true if its already correct
    private bool FixEntry(List<int> entry)
    {
        var result = true;
        for(var i = 0; i < entry.Count; i++)
        {
            // look at the last few elements, check if any of them violate a previous rule
            if (_rules.TryGetValue(entry[i], out var prevRules) && prevRules.Any(rule => entry.Skip(i + 1).Contains(rule)))
            {
                var indexToSwap = entry.Skip(i + 1).TakeWhile(x => x != entry[i]).Count();
                Console.WriteLine(string.Join(";", entry));
                // Console.WriteLine(en);
                (entry[i], entry[indexToSwap]) = (entry[indexToSwap], entry[i]);
                result = false;
                Console.WriteLine();
                // i = Math.Min(i, indexToSwap) + 1;
            }
        }
        
        if (!result)
         Console.WriteLine(string.Join(";", entry));
        return result;
    }
    
    [GeneratedRegex(@"\d+")]
    private static partial Regex MyRegex();
}