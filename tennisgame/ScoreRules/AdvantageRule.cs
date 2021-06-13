namespace Chaiwatmat.TennisGame.ScoreRules
{
    public class AdvantageRule : IScoreRule
    {
        private int _player1Score;
        private int _player2Score;

        public AdvantageRule(int player1Score, int player2Score)
        {
            _player1Score = player1Score;
            _player2Score = player2Score;
        }

        public bool IsMatchRule() => Player1Advantage() || Player2Advantage();

        public string SpeakScore() => Player1Advantage() ? "advantage-forty" : "forty-advantage";

        private bool Player1Advantage() => _player1Score >= 4 && _player1Score - 1 == _player2Score;

        private bool Player2Advantage() => _player2Score >= 4 && _player2Score - 1 == _player1Score;
    }
}