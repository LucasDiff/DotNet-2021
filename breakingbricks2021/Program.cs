using System;
using Breakingbricks.Core;
namespace breakingbricks2021
{
    class Program
    {
        static void Main(string[] args)
        {
            var field = new Field(8, 8);
            for (var row = 0; row < field.RowCount; row++)
            {
                for (var column = 0; column < field.ColumnCount; column++)
                {
                    Console.Write(" " + field.GetBrick(row, column).Colour);
                }
                Console.WriteLine();
            }
        }
    }
}
