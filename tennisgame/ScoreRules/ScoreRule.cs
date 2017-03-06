using System;

namespace Chaiwatmat.TennisGame.ScoreRules
{
    public interface ScoreRule{
        bool IsMatchRule();
        string SpeakScore();
    }
}
