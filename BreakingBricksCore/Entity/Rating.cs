using System;
using System.Collections.Generic;
using System.Text;

namespace BreakingBricksCore.Entity
{
    [Serializable]
    public class Rating
    {
        public string Player { get; set; }

        public DateTime PlayedAt { get; set; }
        public int PlayerRating { get; set; }

    }
}
