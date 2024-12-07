using System.Globalization;

namespace AdventOfCode2024.Day05;

/// <summary>
/// Day 5: Print Queue
/// https://adventofcode.com/2024/day/5
/// </summary>
internal static class Puzzle
{
    public static int Part01(string[] inputLines)
    {
        var orderRules = ParseRules(inputLines);
        var inputOrder = ParseOrder(inputLines);

        var correctOrder = inputOrder
            .Where(l => IsValidOrder(l, orderRules))
            .ToList();

        return SumUpMiddlePageNumber(correctOrder);
    }
    
    public static int Part02(string[] inputLines)
    {
        var orderRules = ParseRules(inputLines);
        var inputOrder = ParseOrder(inputLines);

        var sortComparer = new PageNumberComparer(orderRules);
        
        var sorted = inputOrder
            .Where(o => !IsValidOrder(o, orderRules))
            .Select(o =>
            {
                Array.Sort(o, sortComparer);
                return o;
            })
            .ToList();

        return SumUpMiddlePageNumber(sorted);
    }

    private sealed class PageNumberComparer(Dictionary<int, List<int>> orderRules) : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (orderRules.TryGetValue(y, out var pageRules))
                return pageRules.Contains(x) ? 1 : -1;

            if (orderRules.TryGetValue(x, out pageRules))
                return pageRules.Contains(y) ? -1 : 1;
            
            return 0;
        }
    }
    
    private static bool IsValidOrder(int[] line, Dictionary<int, List<int>> orderRules)
    {
        var previousPageNumbers = new List<int>();
            
        foreach (var page in line)
        {
            previousPageNumbers.Add(page);
                
            if (!orderRules.TryGetValue(page, out var currentPageRules))
                continue;

            // Check if the current page does not break any of the order rules
            if (previousPageNumbers.Any(h => currentPageRules.Contains(h)))
            {
                return false;
            }
        }

        return true;
    }

    private static int SumUpMiddlePageNumber(List<int[]> correctOrder)
    {
        return correctOrder.Sum(l => l[l.Length / 2]);
    }

    private static int[][] ParseOrder(string[] inputLines)
    {
        var inputOrder = inputLines
            .Where(l => l.Contains(',', StringComparison.Ordinal))
            .Select(l => l.Split(',', StringSplitOptions.RemoveEmptyEntries))
            .Select(l => l.Select(n => int.Parse(n, CultureInfo.InvariantCulture))
                .ToArray())
            .ToArray();
        return inputOrder;
    }

    private static Dictionary<int, List<int>> ParseRules(string[] inputLines)
    {
        var orderRules = new Dictionary<int, List<int>>();
        
        var inputRules = inputLines
            .Where(l => l.Contains('|', StringComparison.Ordinal))
            .Select(l => l.Split('|', StringSplitOptions.RemoveEmptyEntries))
            .Select(l => (
                Page: int.Parse(l[0], CultureInfo.InvariantCulture),
                PrintedBefore: int.Parse(l[1], CultureInfo.InvariantCulture))
            );

        foreach (var orderingRule in inputRules)
        {
            if (orderRules.TryGetValue(orderingRule.Page, out var value))
                value.Add(orderingRule.PrintedBefore);
            else
                orderRules.Add(orderingRule.Page, [ orderingRule.PrintedBefore ]);
        }

        return orderRules;
    }
}