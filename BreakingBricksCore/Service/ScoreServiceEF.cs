using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BreakingBricksCore.Entity;
using BreakingBricksCore.Service;


namespace BreakingBricksCore.Service
{
   public class ScoreServiceEF : IScoreService
    {
        public void AddScore(Score score)
        {
            using (var context = new BreakingBricksDbContext())
            {
                context.Scores.Add(score);
                context.SaveChanges();
            }
        }

        public IList<Score> GetTopScores()
        {
            using (var context = new BreakingBricksDbContext())
            {
                return (from s in context.Scores orderby s.BrickScore descending select s).Take(3).ToList();
            }
        }

        public void ResetScore()
        {
            using (var context = new BreakingBricksDbContext())
            {
                context.Database.ExecuteSqlRaw("DELETE FROM Scores");
            }

        }
    }
}
