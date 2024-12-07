using AdventOfCode2024.Day02;

namespace AdventOfCode2024.Tests;

public class Day02Tests
{
    [Fact]
    public void Part01_Sample_Test()
    {
        const string input = """
                             7 6 4 2 1
                             1 2 7 8 9
                             9 7 6 2 1
                             1 3 2 4 5
                             8 6 4 4 1
                             1 3 6 7 9
                             """;
        
        var result = Puzzle.Part01(input.Split(Environment.NewLine));

        result.Should().Be(2);
    }
    
    [Fact]
    public void Part02_Sample_Test()
    {
        const string input = """
                             7 6 4 2 1
                             1 2 7 8 9
                             9 7 6 2 1
                             1 3 2 4 5
                             8 6 4 4 1
                             1 3 6 7 9
                             """;
        
        var result = Puzzle.Part02(input.Split(Environment.NewLine));
    
        result.Should().Be(4);
    }
}