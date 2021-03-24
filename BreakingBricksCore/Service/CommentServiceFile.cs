using BreakingBricksCore.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace BreakingBricksCore.Service
{
    public class CommentServiceFile : ICommentService
    {
        private const string FileName = "comment.bin";

        private List<Comment> _comments = new List<Comment>();
        void ICommentService.AddComment(Comment comment)
        {
            _comments.Add(comment);
            SaveComments();
        }

        

        private void SaveComments()
        {
            using var fs = File.OpenWrite(FileName);
            var bf = new BinaryFormatter();
            bf.Serialize(fs, _comments);
        }

        IList<Comment> ICommentService.GetBestComments()
        {
            LoadComments();
            return (IList<Comment>)_comments.OrderByDescending(s => s.Content).Take(3).ToList();

        }

        void ICommentService.ResetComments()
        {
            _comments.Clear();
            File.Delete(FileName);
        }
        private void LoadComments()
        {
            if (File.Exists(FileName))
            {
                using var fs = File.OpenRead(FileName);
                var bf = new BinaryFormatter();
                _comments = (List<Comment>)bf.Deserialize(fs);
            }
        }
    }
}