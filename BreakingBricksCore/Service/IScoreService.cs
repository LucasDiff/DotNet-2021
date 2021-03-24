using System;
using System.Collections.Generic;
using System.Text;
using BreakingBricksCore.Entity;

namespace BreakingBricksCore.Service
{
    public interface IScoreService
    {
        void AddScore(Score score);
        IList<Score> GetTopScores();
        void ResetScore();
    }
}
