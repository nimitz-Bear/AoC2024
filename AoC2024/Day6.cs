namespace AoC2024;

public class Day6
{
    private readonly string[] _grid;
    private int _guardX = -1, _guardY = -1;
    private Direction _direction = Direction.Up;
    
    public Day6(string[] grid)
    {
        _grid = grid;
        
        // find where the guard is
        for (var i = 0; i < _grid.Length; i++)
        {
            _guardX = Array.FindIndex(_grid, row => row.Contains('^'));
            _guardY = i;
            
            if (_guardX != -1)
                break;
        }
    }
    private bool IsInsideRoom(int x, int y) =>
        x >= 0 && x < _grid[0].Length && y >= 0 && y < _grid.Length;

    public int Part1()
    {
        int[] dx = [0, 1, 0, -1];
        int[] dy = [1, 0, -1, 0];
        var result = 0;
        
        while (IsInsideRoom(_guardX, _guardY))
        {
            if (_grid[_guardX + dx[(int)_direction]][_guardY + dy[(int)_direction]] != '.')
                _direction = (Direction)(((int)_direction + 1) % 4);
            else
            {
                result++;
                _guardX += dx[(int)_direction];
                _guardY += dy[(int)_direction];
            }

        }

        return result;
    }

    private enum Direction
    {
        Up = 0,
        Right = 1,
        Down = 2,
        Left = 3
    }
    
}