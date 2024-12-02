namespace AdventOfCode2024.Day01;

/// <summary>
/// Day 1: Historian Hysteria
/// https://adventofcode.com/2024/day/1
/// </summary>
public static class PuzzleDay01
{
    public static int Part01(IEnumerable<string> input)
    {
        var leftNumbers = new List<int>();
        var rightNumbers = new List<int>();
        
        foreach (var inputLine in input)
        {
            var values = inputLine.Split("   ");
            
            leftNumbers.Add(int.Parse(values[0]));
            rightNumbers.Add(int.Parse(values[1]));
        }

        leftNumbers.Sort();
        rightNumbers.Sort();

        return leftNumbers.Select((leftNumber, i) => Math.Abs(leftNumber - rightNumbers[i])).Sum();
    }

    public static int Part02(IEnumerable<string> input)
    {
        var result = 0;
        var leftNumbers = new Dictionary<int, int>();
        var rightNumbers = new Dictionary<int, int>();
        
        foreach (var inputLine in input)
        {
            var values = inputLine.Split("   ");
            
            var valueLeft = int.Parse(values[0]);
            var valueRight = int.Parse(values[1]);
            
            if (!leftNumbers.TryAdd(valueLeft, 1))
            {
                leftNumbers[valueLeft]++;
            }
            
            if (!rightNumbers.TryAdd(valueRight, 1))
            {
                rightNumbers[valueRight]++;
            }
        }

        foreach (var leftNumber in leftNumbers)
        {
            if (!rightNumbers.TryGetValue(leftNumber.Key, out var rightNumber))
                continue;
            
            result += (leftNumber.Key * rightNumber) * leftNumber.Value;
        }
        
        return result;
    }
}