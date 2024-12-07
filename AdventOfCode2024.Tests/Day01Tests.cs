using AdventOfCode2024.Day01;

namespace AdventOfCode2024.Tests;

public class Day01Tests
{
    [Fact]
    public void Part01_Sample_Test()
    {
        const string input = """
                             3   4
                             4   3
                             2   5
                             1   3
                             3   9
                             3   3
                             """;
        
        var result = Puzzle.Part01(input.Split(Environment.NewLine));

        result.Should().Be(11);
    }
    
    [Fact]
    public void Part02_Sample_Test()
    {
        const string input = """
                             3   4
                             4   3
                             2   5
                             1   3
                             3   9
                             3   3
                             """;
        
        var result = Puzzle.Part02(input.Split(Environment.NewLine));
    
        result.Should().Be(31);
    }
}