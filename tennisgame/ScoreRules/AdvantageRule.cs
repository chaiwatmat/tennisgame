using System;

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

        public bool IsMatchRule() => AdvantageScore();

        public string SpeakScore() => _player1Score > _player2Score ? "advantage-forty" : "forty-advantage";

        private bool AdvantageScore() => (_player1Score >= 4 || _player2Score >= 4) && Math.Abs(_player1Score - _player2Score) == 1;
    }
}