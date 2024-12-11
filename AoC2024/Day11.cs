namespace AoC2024;

public class Day11(string input)
{
    private readonly List<int> _stones = input.Split(" ").Select(int.Parse).ToList();

    public int Part1()
    {
        for (int x = 0; x < 25; x++)
        {
            for (int i = 0; i < _stones.Count; i++)
            {
                if (_stones[i] == 0)
                    _stones[i] = 1;
                else if (_stones[i].ToString().Length % 2 == 0)
                {
                    // split the number if the number of digits is even
                    _stones[i] = int.Parse(_stones[i].ToString().Substring(0, _stones[i].ToString().Length / 2 - 1));
                    _stones.Insert(i + 1, int.Parse(_stones[i].ToString().Substring(_stones[i].ToString().Length / 2 - 1)));
                }
                else
                    _stones[i] *= 2024;
            }
            
        }

        return _stones.Count;
    }
}