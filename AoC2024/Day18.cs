using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;

namespace AoC2024;

public class Day18
{
    private readonly int[,] _board = new int[7, 7]; // 0 = none, 1 = blocked, 2 = path
    private char[,] _test = new char[7, 7];
    
    public Day18(string[] input)
    {
        // for (var y = 0; y < 7; y++)
        // for (var x = 0; x < 7; x++)
        //     _test[y, x] = '.';
        //     
        foreach (var line in input)
        {
            var split = line.Split(',').Select(int.Parse).ToArray();
            Console.WriteLine($"{split[0]} {split[1]}");
            // _test[split[0], split[1]] = '#';
            _board[split[1], split[0]] = 1;
        }
        PrintBoardAsCsv();
        
    }

    public int Part1()
    {
        var path = Utils.AStar(_board, Tuple.Create(0, 0), Tuple.Create(6, 6), true);
        path.ForEach(x => _board[x.Item1, x.Item2] = 8);

        PrintBoardAsCsv();
        
        return path.Count;
    }
    
    public void PrintBoardAsCsv()
    {
        // Iterate through each row
        for (int i = 0; i < _board.GetLength(0); i++)
        {
            // Get the values of the current row
            var row = Enumerable.Range(0, _board.GetLength(1))
                .Select(j => _board[i, j].ToString());
            
            // Join the values with commas and print the row
            Console.WriteLine(string.Join("", row));
        }
    }
}