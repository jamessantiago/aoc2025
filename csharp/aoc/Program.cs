using System.Reflection;
using aoc.solutions;

namespace aoc;

class Program
{
    static void Main(string[] args)
    {
        var solution = Assembly.GetExecutingAssembly().GetTypes()
            .Where(x => x.Name.StartsWith("day"))
            .OrderByDescending(x => x.Name)
            .Select(Activator.CreateInstance)
            .FirstOrDefault() as ISolution;

        if (solution == null)
        {
            Console.WriteLine("Failed to find solution");
            return;
        }

        try
        {
            solution.SolveB();
        }
        catch (NotImplementedException)
        {
            solution.SolveA();   
        }
    }
}