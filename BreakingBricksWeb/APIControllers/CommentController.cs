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
    //https://localhost:44321/api/Comment ?
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private ICommentService _commentService = new CommentServiceEF();
        [HttpGet]
        public IEnumerable<Comment>GetComments()
        {
            return _commentService.GetComments();
        }

        [HttpPost]
        public void PostComment(Comment comment)
        {
            comment.PlayedAt = DateTime.Now;
            _commentService.AddComment(comment);
        }
    }
}