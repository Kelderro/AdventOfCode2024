namespace AdventOfCode2024.Day04;

/// <summary>
///     Day 4: Ceres Search
///     https://adventofcode.com/2024/day/4
/// </summary>
internal static class Puzzle
{
    public static int Part01(string[] inputLines)
    {
        var wordCount = 0;

        for (var r = 0; r < inputLines.Length; r++)
            for (var c = 0; c < inputLines[r].Length; c++)
            {
                if (inputLines[r][c] != 'X')
                    continue;

                // Vertical left
                if (c >= 3
                    && inputLines[r][c - 1] == 'M'
                    && inputLines[r][c - 2] == 'A'
                    && inputLines[r][c - 3] == 'S')
                    wordCount++;

                // Vertical right
                if (inputLines[r].Length - c > 3
                    && inputLines[r][c + 1] == 'M'
                    && inputLines[r][c + 2] == 'A'
                    && inputLines[r][c + 3] == 'S')
                    wordCount++;

                // Horizontal up
                if (r >= 3
                    && inputLines[r - 1][c] == 'M'
                    && inputLines[r - 2][c] == 'A'
                    && inputLines[r - 3][c] == 'S')
                    wordCount++;

                // Horizontal down
                if (inputLines.Length - r > 3
                    && inputLines[r + 1][c] == 'M'
                    && inputLines[r + 2][c] == 'A'
                    && inputLines[r + 3][c] == 'S')
                    wordCount++;

                // Diagonal left down
                if (inputLines.Length - r > 3
                    && c >= 3
                    && inputLines[r + 1][c - 1] == 'M'
                    && inputLines[r + 2][c - 2] == 'A'
                    && inputLines[r + 3][c - 3] == 'S')
                    wordCount++;


                // Diagonal right down
                if (inputLines.Length - r > 3
                    && inputLines[r].Length - c > 3
                    && inputLines[r + 1][c + 1] == 'M'
                    && inputLines[r + 2][c + 2] == 'A'
                    && inputLines[r + 3][c + 3] == 'S')
                    wordCount++;

                // Diagonal left up
                if (r >= 3
                    && c >= 3
                    && inputLines[r - 1][c - 1] == 'M'
                    && inputLines[r - 2][c - 2] == 'A'
                    && inputLines[r - 3][c - 3] == 'S')
                    wordCount++;

                // Diagonal right up
                if (r >= 3
                    && inputLines[r].Length - c > 3
                    && inputLines[r - 1][c + 1] == 'M'
                    && inputLines[r - 2][c + 2] == 'A'
                    && inputLines[r - 3][c + 3] == 'S')
                    wordCount++;
            }

        return wordCount;
    }

    public static int Part02(string[] inputLines)
    {
        var wordCount = 0;

        for (var r = 0; r < inputLines.Length; r++)
            for (var c = 0; c < inputLines[r].Length; c++)
            {
                if (inputLines[r][c] != 'A')
                    continue;

                if (inputLines.Length - r > 1 &&
                    inputLines[r].Length - c > 1
                    && r >= 1
                    && c >= 1
                    // Top left
                    && ((inputLines[r - 1][c - 1] == 'M' && inputLines[r + 1][c + 1] == 'S')
                        || (inputLines[r - 1][c - 1] == 'S' && inputLines[r + 1][c + 1] == 'M'))
                    // Top right
                    && ((inputLines[r - 1][c + 1] == 'M' && inputLines[r + 1][c - 1] == 'S')
                        || (inputLines[r - 1][c + 1] == 'S' && inputLines[r + 1][c - 1] == 'M'))
                    // Bottom left
                    && ((inputLines[r + 1][c - 1] == 'M' && inputLines[r - 1][c + 1] == 'S')
                        || (inputLines[r + 1][c - 1] == 'S' && inputLines[r - 1][c + 1] == 'M'))
                    // Bottom right
                    && ((inputLines[r + 1][c + 1] == 'M' && inputLines[r - 1][c - 1] == 'S')
                        || (inputLines[r + 1][c + 1] == 'S' && inputLines[r - 1][c - 1] == 'M')))
                    wordCount++;
            }

        return wordCount;
    }
}