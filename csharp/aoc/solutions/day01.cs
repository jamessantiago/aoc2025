namespace aoc.solutions;

public class day01 : ISolution
{
    private readonly string _input;
    
    public day01()
    {
        var day = this.GetType().Name;
        _input = File.ReadAllText($"inputs/{day}.txt");
    }

    public Task SolveA()
    {
        var dial = 50;
        var zeros = 0;
        var lines = _input.Split(Environment.NewLine);
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            var distance = int.Parse(line[1..]);
            if (line[0] == 'L')
            {
                dial -= distance;
                if (dial < 0) dial += 100;
                dial %= 100;
            }
            else
            {
                dial += distance;
                dial %= 100;
            }
            if (dial == 0) zeros++;
        }
        Console.WriteLine(zeros);
        
        return Task.CompletedTask;
    }

    public Task SolveB()
    {
        var dial = 50;
        var zeros = 0;
        var lines = _input.Split(Environment.NewLine);
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            var distance = int.Parse(line[1..]);
            Console.WriteLine(line);
            if (line[0] == 'L')
            {
                var from = dial;
                zeros += FloorDiv(dial - 1, 100) - FloorDiv(dial - distance - 1, 100);
                dial -= distance;
                dial %= 100;
                if (dial < 0) dial += 100;
                Console.WriteLine($"{FloorDiv(dial - 1, 100) - FloorDiv(dial - distance - 1, 100)} zeros found moving {from} by {line} to {dial}");
            }
            else
            {
                var from = dial;
                zeros += (dial + distance) / 100 - dial / 100;
                dial += distance;
                dial %= 100;
                Console.WriteLine($"{FloorDiv(dial - 1, 100) - FloorDiv(dial - distance - 1, 100)} zeros found moving {from} by {line} to {dial}");
            }
        }
        Console.WriteLine(zeros);
        return Task.CompletedTask;
    }

    private static int FloorDiv(int a, int b)
    {
        int q = a / b;
        if ((a ^ b) < 0 && a % b != 0) q--;
        return q;
    }
}