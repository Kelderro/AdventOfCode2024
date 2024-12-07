using System.Globalization;

namespace AdventOfCode2024.Day01;

/// <summary>
/// Day 1: Historian Hysteria
/// https://adventofcode.com/2024/day/1
/// </summary>
internal static class Puzzle
{
    public static int Part01(IEnumerable<string> input)
    {
        var leftNumbers = new List<int>();
        var rightNumbers = new List<int>();
        
        foreach (var inputLine in input)
        {
            var values = inputLine.Split("   ");
            
            leftNumbers.Add(int.Parse(values[0], CultureInfo.InvariantCulture));
            rightNumbers.Add(int.Parse(values[1], CultureInfo.InvariantCulture));
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
            
            var valueLeft = int.Parse(values[0], CultureInfo.InvariantCulture);
            var valueRight = int.Parse(values[1], CultureInfo.InvariantCulture);
            
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