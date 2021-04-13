using System;
using System.Collections.Generic;
using System.Text;

namespace BreakingBricksCore.Entity
{
    [Serializable]
    public class Score
    {

        public int Id { get; set; }

        public string Player { get; set; }

        public int BrickScore { get; set; }

        public DateTime PlayedAt { get; set; }


    }
}
