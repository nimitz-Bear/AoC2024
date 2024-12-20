using System.Text.RegularExpressions;
namespace AoC2024;

public class Day19(string[] input)
{
    private List<string> _towels = input[0].Split(',').Select(x => x.Trim()).ToList();
    private string[] _designs = input.Skip(2).ToArray();

    public int Part1()
    {
        return _designs.Sum(design => CheckList(design, _towels));
    }


    private int CheckList(string str, List<string> lst)
    {
        // Construct the regex pattern
        var pattern = "^(?:" + string.Join("|", lst) + ")*$";
        
        // Use Regex to check the patterns
        var result =  Regex.Matches(str, pattern);
        Console.WriteLine($"{str}: {result.Count}");
        return result.Count;
    }

}