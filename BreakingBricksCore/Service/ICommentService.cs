using System;
using System.Collections.Generic;
using System.Text;
using BreakingBricksCore.Entity;

namespace BreakingBricksCore.Service
{
    public interface ICommentService
    {
        void AddComment(Comment comment);
        IList<Comment> GetComments();
    }
}
