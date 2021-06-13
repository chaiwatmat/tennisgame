using System;

namespace Chaiwatmat.TennisGame.ScoreRules
{
    public interface IScoreRule
    {
        bool IsMatchRule();

        string SpeakScore();
    }
}