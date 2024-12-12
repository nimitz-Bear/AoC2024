namespace AoC2024;

public class Day11(string input)
{
    private readonly List<long> _stones = input.Split(" ").Select(long.Parse).ToList();

    public int Part1()
    {
        for (var x = 0; x < 75; x++)
        {
            for (var i = 0; i < _stones.Count; i++)
            {
                if (_stones[i] == 0)
                    _stones[i] = 1;
                else if (_stones[i].ToString().Length % 2 == 0)
                {
                    var number = "" + _stones[i];
                    _stones[i] = long.Parse(number.Substring(0, number.Length / 2));
                    _stones.Insert(i + 1, long.Parse(number.Substring(number.Length / 2)));
                    i++;
                }
                else
                    _stones[i] *= 2024;
            }
            
        }

        return _stones.Count;
    }

    public int Part2()
    {
        Dictionary<long, int> cache = []; // value, count
        
        for (var x = 0; x < 75; x++)
        {
            for (var i = 0; i < _stones.Count; i++)
            {
                if (cache.ContainsKey(_stones[i]))
                {
                    
                }
                else if (_stones[i] == 0)
                    _stones[i] = 1;
                else if (_stones[i].ToString().Length % 2 == 0)
                {
                    var number = "" + _stones[i];
                    _stones[i] = long.Parse(number.Substring(0, number.Length / 2));
                    _stones.Insert(i + 1, long.Parse(number.Substring(number.Length / 2)));
                    i++;
                }
                else
                    _stones[i] *= 2024;
            }
            
        }

        return _stones.Count;
    }
}