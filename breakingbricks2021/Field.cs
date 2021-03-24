using System;
using System.Collections.Generic;
using System.Text;

namespace Breakingbricks.Core
{
    public class Field
    {
        private Brick[,] bricks;
        public int RowCount
        {
            get;
        }
        public int ColumnCount
        {
            get;
        }

        public Field(int rowCount, int columnCount)
        {
            RowCount = rowCount;
            ColumnCount = columnCount;
            bricks = new Brick[rowCount, columnCount];
            Generate();
        }

        public Brick GetBrick(int row, int column)
        {
            return bricks[row, column];
        }
        private void Generate()
        {
            Random random = new System.Random();
            int rvalue = 0;
            for (var row = 0; row < RowCount; row++)
            {
                for (var column = 0; column < ColumnCount; column++)
                {
                    rvalue = random.Next(0, 3);
                    bricks[row, column] = new Brick(rvalue);
                }
            }
        }
    }
}
