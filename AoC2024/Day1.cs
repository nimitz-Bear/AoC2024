namespace AoC2024;

public class Day1
{
    List<int> left = [];
    List<int> right = [];
    public Day1(string[] input)
    {
        foreach (var line in input)
        {
                var lineParts = line.Split("   ");
                left.Add(int.Parse(lineParts[0]));
                right.Add(int.Parse(lineParts[1]));
        }
    }
    
    public int Part1()
    {
        var result = 0;
        left.Sort();
        right.Sort();

        while (left.Count != 0 && right.Count != 0)
        {
            result += Math.Abs(left[0] - right[0]);
            left.RemoveAt(0);
            right.RemoveAt(0);
        }

        return result;
    }
    
    public int Part2()
    {
        var result = 0;
        left.Sort();
        right.Sort();
        
        while (left.Count != 0)
        {
            var oldSize = right.Count;
            right.RemoveAll(i => i == left[0]);
            result += left[0] * (oldSize - right.Count);
            left.RemoveAt(0);
        }

        return result;
    }
    
}