using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BreakingBricksCore.Entity;



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
            using (var db = new BreakingBricksDbContext())
            {
                var a = (from s in db.Scores orderby s.BrickScore descending select s);
                return a.Take(3).ToList();

                
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
