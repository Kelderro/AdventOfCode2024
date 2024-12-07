namespace AdventOfCode2024.Day02;

/// <summary>
/// Day 2: Red-Nosed Reports
/// https://adventofcode.com/2024/day/2
/// </summary>
internal static class Puzzle
{
    public static int Part01(IEnumerable<string> reports)
    {
        var safeReports = 0;
        
        foreach (var reportLine in reports)
        {
            var levels = reportLine.Split(' ')
                .Select(int.Parse)
                .ToList();
            
            safeReports += IsSafe(levels) ? 1 : 0;
        }
        return safeReports;
    }

    private static bool IsSafe(List<int> levels)
    {
        var increasing = levels[0] - levels[1] < 0;
        
        for (var i = 1; i < levels.Count; i++)
        {
            var previous = levels[i - 1];
            var current = levels[i];

            if (previous == current)
                return false;

            if (increasing && previous > current)
                return false;

            if (!increasing && previous < current)
                return false;

            var diff = Math.Abs(previous - current);

            if (diff > 3)
                return false;
        }

        return true;
    }

    public static int Part02(IEnumerable<string> reports)
    {
        var safeReports = 0;
        
        foreach (var reportLine in reports)
        {
            var allLevels = reportLine.Split(' ')
                .Select(int.Parse)
                .ToList();

            for(var i = -1; i < allLevels.Count; i++)
            {
                var levels = allLevels.ToList();
                
                if (i >= 0)
                    levels.RemoveAt(i);
                
                if (IsSafe(levels))
                {
                    safeReports++;
                    break;
                }
            }
        }
        return safeReports;
    }
}