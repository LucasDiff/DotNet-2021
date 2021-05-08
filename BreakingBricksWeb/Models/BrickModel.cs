using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BreakingBricks.Core;
using BreakingBricksCore.Entity;
namespace BreakingBricksWeb.Models
{
    public class BrickModel
    {
        public Field Field { get; set; }

        public IList<Score> Scores{ get; set; }
        public IList<Comment> Comments { get; set; }

        public IList<Rating> Ratings { get; set; }
    }
}
