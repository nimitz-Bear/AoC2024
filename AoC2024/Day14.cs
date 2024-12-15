namespace AoC2024;

public class Day14
{
    private readonly List<Tuple<int, int>> _robots = [];
    private readonly List<Tuple<int, int>> _velocities = [];
    private const int Width = 101, Height = 103;
    char[,] grid = new char[Width, Height];
    
    public Day14(string[] input)
    {
        foreach (var line in input)
        {
            var sides = new string(line.Where(c => !char.IsLower(c) && c != '=').ToArray()).Split(" ");
            var initialPosition = new Tuple<int, int>(int.Parse(sides[0].Split(',')[0]), int.Parse(sides[0].Split(',')[1]));
            _robots.Add(initialPosition);
            var velocity = new Tuple<int, int>(int.Parse(sides[1].Split(',')[0]), int.Parse(sides[1].Split(',')[1]));
            _velocities.Add(velocity);
        }
    }

    public int Part1()
    {
        for (var i = 0; i < 100; i++)
        {
            for (var x = 0; x < _robots.Count; x++)
            {
                _robots[x] = new Tuple<int, int>(_robots[x].Item1 + _velocities[x].Item1, _robots[x].Item2 + _velocities[x].Item2);

                if (_robots[x].Item1 < 0)
                    _robots[x] = new Tuple<int, int>(_robots[x].Item1 + Width, _robots[x].Item2);
                else
                    _robots[x] = new Tuple<int, int>(_robots[x].Item1 % Width, _robots[x].Item2);
                
                if (_robots[x].Item2 < 0) 
                    _robots[x] = new Tuple<int, int>(_robots[x].Item1, _robots[x].Item2 + Height);
                else
                    _robots[x] = new Tuple<int, int>(_robots[x].Item1, _robots[x].Item2 % Height);
            }
        }

        return CheckQuadrants().Aggregate(1, (current, x) => current * x);
    }

    public int Part2()
    {
        for (var i = 0; i < 100000; i++)
        {
            grid = new char[Width, Height];
            
            HashSet<Tuple<int, int>> visited = [];
            for (var x = 0; x < _robots.Count; x++)
            {
                _robots[x] = new Tuple<int, int>(_robots[x].Item1 + _velocities[x].Item1,
                    _robots[x].Item2 + _velocities[x].Item2);

                if (_robots[x].Item1 < 0)
                    _robots[x] = new Tuple<int, int>(_robots[x].Item1 + Width, _robots[x].Item2);
                else
                    _robots[x] = new Tuple<int, int>(_robots[x].Item1 % Width, _robots[x].Item2);

                if (_robots[x].Item2 < 0)
                    _robots[x] = new Tuple<int, int>(_robots[x].Item1, _robots[x].Item2 + Height);
                else
                    _robots[x] = new Tuple<int, int>(_robots[x].Item1, _robots[x].Item2 % Height);
                
                visited.Add(_robots[x]);
                grid[_robots[x].Item1, _robots[x].Item2] = '#';
            }

            if (visited.Count == _robots.Count)
            {
                for (var w = 0; w < grid.GetLength(0); w++) // Iterate over rows
                {
                    for (var h = 0; h < grid.GetLength(1); h++)
                    {
                        if (grid[w, h] == '#')
                            Console.Write('#');
                        else 
                            Console.Write(' ');
                    }
                    
                    Console.WriteLine();
                }
                
                return i + 1; // include the 0th second
            }
        }


        return -1;
    }

    private List<int> CheckQuadrants()
    {
        const int middleX = Width / 2;
        const int middleY = Height / 2;
        List<int> result = [0, 0, 0, 0];
        foreach (var robot in _robots)
        {
            if (robot.Item1 < middleX && robot.Item2 < middleY)
                result[0]++; // top left
            else if (robot.Item1 < middleX && robot.Item2 > middleY)
                result[1]++; // bottom left
            else if (robot.Item1 > middleX && robot.Item2 < middleY)
                result[2]++;
            else if (robot.Item1 > middleX && robot.Item2 > middleY)
                result[3]++;
        }

        return result;
    }
}