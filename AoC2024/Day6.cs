using System.Runtime.InteropServices.JavaScript;

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
            _guardX = _grid[i].IndexOf('^');
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
        int[] dy = [-1, 0, 1, 0];
        var result = 1;
        
        // Console.WriteLine($"{_guardX}, {_guardY}");
        while (IsInsideRoom(_guardX, _guardY))
        {
            Console.WriteLine($"{_guardX}, {_guardY}");
            if (!IsInsideRoom(_guardX + dx[(int)_direction], _guardY + dy[(int)_direction]))
                break;

            int nextX = _guardX + dx[(int)_direction];
            int nextY = _guardY + dy[(int)_direction];
            // Console.WriteLine("W" + _grid[nextX]);
            // Console.WriteLine(_grid[nextX][nextY]);
            switch (_grid[nextY][nextX])
            {
                case '#':
                {
                    _direction = (Direction)(((int)_direction + 1) % 4);
                    break;
                }
                case '.':
                {
                    var charArray = _grid[nextY].ToCharArray();
                    charArray[nextX] = 'X';
                    _grid[nextY] = new string(charArray);
                    result++;
                    // foreach (var line in _grid)
                    //     Console.WriteLine(line);
                    _guardX += dx[(int)_direction];
                    _guardY += dy[(int)_direction];
                    break;
                }
                case 'X':
                {
                    _guardX += dx[(int)_direction];
                    _guardY += dy[(int)_direction];
                    break;
                }
                case '^':
                {
                    _guardX += dx[(int)_direction];
                    _guardY += dy[(int)_direction];
                    break;
                }
                
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