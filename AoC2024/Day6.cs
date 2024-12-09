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
        FindGuard();
    }

    private void FindGuard()
    {
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

    public int Part1(int iterationsToLoop = int.MaxValue)
    {
        int[] dx = [0, 1, 0, -1];
        int[] dy = [-1, 0, 1, 0];
        var result = 1;
        var totalIterations = 0;
        
        while (IsInsideRoom(_guardX, _guardY))
        {
            if (!IsInsideRoom(_guardX + dx[(int)_direction], _guardY + dy[(int)_direction]))
                break;
            
            // for part 2, break if this is already clearly in a loop
            if (totalIterations > iterationsToLoop)
                break;

            var nextX = _guardX + dx[(int)_direction];
            var nextY = _guardY + dy[(int)_direction];

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
            

            totalIterations++;
        }

        return result;
    }
    
    public int TraverseMap(int iterationsToLoop = int.MaxValue)
    {
        int[] dx = [0, 1, 0, -1];
        int[] dy = [-1, 0, 1, 0];
        var totalIterations = 0;
        
        while (IsInsideRoom(_guardX, _guardY))
        {
            if (!IsInsideRoom(_guardX + dx[(int)_direction], _guardY + dy[(int)_direction]))
                break;
            
            // for part 2, break if this is already clearly in a loop
            if (totalIterations > iterationsToLoop)
                break;

            var nextX = _guardX + dx[(int)_direction];
            var nextY = _guardY + dy[(int)_direction];

            switch (_grid[nextY][nextX])
            {
                case '#':
                {
                    _direction = (Direction)(((int)_direction + 1) % 4);
                    break;
                }
                case '.':
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
            

            totalIterations++;
        }

        return totalIterations;
    }

    public int Part2()
    {
        var result = 0;
        var iterationsToLoop = _grid.Length * _grid[0].Length * 4;
        
        // for each non obstacle and non-initial position on the grid, try placing an obstacle and see if it causes the user to loop
        for (var i = 0; i < _grid.Length; i++)
        {
            var t = _grid[i];
            for (var x = 0; x < _grid[i].Length; x++)
            {
                if (t[x] == '.')
                {
                    _direction = Direction.Up;
                    FindGuard();
                    var charArray = t.ToCharArray();
                    charArray[x] = '#';
                    _grid[i] = new string(charArray);

                    if (TraverseMap(iterationsToLoop) > iterationsToLoop)
                        result++;
                    
                    charArray[x] = '.';
                    _grid[i] = new string(charArray);
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