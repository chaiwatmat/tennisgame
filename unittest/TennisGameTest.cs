using Chaiwatmat.TennisGame;
using Xunit;

namespace Chaiwatmat.TennisGameTest
{
    public class TennisGameTest
    {
        private Game StartNewGame()
        {
            Player john = new Player("John");
            Player james = new Player("James");

            return new Game(john, james);
        }

        private static void GameScore(int player1Score, int player2Score, Game game)
        {
            for (int i = 1; i <= player1Score; i++)
            {
                game.Player1Score();
            }

            for (int i = 1; i <= player2Score; i++)
            {
                game.Player2Score();
            }
        }

        [Theory]
        [InlineData(0, 0, "love-love")]
        [InlineData(3, 0, "forty-love")]
        [InlineData(3, 3, "deuce")]
        public void WhenPlayerScored_ScoreShouldBeCorrect(int player1Score, int player2Score, string expected)
        {
            Game game = StartNewGame();

            GameScore(player1Score, player2Score, game);

            var result = game.Score();
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(3, 3, "advantage-forty")]
        public void WhenJohnScore4_AndJamesScore3_ScoreShouldBe_Advantage_Forty(int player1Score, int player2Score, string expected)
        {
            Game game = StartNewGame();

            GameScore(player1Score, player2Score, game);

            game.Player1Score();

            var result = game.Score();
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(3, 3, "deuce")]
        public void WhenJohnScore4_AndJamesScore4_ScoreShouldBe_Deuce_Deuce(int player1Score, int player2Score, string expected)
        {
            Game game = StartNewGame();

            GameScore(player1Score, player2Score, game);

            game.Player1Score();
            game.Player2Score();

            var result = game.Score();
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(3, 3, "forty-advantage")]
        public void WhenJohnScore5_AndJamesScore4_ScoreShouldBe_Advantage_Forty(int player1Score, int player2Score, string expected)
        {
            Game game = StartNewGame();

            GameScore(player1Score, player2Score, game);

            game.Player1Score();
            game.Player2Score();

            game.Player2Score();

            var result = game.Score();
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(3, 3, "John")]
        public void WhenJohnScore6_AndJamesScore4_WinnerShouldBe_John(int player1Score, int player2Score, string expected)
        {
            Game game = StartNewGame();

            GameScore(player1Score, player2Score, game);

            game.Player1Score();
            game.Player2Score();

            game.Player1Score();
            game.Player1Score();

            var winner = game.GetWinner();
            Assert.Equal(expected, winner.Name);
        }

        [Theory]
        [InlineData(3, 3, "James")]
        public void WhenJamesScore6_AndJohnScore4_WinnerShouldBe_James(int player1Score, int player2Score, string expected)
        {
            Game game = StartNewGame();

            GameScore(player1Score, player2Score, game);

            game.Player1Score();
            game.Player2Score();

            game.Player2Score();
            game.Player2Score();

            var winner = game.GetWinner();
            Assert.Equal(expected, winner.Name);
        }
    }
}