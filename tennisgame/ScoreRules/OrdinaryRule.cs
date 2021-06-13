namespace Chaiwatmat.TennisGame.ScoreRules
{
    public class OrdinaryRule : IScoreRule
    {
        private int _player1Score;
        private int _player2Score;

        public OrdinaryRule(int player1Score, int player2Score)
        {
            _player1Score = player1Score;
            _player2Score = player2Score;
        }

        public bool IsMatchRule() => true;

        public string SpeakScore()
        {
            var p1Score = Describe(_player1Score);
            var p2Score = Describe(_player2Score);

            return $"{p1Score}-{p2Score}";
        }

        private string Describe(int score)
        {
            return score switch
            {
                0 => "love",
                1 => "fifteen",
                2 => "thirty",
                3 => "forty",
                _ => "",
            };
        }
    }
}