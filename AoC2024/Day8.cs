namespace AoC2024;

public class Day8
{
    private readonly Dictionary<char, List<Tuple<int, int>>> _map = [];
    private readonly HashSet<Tuple<int,int>> _antinodes = [];
    private char[][] _grid;
    
    public Day8(string[] input)
    {
        var y = 0;
        _grid = input.Select(line => line.ToCharArray()).ToArray();
        
        foreach (var line in input)
        {
            var x = 0;
            foreach (var c in line)
            {
                if (char.IsLetterOrDigit(c))
                {
                    if (!_map.ContainsKey(c))
                        _map.Add(c, [new Tuple<int, int>(x, y)]);
                    else
                        _map[c].Add(new Tuple<int, int>(x, y));
                }

                x++;
            }

            y++;
        }
 
        foreach (var line in _grid)
            Console.WriteLine(new string(line));
        
        Console.WriteLine();
    }

    public int Part1()
    {
        // for each character
            // look at every combination of positions (a,b)
            // where a is twice b and b is twice a, and draw a # there
            foreach (var kvp in _map)
            {
                foreach (var a in kvp.Value)
                {
                    foreach (var b in kvp.Value)
                    {
                        if (Equals(a, b))
                            continue;
                        
                        var antinodeX = a.Item1 + (a.Item1 - b.Item1);
                        var antinodeY = a.Item2 + (a.Item2 - b.Item2);
                        
                        if (antinodeY < 0 || antinodeY >= _grid.Length || antinodeX < 0 || antinodeX >= _grid[0].Length)
                            continue;
                        
                        _antinodes.Add(new Tuple<int, int>(antinodeX, antinodeY));
                        _grid[antinodeY][antinodeX] = '#';
                    }
                }
            }

            return _antinodes.Count;
    }

    public int Part2()
    {
        // for each character
        // look at every combination of positions (a,b)
            // find dx, dy 
            // increment by dx and dy until its out of the map
            // each increment, add a new antinode to the hashset
        foreach (var kvp in _map)
        {
            
            // all the frequencies with > 1 antenna are antinodes
            if (kvp.Value.Count > 1)
                kvp.Value.ForEach(x => _antinodes.Add(new Tuple<int, int>(x.Item1, x.Item2)));
            
            foreach (var a in kvp.Value)
            {
                foreach (var b in kvp.Value)
                {
                    if (Equals(a, b))
                        continue;

                    var dx = a.Item1 - b.Item1;
                    var dy = a.Item2 - b.Item2;
                    var antinodeX = a.Item1 + dx;
                    var antinodeY = a.Item2 + dy;

                    while (true)
                    {
                        if (antinodeY < 0 || antinodeY >= _grid.Length || antinodeX < 0 || antinodeX >= _grid[0].Length) 
                            break;
                        
                        _antinodes.Add(new Tuple<int, int>(antinodeX, antinodeY));
                        _grid[antinodeY][antinodeX] = '#';
                        
                        Console.WriteLine($"{antinodeX} {antinodeY}");
                        
                        antinodeX += dx;
                        antinodeY += dy;
                    }
                }
            }
        }
        
        foreach (var line in _grid)
            Console.WriteLine(new string(line));

        return _antinodes.Count;
    }

}