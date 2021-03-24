using System;
using BreakingBricks.Core;
using BreakingBricksCore.Core;

namespace BreakingBricks
{
    public class Program
    {
        static void Main()
        {
            var field = new Field(8, 8);
            var ui = new ConsoleUI.ConsoleUI(field);
            ui.Play();
            
        }
    }
}
