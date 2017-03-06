using System;

namespace Chaiwatmat.TennisGame.ScoreRules
{
    public class DeuceRule : ScoreRule{
        private int _player1Score;
        private int _player2Score;

        public DeuceRule(int player1Score, int player2Score){
            _player1Score = player1Score;
            _player2Score = player2Score;
        }

        public bool IsMatchRule(){
            return _player1Score >= 3 && _player1Score == _player2Score;
        }

        public string SpeakScore(){
            return "deuce-deuce";
        }
    }
}
