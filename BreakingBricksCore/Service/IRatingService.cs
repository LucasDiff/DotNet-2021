using System;
using System.Collections.Generic;
using System.Text;
using BreakingBricksCore.Entity;

namespace BreakingBricksCore.Service
{
    public interface IRatingService
    {
        void AddRating(Rating rating);
        IList<Rating> GetTopRatings();
        void ResetRatings();
    }
}