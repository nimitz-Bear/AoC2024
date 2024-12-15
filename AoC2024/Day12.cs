namespace AoC2024;

public class Day12
{
    private Dictionary<char, List<Tuple<int, int>>> map = [];

    public Day12(string[] input)
    {
        for (var y = 0; y < input.Length; y++)
        {
            for (var x = 0; x < input[0].Length; x++)
            {
                if (map.ContainsKey(input[y][x]))
                    map[input[y][x]].Add(new Tuple<int, int>(x, y));
                else
                    map.Add(input[y][x], [new Tuple<int, int>(x, y)]);
            }
        }
    }

    public int Part1()
    {
        int[] dx = [-1, 0, 1, 0];
        int[] dy = [0, 1, 0, -1];
        var result = 0;
        

        foreach (var entry in map)
        {
            List<Tuple<int, int>> fences = [];
            foreach (var location in entry.Value)
            {
                for (var i = 0; i < 4; i++)
                {
                    var possibleFence = new Tuple<int, int>(location.Item1 + dx[i], location.Item2 + dy[i]);
                    if (!entry.Value.Contains(possibleFence))
                        fences.Add(possibleFence);
                }
                    
            }
            Console.WriteLine($"{entry.Key}: {fences.Count} * {entry.Value.Count} = {fences.Count * entry.Value.Count}");
            result += fences.Count * entry.Value.Count;
        }

        return result;
    }
}