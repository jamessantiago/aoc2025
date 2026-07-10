namespace aoc.solutions;

public class day02 : ISolution
{
    private readonly string _input;

    public day02()
    {
        var day = GetType().Name;
        _input = File.ReadAllText($"inputs/{day}.txt");
    }

    public Task SolveA()
    {
        var pairs = _input.Split(',').Select(x => x.Split('-')).ToList();
        long total = 0;
        foreach (var pair in pairs)
        {
            var start = long.Parse(pair[0]);
            var end = long.Parse(pair[1]);
            var maxLen = pair[1].Length;
            //Console.WriteLine($"Checking pair {pair[0]} -> {pair[1]}");
            for (var i = 2; i <= maxLen; i += 2)
            {
                var h = i / 2;
                var factor = Pow10(h) + 1;
                var minP = Pow10(h - 1);
                var maxP = Pow10(h) - 1;
                var pLow = Math.Max(minP, (start + factor - 1) / factor);
                var pHigh = Math.Min(maxP, end / factor);
                if (pLow > pHigh) continue;

                var count = pHigh - pLow + 1;
                var invalidIdCountSum = factor * (pLow + pHigh) * count / 2;
                //Console.WriteLine($"Found {pLow} - {pHigh} - {count} - {invalidIdCountSum}");
                total += invalidIdCountSum;
            }
        }

        Console.WriteLine(total);
        return Task.CompletedTask;
    }

    public Task SolveB()
    {
        var pairs = _input.Split(',').Select(x => x.Split('-')).ToList();
        var ids = new HashSet<long>();
        foreach (var pair in pairs)
        {
            var start = long.Parse(pair[0]);
            var end = long.Parse(pair[1]);
            var maxLen = pair[1].Length;
            for (var i = 2; i <= maxLen; i++)
            for (var j = 1; j < i; j++)
            {
                if (i % j != 0) continue;
                var r = i / j;
                if (r < 2) continue;

                long factor = 0;
                long term = 1;
                for (var t = 0; t < r; t++)
                {
                    factor += term;
                    term *= Pow10(j);
                }

                //Console.WriteLine($"Test {i} - {j} - {factor}");
                var minP = Pow10(j - 1);
                var maxP = Pow10(j) - 1;
                var pLow = Math.Max(minP, (start + factor - 1) / factor);
                var pHigh = Math.Min(maxP, end / factor);
                for (var p = pLow; p <= pHigh; p++)
                {
                    //Console.WriteLine($"Res {p * factor}");
                    ids.Add(p * factor);
                }
            }
        }

        long total = 0;
        foreach (var id in ids) total += id;
        Console.WriteLine(total);
        return Task.CompletedTask;
    }

    private static long Pow10(int exp)
    {
        long result = 1;
        for (var i = 0; i < exp; i++) result *= 10;
        return result;
    }
}