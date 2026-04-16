namespace bowling;

using FluentAssertions;

public class UnitTest1
{
    [Fact]
    public void Two_gutter_throws_score_is_zero()
    {
        var game = new Game();
        game.Bowl(0);
        game.Bowl(0);

        game.Score().Should().Be(0);
    }

    [Theory]
    [InlineData(new int[]{0, 3}, 3)]
    [InlineData(new int[]{3, 0}, 3)]
    [InlineData(new int[]{2, 7}, 9)]
    [InlineData(new int[]{3, 7}, 10)]
    [InlineData(new int[]{5,5,3}, 16)] // Spare
    [InlineData(new int[]{5, 5, 5, 1}, 21)] // Spare
    [InlineData(new int[]{10,3,4}, 24)] // Strike
    public void Two_throws_score_is_summed(int[] throws, int expected)
    {
        var game = new Game();
        foreach(var aThrow in throws)
        {
            game.Bowl(aThrow);
        }

        game.Score().Should().Be(expected);
    }

    [Fact]
    public void perfect_game_of_12_tens()
    {
        var game = new Game();
        var twelveStrikes = Enumerable.Repeat<int>(10, 12).ToList();
        twelveStrikes.ForEach(game.Bowl);

        game.Score().Should().Be(300);
    }

    [Fact]
    public void Game_of_twenty_throws_of_1_scores_20()
    {
        var game = new Game();
        for (int i = 0; i < 20; i++)
        {
            game.Bowl(1);
        }

        game.Score().Should().Be(20);
    }

    [Fact]
    public void _18_gutters_and_a_spares_and_a_four()
    {
        var game = new Game();
        var theThrows = Enumerable.Repeat<int>(0, 18).ToList();
        theThrows.Add(5);
        theThrows.Add(5);

        theThrows.Add(4);

        theThrows.ForEach(game.Bowl);

        game.Score().Should().Be(14);
    }

    [Fact]
    public void PrintScores()
    {
        var game = new Game();

        var theThrows = Enumerable.Repeat<int>(1, 20).ToList();
        
        theThrows.ForEach(game.Bowl);

//         var actualText = game.GetScoreCardText();
//         var expectedText = """
// | F1  | F2  | F3  | F4  | F5  | F6  | F7  | F8  | F9  | F10   |
// |     |     |     |     |     |     |     |     |     |       |
// |     |     |     |     |     |     |     |     |     |       |
//     """;

        // Console.WriteLine(game.GetScoreCardText());

        // actualText.Should().Be(expectedText);
    }

    [Fact]
    public void InterestingGameScoreCard()
    {
        var theThrows = new List<int>{1, 4, 4, 5, 6, 4, 5, 5, 10, 0, 1, 7, 3, 6, 4, 10, 2, 8, 6};
        var game = new Game();
        theThrows.ForEach(game.Bowl);

        Console.WriteLine("");
        Console.WriteLine(game.GetScoreCardText());
        Console.WriteLine("");
    }
}
