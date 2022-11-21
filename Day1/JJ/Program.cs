using System.IO;

public class Day1 {
    private static readonly string input = File.ReadAllText("input.txt");
    public static void Main() {
        Console.WriteLine(Part1());
        Console.WriteLine(Part2());
    }
    public static int Part1()
    {
        return Execute(
            input.Split("\r\n")
                 .Select(o => Convert.ToInt32(o))
                 .ToList());
    }

    public static int Part2()
    {
        var inputSplitted = input.Split("\r\n").Select(o => Convert.ToInt32(o)).ToList();
        var result = new List<int>();
        for (int i = 2; i < inputSplitted.Count; i++)
        {
            result.Add(inputSplitted[i - 2] + inputSplitted[i - 1] + inputSplitted[i]);
        }
        return Execute(result);
    }

    private static int Execute(List<int> input)
    {
        var count = 0;
        for (int i = 1; i < input.Count; i++)
        {
            if (input[i] - input[i - 1] > 0)
            {
                count++;
            }
        }

        return count;
    }
}