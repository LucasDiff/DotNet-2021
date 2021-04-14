using System;
using System.Collections.Generic;
using System.Text;

namespace BreakingBricksCore.Service
{
    class CommentException : Exception
    {
        public CommentException(string message) : base(message)
        {
        }

        public CommentException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
