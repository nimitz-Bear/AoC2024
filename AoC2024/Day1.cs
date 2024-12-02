namespace AoC2024;

public class Day1
{
    private readonly List<int> _left = [];
    private readonly List<int> _right = [];
    public Day1(string[] input)
    {
        foreach (var line in input)
        {
            var lineParts = line.Split("   ");
            _left.Add(int.Parse(lineParts[0]));
            _right.Add(int.Parse(lineParts[1]));
        }
    }
    
    public int Part1()
    {
        var result = 0;
        _left.Sort();
        _right.Sort();

        while (_left.Count != 0 && _right.Count != 0)
        {
            result += Math.Abs(_left[0] - _right[0]);
            _left.RemoveAt(0);
            _right.RemoveAt(0);
        }

        return result;
    }
    
    public int Part2()
    {
        var result = 0;
        _left.Sort();
        _right.Sort();
        
        while (_left.Count != 0)
        {
            var oldSize = _right.Count;
            _right.RemoveAll(i => i == _left[0]);
            result += _left[0] * (oldSize - _right.Count);
            _left.RemoveAt(0);
        }

        return result;
    }
    
}