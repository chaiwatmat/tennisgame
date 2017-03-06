using System;

namespace Chaiwatmat.TennisGame.ScoreRules
{
    public class AdvantageRule : ScoreRule{
        private int _player1Score;
        private int _player2Score;

        public AdvantageRule(int player1Score, int player2Score){
            _player1Score = player1Score;
            _player2Score = player2Score;
        }

        public bool IsMatchRule(){
            return _player1Score >= 4 && _player1Score - 1 == _player2Score;
        }

        public string SpeakScore(){
            return "advantage-forty";
        }
    }
}
