namespace AoC2024;

public class Day4(string[] input)
{
    private readonly string[] _input = input;

    private const string Word = "XMAS";

    public int Part1()
    {
        int[] directionX = { -1, -1, -1, 0, 0, 1, 1, 1 };
        int[] directionY = { -1, 0, 1, -1, 1, -1, 0, 1 };
        int result = 0;
        
        var y = 0;
        foreach (var line in _input)
        {
            for (var i = 0; i < line.Length; i++)
            {
                if (line[i] == 'X')
                {
                    // go once in all 8 directions
                    for (var k = 0; k < 8; k++)
                    {
                        if (LookForWords(0, y, i, directionX[k], directionY[k]))
                            result++;
                            
                    }
                       
                }
            }
            y++;
        }

        return result;
    }

    public int Part2()
    {
        var result = 0;
        
        var y = 0;
        foreach (var line in _input)
        {
            for (var i = 0; i < line.Length; i++)
            {
                if (line[i] == 'A')
                {
                    // go once in all 8 directions
                        if (IsValidCross(y,i))
                            result++;
                }
            }
            y++;
        }

        return result;
    }
    
    private bool LookForWords(int index, int x, int y, int dirX, int dirY)
    {
        // if word has been found
        if (index == Word.Length) return true;
        
        if (ValidCoord(x, y, _input.Length, _input[0].Length) 
            && Word[index] == input[x][y])
            return LookForWords(index + 1, 
                x + dirX, y + dirY, dirX, dirY);

        return false;
    }
    
    private static bool ValidCoord(int x, int y, int m, int n)
    {
        return x >= 0 && x < m && y >= 0 && y < n;
    }
    
    private bool IsValidCross(int x, int y)
    {                   
        int[] directionX = { -1, -1, 1, 1 };
        int[] directionY = { -1, 1, -1, 1 };
        
        // check if all directions are valid
        for (var i = 0; i < 4; i++)
        {
            if (!ValidCoord(x + directionX[i], y + directionY[i], _input.Length, _input[0].Length))
                return false;
        }
        
        // left is m and right is s
        if (_input[x + directionX[0]][y + directionY[0]] == 'S' && _input[x + directionX[1]][y + directionY[1]] == 'S'
            && _input[x + directionX[2]][y + directionY[2]] == 'M'  && _input[x + directionX[3]][y + directionY[3]] == 'M')
            return true;
        
        // right is s and left is m
        if (_input[x + directionX[0]][y + directionY[0]] == 'M' && _input[x + directionX[1]][y + directionY[1]] == 'M' 
                && _input[x + directionX[2]][y + directionY[2]] == 'S'  && _input[x + directionX[3]][y + directionY[3]] == 'S')
            return true;
        
        // top is m and bottom is s
        if (_input[x + directionX[0]][y + directionY[0]] == 'S' && _input[x + directionX[2]][y + directionY[2]] == 'S' 
                                                                && _input[x + directionX[1]][y + directionY[1]] == 'M'  && _input[x + directionX[3]][y + directionY[3]] == 'M')
            return true;
        
        // bottom is m and top is s
        if (_input[x + directionX[0]][y + directionY[0]] == 'M' && _input[x + directionX[2]][y + directionY[2]] == 'M' 
                                                                && _input[x + directionX[1]][y + directionY[1]] == 'S'  && _input[x + directionX[3]][y + directionY[3]] == 'S')
            return true;
        
        return false;
    }
}