using AdventOfCode2024.Day01;
using AdventOfCode2024.Day02;

var input = await File.ReadAllLinesAsync("Day01/input.txt").ConfigureAwait(false);
Console.WriteLine(PuzzleDay01.Part01(input));
Console.WriteLine(PuzzleDay01.Part02(input));
Console.WriteLine(AdventOfCode2024.Day01.Puzzle.Part01(input));
Console.WriteLine(AdventOfCode2024.Day01.Puzzle.Part02(input));

input = await File.ReadAllLinesAsync("Day02/input.txt").ConfigureAwait(false);
Console.WriteLine(PuzzleDay02.Part01(input));
Console.WriteLine(PuzzleDay02.Part02(input));
Console.WriteLine(AdventOfCode2024.Day02.Puzzle.Part01(input));
Console.WriteLine(AdventOfCode2024.Day02.Puzzle.Part02(input));