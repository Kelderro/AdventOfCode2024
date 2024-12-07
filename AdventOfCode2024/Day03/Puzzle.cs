using System.Globalization;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day03;

/// <summary>
///     Day 3: Mull It Over
///     https://adventofcode.com/2024/day/3
/// </summary>
internal static partial class Puzzle
{
    [GeneratedRegex(@"mul\((?<left>[0-9]*),(?<right>[0-9]*)\)", RegexOptions.Compiled)]
    private static partial Regex PartOneRegex();
    
    public static int Part01(IEnumerable<string> inputLines)
    {
        var input = string.Join(Environment.NewLine, inputLines);
        
        return PartOneRegex()
            .Matches(input)
            .Select(m => (
                Left: int.Parse(m.Groups["left"].Value, CultureInfo.InvariantCulture),
                Right: int.Parse(m.Groups["right"].Value, CultureInfo.InvariantCulture)))
            .Sum(match => match.Left * match.Right);
    }

    [GeneratedRegex(@"do\(\)|don\'t\(\)|mul\((?<left>[0-9]*),(?<right>[0-9]*)\)", RegexOptions.Compiled)]
    private static partial Regex PartTwoRegex();
    
    public static int Part02(IEnumerable<string> inputLines)
    {
        var answer = 0;
        var input = string.Join(Environment.NewLine, inputLines);

        var matches = PartTwoRegex()
            .Matches(input);

        var calcEnabled = true;
        foreach (Match match in matches)
        {
            if (match.Value.Equals("do()", StringComparison.Ordinal))
            {
                calcEnabled = true;
                continue;
            }
            
            if (match.Value.Equals("don't()", StringComparison.Ordinal))
            {
                calcEnabled = false;
                continue;
            }

            if (!calcEnabled)
                continue;
            
            var left = int.Parse(match.Groups["left"].Value, CultureInfo.InvariantCulture);
            var right = int.Parse(match.Groups["right"].Value, CultureInfo.InvariantCulture);
            
            answer += left * right;
        }
        
        return answer;
    }
}