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

        [Theory]
        [InlineData("love-love")]
        public void WhenGameStart_ScoreShouldBe_LoveLove(string expected)
        {
            Game game = StartNewGame();

            var result = game.Score();
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("forty-love")]
        public void WhenJohnScore3_AndJamesScore0_ScoreShouldBe_Forty_Love(string expected)
        {
            Game game = StartNewGame();

            game.Player1Score();
            game.Player1Score();
            game.Player1Score();

            var result = game.Score();
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("deuce")]
        public void WhenJohnScore3_AndJamesScore3_ScoreShouldBe_Deuce_Deuce(string expected)
        {
            Game game = StartNewGame();

            game.Player1Score();
            game.Player1Score();
            game.Player1Score();

            game.Player2Score();
            game.Player2Score();
            game.Player2Score();

            var result = game.Score();
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("advantage-forty")]
        public void WhenJohnScore4_AndJamesScore3_ScoreShouldBe_Advantage_Forty(string expected)
        {
            Game game = StartNewGame();

            game.Player1Score();
            game.Player1Score();
            game.Player1Score();

            game.Player2Score();
            game.Player2Score();
            game.Player2Score();

            game.Player1Score();

            var result = game.Score();
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("deuce")]
        public void WhenJohnScore4_AndJamesScore4_ScoreShouldBe_Deuce_Deuce(string expected)
        {
            Game game = StartNewGame();

            game.Player1Score();
            game.Player1Score();
            game.Player1Score();

            game.Player2Score();
            game.Player2Score();
            game.Player2Score();

            game.Player1Score();
            game.Player2Score();

            var result = game.Score();
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("forty-advantage")]
        public void WhenJohnScore5_AndJamesScore4_ScoreShouldBe_Advantage_Forty(string expected)
        {
            Game game = StartNewGame();

            game.Player1Score();
            game.Player1Score();
            game.Player1Score();

            game.Player2Score();
            game.Player2Score();
            game.Player2Score();

            game.Player1Score();
            game.Player2Score();

            game.Player2Score();

            var result = game.Score();
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("John")]
        public void WhenJohnScore6_AndJamesScore4_WinnerShouldBe_John(string expected)
        {
            Game game = StartNewGame();

            game.Player1Score();
            game.Player1Score();
            game.Player1Score();

            game.Player2Score();
            game.Player2Score();
            game.Player2Score();

            game.Player1Score();
            game.Player2Score();

            game.Player1Score();
            game.Player1Score();

            var winner = game.GetWinner();
            Assert.Equal(expected, winner.Name);
        }
    }
}