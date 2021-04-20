using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BreakingBricksCore.Entity;

namespace BreakingBricksCore.Service
{
    public class RatingServiceEF : IRatingService
    {
 
        public void AddRating(Rating rating)
        {
            
            using (var context = new BreakingBricksDbContext())
            {
                context.Ratings.Add(rating);
                context.SaveChanges();
            }
        }
        public IList<Rating> GetTopRatings()
        {
            using (var context = new BreakingBricksDbContext())
            {
                return (from s in context.Ratings select s).ToList();
            }

        }
        public void ResetRatings()
        {
            using (var context = new BreakingBricksDbContext())
            {
                context.Database.ExecuteSqlRaw("DELETE FROM Rating");
            }
        }

    }
}