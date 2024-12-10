using System.Data;

namespace AoC2024;

public class Day10
{
    private char[][] _grid;
    private int[] _dx = [0, 1, 0, -1];
    private int[] _dy = [1, 0, -1, 0];

    public Day10(string[] input) =>
        _grid = input.Select(row => row.ToCharArray()).ToArray();

    public int Part1()
    {
        var total = 0;
        for (var row = 0; row < _grid.Length; row++)
        {
            for (var col = 0; col < _grid[0].Length ; col++)
            {
                if (_grid[row][col] == '0')
                    total += Part1Score(row, col);
            }
        }

        return total;
    }

    public int Part2()
    {
        var total = 0;
        for (var row = 0; row < _grid.Length; row++)
        {
            for (var col = 0; col < _grid[0].Length ; col++)
            {
                if (_grid[row][col] == '0')
                    total += Part1Score(row, col);
            }
        }

        return total;
    }
    
    private int Part1Score(int row, int col)
    {
        var toVisit = new Stack<Tuple<int, int>>();
        toVisit.Push(new Tuple<int, int>(row, col));
        HashSet<Tuple<int, int>> reachablePeaks = [];
        bool[,] visited = new bool[_grid.Length, _grid[0].Length];

        while (toVisit.Count > 0)
        {
            var current = toVisit.Pop();

            if (_grid[current.Item1][current.Item2] == 'X')
                continue;
            
            // look at adjacent grid squares
            // if current is 8, look around and check for 9's and increment the total
            // otherwise, look around for 1 higher than current's value and add to stack
            if (_grid[current.Item1][current.Item2] == '8')
            {
                for (var i = 0; i < 4; i++)
                {
                    if (IsCoordinateValid(current.Item1 + _dy[i], current.Item2 + _dx[i]) &&
                        _grid[current.Item1 + _dy[i]][current.Item2 + _dx[i]] == '9')
                        reachablePeaks.Add(new Tuple<int, int>(current.Item1 + _dy[i], current.Item2 + _dx[i]));
                 
                }
            }
            else
            {
                int currHeight = _grid[current.Item1][current.Item2] - '0';
                
                for (var i = 0; i < 4; i++)
                {
                    if (IsCoordinateValid(current.Item1  + _dy[i], current.Item2 + _dx[i]) &&
                        _grid[current.Item1 + _dy[i]][current.Item2 + _dx[i]] == (char)(currHeight + 1 + '0'))
                        toVisit.Push(new Tuple<int, int>(current.Item1 + _dy[i], current.Item2 + _dx[i]));
                }
                
            }
            // mark of the location as visited
            visited[current.Item1,current.Item2] = true;
        }

        return reachablePeaks.Count;
    }
    
    private bool IsCoordinateValid(int row, int col) => row >= 0 && row < _grid.Length && col >= 0 && col < _grid[0].Length;
}