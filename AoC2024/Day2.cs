namespace AoC2024;

public class Day2
{
    private string[] _input;
    public Day2(string[] input)
    {
        _input = input;
    }
    
    public int Part1()
    {
        return _input.Select(line => line.Split().Select(int.Parse).ToArray()).Count(numbers => IsAscending(numbers) || IsDescending(numbers));
    }
    
    public int Part2()
    {
        var result = 0;
        var reports = _input.Select(line => line.Split().Select(int.Parse).ToArray());
        foreach (var report in reports)
        {
            for (var i = 0; i < report.Length; i++)
            {
                var temp = report.ToList();
                temp.RemoveAt(i);
                if (IsAscending(temp.ToArray()) || IsDescending(temp.ToArray())) 
                {
                    result++;
                    break;
                } 
            }
        }

        return result;
    }
    
    private bool IsAscending(int[] numbers)
    {
        for (var i = 1; i < numbers.Length; i++)
        {
            if (!(numbers[i - 1] < numbers[i])) return false;
            if (Math.Abs(numbers[i] - numbers[i - 1]) > 3) return false;
        }

        return true;
    }
    
    private bool IsDescending(int[] numbers)
    {
        for (var i = 1; i < numbers.Length; i++)
        {
            if (!(numbers[i - 1] > numbers[i])) return false;
            if (Math.Abs(numbers[i] - numbers[i - 1]) > 3) return false;
        }

        return true;
    }
}