namespace AoC2024;

public class Day15
{
    private readonly List<Tuple<int, int>> _boxes = [];
    private readonly string _directions = string.Empty;
    private readonly int _height = 0, _width = 0;
    private Tuple<int, int> _player = Tuple.Create(-1, -1);
    private char[][] _grid;
    
    private readonly int[] _dx = [0, 1, 0, -1];
    private readonly int[] _dy = [1, 0, -1, 0];
    
    public Day15(string[] input)
    {
        _width = input[0].Length;
        
        foreach (var line in input)
        {
            if (line.StartsWith('#'))
            {
                _boxes.AddRange(AllIndexesOf(line, "O")
                    .Select(x => new Tuple<int, int>(x, _height)).ToList());
                _height++;
                
                if (line.Contains('@'))
                    _player = new Tuple<int, int>(line.IndexOf('@'), _height);
            } else if (line.Contains('v'))
                _directions += line;
        }
        
        _grid = new char[_height][];
        for (var y = 0; y < _height; y++)
        {
            if (input[y].StartsWith('#'))
                _grid[y] = input[y].ToCharArray();
            else
                break;
        }
        
    }

    public int Part1()
    {
        foreach (var c in _directions)
        {
            var direction = Convert(c);
            if (!IsMoveValid(direction))
                continue;
            
            //TODO: 
            
        }
        return _boxes.Select(x => 100 * x.Item1 * x.Item2).Sum();
    }

    private bool IsMoveValid(Direction direction)
    {
        // // TODO: move in a direction from the player until you hit a '.'
        // // if there's a '.', return true
        // var x = _player.Item1 + _dx[direction], y = _player.Item2[direction];
        //
        // while (_grid[y][x] != '.')
        // {
        //     if (_grid[y][x] == '#')
        //         return false;
        // }

        return true;
    }

    private Direction Convert(char c)
    {
        return c switch
        {
            '^' => Direction.North,
            'v' => Direction.South,
            '>' => Direction.East,
            '<' => Direction.West,
            _ => throw new ArgumentException($"Invalid direction: {c}")
        };
    }
    
    private static IEnumerable<int> AllIndexesOf(string str, string searchString)
    {
        var minIndex = str.IndexOf(searchString, StringComparison.Ordinal);
        while (minIndex != -1)
        {
            yield return minIndex;
            minIndex = str.IndexOf(searchString, minIndex + searchString.Length, StringComparison.Ordinal);
        }
    }
    
    private enum Direction
    {
        North,
        East,
        South,
        West
    }
}