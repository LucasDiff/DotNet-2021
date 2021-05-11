using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BreakingBricksCore.Core;

namespace BreakingBricks.Core
{       
    [Serializable]
    public class Field
    {
        private readonly  Brick[,] _bricks;
        public int RowCount { get; }
        public int ColumnCount { get; }
        public int Solvable;
        public int ColourCount;
        public int Score;
        public int Total;
        public int Num;
        public int Count;
        public int Magic = 3;
        public int Skore = 0;
        
        public Field(int rowCount, int columnCount)
        {
            RowCount = rowCount;
            ColumnCount = columnCount;

            _bricks = new Brick[rowCount, columnCount];
            Initialize();
        }
        public int MagicWand()
        {
            return Magic;
        }
        public bool IsSolved()
        {
            Solvable = 0;
            for (var row = 0; row < RowCount; row++)
            {
                for (var column = 0; column < ColumnCount; column++)
                {
                    Solvable += _bricks[row, column].Colour;
                }
            }
            if (Solvable == 0)
            {
                return true;
            }
            return false;
        }
        public void ColumnEmpty()
        {
            ColourCount = 0;
            for (var column = 0; column < RowCount; column++)
            {
                for (var row = 0; row < ColumnCount; row++)
                {
                    ColourCount = _bricks[row, column].Colour + ColourCount;
                }
                if (ColourCount == 0 && column > 0)
                {
                    ExchangeColumns (column);
                }
                ColourCount = 0;
            }
        }

        private void Initialize()
        {
            Random random = new System.Random();
            int rvalue;
            for (var row = 0; row < RowCount; row++)
            {
                for (var column = 0; column < ColumnCount; column++)
                {
                    rvalue = random.Next(1, 4);
                    _bricks[row, column] = new Brick(rvalue, false);
                }
            }
        }
        public Brick GetBrick(int row, int column)
        {
            return _bricks[row, column];
        }
        public Brick this[int row, int column]
        {
            get { return _bricks[row, column]; }
        }

        public void Move(int row, int column)
        {
            Score = 0;
            _bricks[row, column].Marked = true;
            for (var counter = 0; counter < 8; counter++)
            {
                for (var col = 0; col < ColumnCount; col++)
                {
                    for (var rw = 0; rw < RowCount; rw++)
                    {

                        if (_bricks[rw, col].Marked == true)
                        {
                            Check(rw, col);
                            
                        }
                    }
                }
            }
            for (var counter = 0; counter < 8; counter++)
            {
                for (var col = 0; col < ColumnCount; col++)
                {
                    for (var rw = 0; rw < RowCount; rw++)
                    {

                        if (_bricks[rw, col].Marked == true)
                        {
                            Score++;
                            Check(rw, col);
                            _bricks[rw, col].Colour = 0;

                        }
                        _bricks[rw, col].Marked = false;
                        Exchange(rw, col);
                    }
                }
                ColumnEmpty();
            }  
            if (Score == 1)
            {
                Magic--;
            }
            GetScore();
            
        }

        private void ExchangeColumns(int col)
        {

            if (col > 0)
            {
                for (int cl = col; cl > 0; cl--)
                {
                    for (int row = 0; row < RowCount; row++)
                    {

                        _bricks[row, cl].Colour = _bricks[row, cl - 1].Colour;
                        _bricks[row, cl - 1].Colour = 0;
                    }
                }
            }
        }

        private void Exchange(int row, int column)
        {
            if ( row > 0 && _bricks[row, column].Colour == 0)
            {
                _bricks[row, column].Colour = _bricks[row - 1, column].Colour;
                _bricks[row - 1, column].Colour = 0;
            }
        }
        private void Check(int row, int column)
        {
            if ( column > 0 && _bricks[row,column].Colour == _bricks[row, column - 1].Colour)
            {
                _bricks[row, column - 1].Marked = true;
            }
            if (column < 7 && _bricks[row, column].Colour == _bricks[row, column + 1].Colour)
            {
                _bricks[row, column + 1].Marked = true;
            }
            if ( row > 0 && _bricks[row, column].Colour == _bricks[row - 1, column].Colour)
            {
                _bricks[row - 1, column].Marked = true;
            }
            if ( row < 7 && _bricks[row, column].Colour == _bricks[row + 1, column].Colour)
            {
                _bricks[row + 1, column].Marked = true;
            }
        }
        public int GetScore()
        {
            Num = 2;
            for (var poc = 1; poc <= Score; poc++)
            {
                Num *= 2;
            }
            Total = Total + Num - 2;
            
            return Total;
        }
    }
}
