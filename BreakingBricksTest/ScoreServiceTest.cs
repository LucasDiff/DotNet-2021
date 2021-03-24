using Microsoft.VisualStudio.TestTools.UnitTesting;
using BreakingBricksCore.Service;
using System;
using BreakingBricksCore.Entity;

namespace BreakingBricksTest
{
    [TestClass]
    public class ScoreSeviceTest
    {
        
        [TestMethod]
        public void ScoreTest()
        {
            var service  = CreateService();
            service.AddScore(new Score { Player = "Lukas", BrickScore = 32064 });
            Assert.AreEqual(1, service.GetTopScores().Count);
            Assert.AreEqual("Lukas", service.GetTopScores()[0].Player);
            Assert.AreEqual(32064, service.GetTopScores()[0].BrickScore);
        }

        [TestMethod]
        public void ManyScoresTest()
        {
            var service = CreateService();
            service.AddScore(new Score { Player = "Lukas", BrickScore = 32064 });
            service.AddScore(new Score { Player = "Marek", BrickScore = 12980 });
            service.AddScore(new Score { Player = "Jan", BrickScore = 62128 });

            Assert.AreEqual(3, service.GetTopScores().Count);
            Assert.AreEqual("Jan", service.GetTopScores()[0].Player);
            Assert.AreEqual(62128, service.GetTopScores()[0].BrickScore);

            Assert.AreEqual("Lukas", service.GetTopScores()[1].Player);
            Assert.AreEqual(32064, service.GetTopScores()[1].BrickScore);

            Assert.AreEqual("Marek", service.GetTopScores()[2].Player);
            Assert.AreEqual(12980, service.GetTopScores()[2].BrickScore);
        }
        [TestMethod]
        public void ResetScoreTest()
        {
            var service = CreateService();
            service.AddScore(new Score { Player = "Lukas", BrickScore = 320 });
            service.AddScore(new Score { Player = "Marek", BrickScore = 640 });

            service.ResetScore();

            Assert.AreEqual(0, service.GetTopScores().Count);
        }


        public IScoreService CreateService()
        {
            return new ScoreServiceFile();
        }
    }
}
