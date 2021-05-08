using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using BreakingBricks.Core;
using BreakingBricksCore.Service;
using BreakingBricksCore.Entity;
using BreakingBricksWeb.Models;

namespace BreakingBricksWeb.Controllers
{
    public class BrickController : Controller
    {
        private IScoreService _scoreService = new ScoreServiceEF();
        private const string FieldSessionKey = "field";

        public IActionResult Index()
        {
            var field = new Field(8, 8);
            HttpContext.Session.SetObject(FieldSessionKey, field);

            CreateModel();
            return View("Index", CreateModel());
        }

        public IActionResult Move(int c)
        {

            int row = 0;
            int col = 0;
           
            if (c != 0)
            {
                while (c >= 0)
                {
                    row++;
                    c = c - 8;
                    col = c + 8;
                }
                row--;
            }

            var field = (Field) HttpContext.Session.GetObject(FieldSessionKey);
            field.Move(row,col);          
            HttpContext.Session.SetObject(FieldSessionKey, field);
            return View("Index", CreateModel());
        }

        public IActionResult SaveScore(Score score)
        {
            //   _scoreService.AddScore(new Score() { PlayedAt = DateTime.Now, Player = Player, BrickScore = BrickScore });\
            score.PlayedAt = DateTime.Now;
            _scoreService.AddScore(score);
            return View("Index", CreateModel());
        }
        private BrickModel CreateModel()
        {
            var field = (Field)HttpContext.Session.GetObject(FieldSessionKey);
            var scores = _scoreService.GetTopScores();

            return new BrickModel { Field = field, Scores = scores };
        }
    }
}
    