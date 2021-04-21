using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BreakingBricksCore.Entity;

namespace BreakingBricksCore.Service
{
    public class CommentServiceEF : ICommentService
    {
        public void AddComment(Comment comment)
        {
            using (var context = new BreakingBricksDbContext())
            {
                context.Comments.Add(comment);
                context.SaveChanges();
            }
        }
        public IList<Comment> GetComments()
        {
            using var context = new BreakingBricksDbContext();
            return (from s in context.Comments select s).ToList();

        }
        public void ResetComments()
        {
            using (var context = new BreakingBricksDbContext())
            {
                context.Database.ExecuteSqlRaw("DELETE FROM Comment");
            }
        }
        public IList<Comment> GetTopComments()
        {
            using (var context = new BreakingBricksDbContext())
            {

                return (from s in context.Comments select s).Take(3).ToList();
            }
        }

    }
    
}