using System;

namespace Chaiwatmat.TennisGame.ScoreRules
{
    public class OrdinaryRule : ScoreRule{
        private int _player1Score;
        private int _player2Score;

        public OrdinaryRule(int player1Score, int player2Score){
            _player1Score = player1Score;
            _player2Score = player2Score;
        }

        public bool IsMatchRule(){
            return true;
        }

        public string SpeakScore(){
            var p1Score = Describe(_player1Score);
            var p2Score = Describe(_player2Score);

            return p1Score + "-" + p2Score;
        }

        private string Describe(int score){
            var describe = "";
            switch(score){
                case 0:
                    describe = "love";
                    break;
                case 1:
                    describe = "fifteen";
                    break;
                case 2:
                    describe = "thirty";
                    break;
                case 3:
                    describe = "forty";
                    break;
            }
            return describe;
        }
    }
}
