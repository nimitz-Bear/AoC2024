namespace AoC2024;

public class Day7
{
    private readonly List<Tuple<long, List<long>>> _entries = [];
    
    public Day7(string[] lines)
    {
        foreach (var line in lines)
        {
            var sides = line.Split(": ");
            _entries.Add(new Tuple<long, List<long>>(
                long.Parse(sides[0]), 
                sides[1].Split(' ').Select(long.Parse).ToList()));
        }
    }

    public long Part1()
    {
        var result = (long) 0;
        
        foreach (var entry in _entries)
        {
            var totalCombinations = (int) Math.Pow(2, entry.Item2.Count - 1);
            for (var i = 0; i < totalCombinations; i++)
            {
                // create a binary string for each combination, where 0 is + and 1 is *
                var binary = Convert.ToString(i, 2).PadLeft(entry.Item2.Count - 1, '0');
                Console.WriteLine(binary);
            
                
                // use the binary to figure out the total
                var j = 1;
                var total = entry.Item2[0];
                foreach (var digit in binary)
                {
                    if (digit == '0')
                        total += entry.Item2[j];
                    else
                        total *= entry.Item2[j];
                    j++;
                }
                
                // if the total is equal to the target
                if (total == entry.Item1)
                {
                    result += total;
                    break;
                }
           
            }
        }
        
        return result;
    }
}