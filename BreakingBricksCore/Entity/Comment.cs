using System;
using System.Collections.Generic;
using System.Text;

namespace BreakingBricksCore.Entity
{
    [Serializable]
    public class Comment
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public DateTime PlayedAt { get; set; }
        public string Content { get; set; }
        
    }
}

