using Chaiwatmat.TennisGame.ScoreRules;
using System;
using System.Collections.Generic;

namespace Chaiwatmat.TennisGame
{
    public class Game
    {
        private Player _player1;
        private Player _player2;

        private int _player1Score;
        private int _player2Score;

        public Game(Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

        public void Player1Score() => _player1Score++;

        public void Player2Score() => _player2Score++;

        public string Score()
        {
            var scoreRules = new List<IScoreRule>
            {
                new AdvantageRule(_player1Score, _player2Score),
                new DeuceRule(_player1Score, _player2Score),
                new OrdinaryRule(_player1Score, _player2Score)
            };

            foreach (var scoreRule in scoreRules)
            {
                if (scoreRule.IsMatchRule())
                {
                    return scoreRule.SpeakScore();
                }
            }

            throw new Exception("Score is error!!");
        }

        public Player GetWinner()
        {
            var isGameEnd = _player1Score >= 4 && _player1Score - 2 >= _player2Score;
            if (!isGameEnd)
            {
                return null;
            }

            return _player1Score > _player2Score ? _player1 : _player2;
        }
    }
}