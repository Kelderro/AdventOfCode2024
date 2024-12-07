using AdventOfCode2024.Day03;

namespace AdventOfCode2024.Tests;

public class Day03Tests
{
    [Fact]
    public void Part01_Sample_Test()
    {
        const string input = """
                             xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))
                             """;
        
        var result = Puzzle.Part01(input.Split(Environment.NewLine));

        result.Should().Be(161);
    }
    
    [Fact]
    public void Part02_Sample_Test()
    {
        const string input = """
                             xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))
                             """;
        
        var result = Puzzle.Part02(input.Split(Environment.NewLine));
    
        result.Should().Be(48);
    }
}