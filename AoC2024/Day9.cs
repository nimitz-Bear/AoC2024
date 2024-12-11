namespace AoC2024;

public class Day9
{
    private readonly List<Tuple<int, bool, int>> _disk = []; // size, isFree, id
    private string status = String.Empty; // represent the disk as a string
    
    public Day9(string input)
    {
        bool isFree = false;
        int i = 0;
        foreach (char c in input)
        {
            int size = c - '0';
            _disk.Add(new Tuple<int, bool, int>(size, isFree, i));
            status += isFree ? new string('.', size): new string('X', size);
            isFree = !isFree;
        }
    }

    public int Part1()
    {
        // file. position
        int filePosition = 0;
        List<Tuple<Tuple<int, bool, int>, int>> files = _disk.Select(file => 
                new Tuple<Tuple<int, bool, int>, int>(file, filePosition)).ToList().Where(portion => 
            !portion.Item1.Item2).Reverse().ToList();
        
        // go through each element of the disk from the back and move it to the leftmost space
        int position = 0;
  
        // while there is empty space to the left of the file and there and there are other files to move
        while (status.Substring(0, files.First().Item2).Contains('.'))
        {
            var file = files.First().Item1;

            while (Equals(files.First().Item1, file))
            {
                // update position
                // position += 
                
                // look for the first chunk of free space
                // if the free space is larger
                // - 1. Turn free space into <file.size, false>
                // - 2. Append remaining space
                // - 3. REmove 
                
                
                
                // update status
            }

        }
        
        // calculate checksum by getting the sum of each files position * id
        position = 0;
        return _disk.Select(file =>
        {
            int value = position * file.Item3;
            position += file.Item1;
            return value;
        }).Sum();
    }
}