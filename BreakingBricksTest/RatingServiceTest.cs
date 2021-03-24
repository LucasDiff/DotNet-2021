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
            service.AddRating(new Rating { Player = "Jonas", PlayerRating = 3 });
            service.AddRating(new Rating { Player = "Judit", PlayerRating = 4 });


            Assert.AreEqual(2, service.GetTopRatings().Count);

        }

        [TestMethod]

        public void ResetRatingsTest()
        {
            var service = CreateService();
            service.AddRating(new Rating { Player = "Marian", PlayerRating = 2 });
            service.AddRating(new Rating { Player = "Erik", PlayerRating = 5 });

            service.ResetRatings();
            Assert.AreEqual(0, service.GetTopRatings().Count);

        }
        public IRatingService CreateService()
        {
            return new RatingServiceFile();
        }
    }
}