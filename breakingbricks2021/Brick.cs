using System;
using System.Collections.Generic;
using System.Text;

namespace Breakingbricks.Core
{
    public class Brick
    {
        public Brick(int colour)
        {
            Colour = colour;
        }
        public int Colour { get; private set; }

    }
}
