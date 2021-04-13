using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using BreakingBricks.Core;
using BreakingBricksCore.Service;
using BreakingBricksCore.Entity;


namespace BreakingBricks.ConsoleUI
{
    public class ConsoleUI
    {
        private readonly Field _field;
        private readonly IScoreService _scoreService = new ScoreServiceFile();
        public int poc = 0;
        public int abeceda = 1;
        public char ch = 'a';
        public ConsoleUI(Field field)
        {
            _field = field;
        }
        public void Play()
        {
            Top();
            do
            {
                PrintField();
                Input();
                if(_field.MagicWand() == 0)
                {
                    System.Console.WriteLine("You lost all your wands and with that ur game! :(");
                    break;
                }
            } while (!_field.IsSolved());
            if (_field.MagicWand() > 0)
            {
                _scoreService.AddScore(
                 new Score { Player = Environment.UserName, BrickScore = _field.GetScore(), PlayedAt = DateTime.Now });
                PrintField();
                System.Console.WriteLine("Game solved, you did it!");
            }
        }

        private void Input()
        {
            
            System.Console.Write("Enter which brick you want to destroy: \n");
            var line = System.Console.ReadLine();
            Regex reg = new Regex("^([a-h])*([1-8])$");
            bool result = reg.IsMatch(line);
            if ("X" == line || "x" == line)
                Environment.Exit(0);
            if (result == true)
            {
                int row = line[0] - 'a';
                int column = line[1] - 49;
                try
                {
                    _field.Move(row, column);
                }
                catch (FormatException)
                {
                    //chyba
                }
            }
            else
            {
                System.Console.WriteLine("Chyba : zly format");
                Input();
            }
        }
        private void PrintField()
        {
            poc = 0;
            abeceda = 97;
            System.Console.Write("   ");
            for (var column = 1; column < _field.ColumnCount + 1; column++)
            {
                System.Console.Write(" " + column + ":" );
            }
            System.Console.WriteLine();

            for (var row = 0; row < _field.RowCount; row++)
            {
                for (var column = 0; column < _field.ColumnCount; column++)
                {
                    var brick = _field[row, column];
                    if (poc == 0)
                    {
                        ch = (char)abeceda;
                        System.Console.Write(ch + ":");
                    }                   
                    if (brick != null)
                        System.Console.Write("{0,3}", brick.Colour);
                    else
                        System.Console.Write("   ");
                    poc++;
                }
                poc = 0;
                abeceda++;
                System.Console.WriteLine();
                
            }
            System.Console.WriteLine("Your Score: {0}\n", _field.GetScore());
            System.Console.WriteLine("Magic wands left: {0}\n", _field.MagicWand());
        }
        private void Top()
        {
            System.Console.WriteLine("");
            System.Console.WriteLine("    -->TOP 3 BEST SCORES<--");
            System.Console.WriteLine("");
            foreach (var score in _scoreService.GetTopScores())
            {
                System.Console.WriteLine("       {0} :  {1}", score.Player, score.BrickScore);
            }
            System.Console.WriteLine();
            System.Console.WriteLine("Careful if you use all of your Magic Wands you lose!");
            System.Console.WriteLine();

            System.Console.WriteLine("\n    --> BRICK BREAKING! <--");
            System.Console.WriteLine();
        }
        
    }
}
