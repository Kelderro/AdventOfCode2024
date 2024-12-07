using AdventOfCode2024.Day04;

namespace AdventOfCode2024.Tests;

public class Day04Tests
{
    [Fact]
    public void Part01_Sample_Test()
    {
        const string input = """
                             MMMSXXMASM
                             MSAMXMSMSA
                             AMXSXMAAMM
                             MSAMASMSMX
                             XMASAMXAMM
                             XXAMMXXAMA
                             SMSMSASXSS
                             SAXAMASAAA
                             MAMMMXMMMM
                             MXMXAXMASX
                             """;
        
        var result = Puzzle.Part01(input.Split(Environment.NewLine));

        result.Should().Be(18);
    }
    
    [Fact]
    public void Part02_Sample_Test()
    {
        const string input = """
                             .M.S......
                             ..A..MSMS.
                             .M.S.MAA..
                             ..A.ASMSM.
                             .M.S.M....
                             ..........
                             S.S.S.S.S.
                             .A.A.A.A..
                             M.M.M.M.M.
                             ..........
                             """;
        
        var result = Puzzle.Part02(input.Split(Environment.NewLine));
    
        result.Should().Be(9);
    }
}