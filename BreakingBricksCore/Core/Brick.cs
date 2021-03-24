using System;
using System.Collections.Generic;
using System.Text;

namespace BreakingBricks.Core
{
    public class Brick
    {
        public Brick(int colour, bool marked)
        {
            Colour = colour;
            Marked = marked;
        }
        public int Colour { get; set; }
        public bool Marked { get; set; }

    }
}
