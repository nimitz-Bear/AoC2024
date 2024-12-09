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

    public long Part2()
    {
       var result = (long) 0;
       char[] operators = ['0', '1', '2']; // 0 = +, 1 = *, 2 = ||
        
        foreach (var entry in _entries)
        {
        
           var combinations = Enumerable.Repeat(operators, entry.Item2.Count - 1)
                                      .Aggregate(
                                          new[] { "" },
                                          (acc, ops) => acc.SelectMany(x => ops, (x, op) => x + op).ToArray()
                                      );

           foreach (var combination in combinations)
           {
               var j = 1;
               var total = entry.Item2[0];
               foreach (var digit in combination)
               {
                   switch (digit)
                   {
                       case '0':
                           total += entry.Item2[j];
                           break;
                       case '1':
                           total *= entry.Item2[j];
                           break;
                       case '2':
                           total = long.Parse("" + total + entry.Item2[j]);
                           break;
                   }

                   j++;
               }

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