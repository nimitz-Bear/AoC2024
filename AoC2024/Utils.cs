namespace AoC2024;

using System;
using System.Collections.Generic;

public static class Utils
{

    // A structure to hold the necessary parameters
    public struct Cell
    {
        // Row and Column index of its parent
        // Note that 0 <= i <= ROW-1 & 0 <= j <= COL-1
        public int parent_i, parent_j;
        // f = g + h
        public double f, g, h;
    }
    
    // A Function to find the shortest path between
    // a given source cell to a destination cell according
    // to A* Search Algorithm
    public static List<Tuple<int, int>> AStar(int[,] grid, Tuple<int, int> src, Tuple<int, int> dest, bool fourWay)
    {
        var row = grid.GetLength(0);
        var col = grid.GetLength(1);
        Tuple<int, int>[] cardinalNeighbours =
            [Tuple.Create(0, -1), Tuple.Create(1, 0), Tuple.Create(0, 1), Tuple.Create(-1, 0)];

        // If the source or destination is out of range
        if (!IsValid(src.Item1, src.Item2, row, col) || !IsValid(dest.Item1, dest.Item2, row, col))
        {
            Console.WriteLine("Source or destination is invalid");
            return [];
        }

        // Either the source or the destination is blocked
        if (!IsUnBlocked(grid, src.Item1, src.Item2) || !IsUnBlocked(grid, dest.Item1, dest.Item2))
        {
            Console.WriteLine("Source or the destination is blocked");
            return [];
        }

        // If the destination cell is the same as the source cell
        if (src.Item1 == dest.Item1 && src.Item2 == dest.Item2)
        {
            Console.WriteLine("We are already at the destination");
            return [];
        }

        // Create a closed list and initialise it to false which
        // means that no cell has been included yet. This closed
        // list is implemented as a boolean 2D array
        var closedList = new bool[row, col];

        // Declare a 2D array of structure to hold the details
        // of that cell
        var cellDetails = new Cell[row, col];

        for (var i = 0; i < row; i++)
        {
            for (var j = 0; j < col; j++)
            {
                cellDetails[i, j].f = double.MaxValue;
                cellDetails[i, j].g = double.MaxValue;
                cellDetails[i, j].h = double.MaxValue;
                cellDetails[i, j].parent_i = -1;
                cellDetails[i, j].parent_j = -1;
            }
        }

        // Initialising the parameters of the starting node
        int x = src.Item1, y = src.Item2;
        cellDetails[x, y].f = 0.0;
        cellDetails[x, y].g = 0.0;
        cellDetails[x, y].h = 0.0;
        cellDetails[x, y].parent_i = x;
        cellDetails[x, y].parent_j = y;

        /*
            Create an open list having information as-
            <f, <i, j>>
            where f = g + h,
            and i, j are the row and column index of that cell
            Note that 0 <= i <= ROW-1 & 0 <= j <= COL-1
            This open list is implemented as a SortedSet of tuple (f, (i, j)).
            We use a custom comparer to compare tuples based on their f values.
        */
        var openList = new SortedSet<(double, Tuple<int,int>)>(
            Comparer<(double, Tuple<int,int>)>.Create((a, b) => a.Item1.CompareTo(b.Item1)));

        // Put the starting cell on the open list and set its
        // 'f' as 0
        openList.Add((0.0, new Tuple<int,int>(x, y)));

        // We set this boolean value as false as initially
        // the destination is not reached.
        var foundDest = false;

        while (openList.Count > 0)
        {
            (double f, Tuple<int,int> pair) p = openList.Min;
            openList.Remove(p);

            // Add this vertex to the closed list
            x = p.pair.Item1;
            y = p.pair.Item2;
            closedList[x, y] = true;

            // Generating all the 8 successors of this cell
            for (var i = -1; i <= 1; i++)
            {
                for (var j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                        continue;

                    if (fourWay && cardinalNeighbours.Contains(Tuple.Create(i, j))) 
                        continue;

                    var newX = x + i;
                    var newY = y + j;

                    // If this successor is a valid cell
                    if (IsValid(newX, newY, row, col))
                    {
                        // If the destination cell is the same as the
                        // current successor
                        if (IsDestination(newX, newY, dest))
                        {
                            cellDetails[newX, newY].parent_i = x;
                            cellDetails[newX, newY].parent_j = y;
                            Console.WriteLine("The destination cell is found");
                            foundDest = true;
                            return TracePath(cellDetails, dest);;
                        }

                        // If the successor is already on the closed
                        // list or if it is blocked, then ignore it.
                        if (!closedList[newX, newY] && IsUnBlocked(grid, newX, newY))
                        {
                            var gNew = cellDetails[x, y].g + 1.0;
                            var hNew = CalculateHValue(newX, newY, dest);
                            var fNew = gNew + hNew;

                            // If it isn’t on the open list, add it to
                            // the open list. Make the current square
                            // the parent of this square. Record the
                            // f, g, and h costs of the square cell
                            if (cellDetails[newX, newY].f == double.MaxValue || cellDetails[newX, newY].f > fNew)
                            {
                                openList.Add((fNew, new Tuple<int,int>(newX, newY)));

                                // Update the details of this cell
                                cellDetails[newX, newY].f = fNew;
                                cellDetails[newX, newY].g = gNew;
                                cellDetails[newX, newY].h = hNew;
                                cellDetails[newX, newY].parent_i = x;
                                cellDetails[newX, newY].parent_j = y;
                            }
                        }
                    }
                }
            }
        }

        // When the destination cell is not found and the open
        // list is empty, then we conclude that we failed to
        // reach the destination cell. This may happen when the
        // there is no way to destination cell (due to
        // blockages)
        if (!foundDest)
            Console.WriteLine("Failed to find the Destination Cell");
        
        return [];
    }

    // A Utility Function to check whether given cell (row, col)
    // is a valid cell or not.
    private static bool IsValid(int row, int col, int ROW, int COL) =>
        row >= 0 && row < ROW && col >= 0 && col < COL;
    

    // Returns true if the cell is not blocked else false
    private static bool IsUnBlocked(int[,] grid, int row, int col)
        => grid[row, col] == 0;

    // A Utility Function to check whether destination cell has
    // been reached or not
    private static bool IsDestination(int row, int col, Tuple<int,int> dest) =>
        row == dest.Item1 && col == dest.Item2;
    

    // A Utility Function to calculate the 'h' heuristics.
    private static double CalculateHValue(int row, int col, Tuple<int,int> dest)
        => Math.Sqrt(Math.Pow(row - dest.Item1, 2) + Math.Pow(col - dest.Item2, 2));

    // A Utility Function to trace the path from the source
    // to destination
    private static List<Tuple<int, int>> TracePath(Cell[,] cellDetails, Tuple<int,int> dest)
    {
        Console.WriteLine("\nThe Path is ");
        var ROW = cellDetails.GetLength(0);
        var COL = cellDetails.GetLength(1);
        var result = new List<Tuple<int, int>>();

        var row = dest.Item1;
        var col = dest.Item2;

        Stack<Tuple<int,int>> path = new Stack<Tuple<int,int>>();

        while (!(cellDetails[row, col].parent_i == row && cellDetails[row, col].parent_j == col))
        {
            path.Push(new Tuple<int,int>(row, col));
            var temp_row = cellDetails[row, col].parent_i;
            var temp_col = cellDetails[row, col].parent_j;
            row = temp_row;
            col = temp_col;
        }

        path.Push(new Tuple<int,int>(row, col));
        while (path.Count > 0)
        {
            var p = path.Peek();
            path.Pop();
            Console.Write(" -> ({0},{1}) ", p.Item1, p.Item2);
            result.Add(new Tuple<int, int>(p.Item1, p.Item2));
        }
        
        return result;
    }
}