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
        //private readonly IScoreService _scoreService = new ScoreServiceFile();
        private readonly IScoreService _scoreService = new ScoreServiceEF();
        private readonly ICommentService _commentService = new CommentServiceEF();
        private readonly IRatingService _ratingService = new RatingServiceEF();
        public int counter = 0;
        public int alphabet = 0;
        public char chr = 'a';
        public ConsoleUI(Field field)
        {
            _field = field;
        }
        public void Play()
        {
            PrintComments();
            PrintRatings();
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
                Console.WriteLine("What do you think about our game? ");
                var comment = Console.ReadLine();


                Console.WriteLine("Rate our game from 0 to 10 points");
                int rating = Convert.ToInt32(Console.ReadLine());
                Check(rating);
                _ratingService.AddRating(
                    new Rating { Points = rating });
               
                _commentService.AddComment(
                    new Comment { Name = Environment.UserName, Content = comment, PlayedAt = DateTime.Now });
            }
            
        }
        
    private void Check(int rating)
    {
        while (rating < 0 || rating > 10)
        {
            Console.WriteLine("Write number between 1 and 10!");
            rating = Convert.ToInt32(Console.ReadLine());
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
            counter = 0;
            alphabet = 97;
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
                    if (counter == 0)
                    {
                        chr = (char)alphabet;
                        System.Console.Write(chr + ":");
                    }                   
                    if (brick != null)
                        System.Console.Write("{0,3}", brick.Colour);
                    else
                        System.Console.Write("   ");
                    counter++;
                }
                counter = 0;
                alphabet++;
                System.Console.WriteLine();
                
            }
            System.Console.WriteLine("Your Score: {0}\n", _field.GetScore());
            System.Console.WriteLine("Magic wands left: {0}\n", _field.MagicWand());
        }

    /*    private void PrintComments()
        {
            var comments = _commentService.GetComments();
            Console.WriteLine("Comments :");
            int idx = 1;
            foreach( var comment in comments)
            {
                Console.WriteLine("{0}. {1, -12} {2,4}", idx, comment.Name, comment.Content);
                idx++;
            }
        }*/
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
            //PrintComments();
            System.Console.WriteLine("Careful if you use all of your Magic Wands you lose!");
            System.Console.WriteLine();

            System.Console.WriteLine("\n    --> BRICK BREAKING! <--");
            System.Console.WriteLine();
        }
        private void PrintRatings()
        {
            System.Console.WriteLine("");
            System.Console.WriteLine("    -->Our ratings : <--");
            System.Console.WriteLine("");
            foreach(var rating in _ratingService.GetTopRatings())
            {
                System.Console.WriteLine("            {0} / 10", rating.Points);
            }

        }
        private void PrintComments()
        {
            System.Console.WriteLine("");
            System.Console.WriteLine("    -->These are the Top Comments!<--");
            System.Console.WriteLine("");
            foreach(var comment in _commentService.GetTopComments())
            {
                System.Console.WriteLine("{0} says :  {1}     time : {2}", comment.Name, comment.Content, comment.PlayedAt);
            }

        }
        
        
    }
}
