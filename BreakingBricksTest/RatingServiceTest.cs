using Microsoft.VisualStudio.TestTools.UnitTesting;
using BreakingBricksCore.Service;
using System;
using BreakingBricksCore.Entity;

namespace BreakingBricksTest
{
    [TestClass]
    public class RatingServiceTest
    {
        [TestMethod]

        public void AddRatingsTest()
        {
            var service = CreateService();
            service.AddRating(new Rating { ID = 1, Points = 3 });
            service.AddRating(new Rating { ID = 2, Points = 4 });


            Assert.AreEqual(2, service.GetTopRatings().Count);

        }
        [TestMethod]

       
        public IRatingService CreateService()
        {
            return new RatingServiceEF();
        }
    }

}