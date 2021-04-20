using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BreakingBricksCore.Service;
using BreakingBricksCore.Entity;

namespace BreakingBricksWeb.APIControllers
{
    //https://localhost:44321/api/Rating ?
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private IRatingService _ratingService = new RatingServiceEF();
        [HttpGet]
        public IEnumerable<Rating> GetTopRatings()
        {
            return _ratingService.GetTopRatings();
        }
        
        [HttpPost]
        public void PostRating(Rating rating)
        {
            
            _ratingService.AddRating(rating);
        }
    }
}