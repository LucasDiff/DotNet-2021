using Microsoft.VisualStudio.TestTools.UnitTesting;
using BreakingBricksCore.Service;
using System;
using BreakingBricksCore.Entity;

namespace BreakingBricksTest
{
    [TestClass]
    public class CommentServiceTest
    {
        [TestMethod]

        public void AddCommentsTest()
        {
            var service = CreateService();
            service.AddComment(new Comment { ID = 2134, Name = "Mariana", Content = "kedy bude update?" });
            service.AddComment(new Comment { ID = 6832, Name = "Martina", Content = "prilis lahke" });

            
            Assert.AreEqual(2, service.GetTopComments().Count);

        }

        [TestMethod]

       
        
        public ICommentService CreateService()
        {
            return new CommentServiceEF();
        }
    }
}
