using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD.Classes;

namespace TDD.Tests.Classes
{
    [TestClass]
    public class BowlingTest
    {
        Bowling bowling = new Bowling();

        [TestMethod]
        public void Bowling_AllFramesGutterBall_ReturnsScore()
        {
            int[] balls = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int score = bowling.Scoring(balls);
            Assert.AreEqual(0, score, "The score for all gutter balls should have been zero.");
        }

        [TestMethod]
        public void Bowling_AllFramesOnePin_ReturnsScore()
        {
            int[] balls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 };
            int score = bowling.Scoring(balls);
            Assert.AreEqual(20, score, "The score for all 1 pin balls should have been 20.");
        }

        [TestMethod]
        // This will test a spare in the first frame followed by 3 pins in the second
        // frame and then all misses after that
        public void Bowling_FirstFrameSpare_ReturnsScore()
        {
            int[] balls = { 5, 5, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            bowling.AddScore(5);
            bowling.AddScore(5);
            bowling.AddScore(3);
            Assert.AreEqual(16, bowling.Score, "The score for a spare followed by 3 pins is 16.");
        }

        [TestMethod]
        // This will test a strike in the first frame followed by 3 pins and then 4 pins in the second
        // frame and then all misses after that
        public void Bowling_FirstFrameStrike_ReturnsScore()
        {
            int[] balls = { 10, 0, 3, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int score = bowling.Scoring(balls);
            Assert.AreEqual(24, score, "The score for a strike followed by 3 pins and then 4 is 24.");
        }

        [TestMethod]
        public void Bowling_PerfectGame_ReturnsScore()
        {
            int[] balls = { 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 10, 10 };
            int score = bowling.Scoring(balls);
            Assert.AreEqual(300, score, "The score a perfect game is 300.");
        }

        //[TestMethod]
        //public void ScoreTenthFrame_Turkey_ReturnsScore()
        //{
        //    int score = bowling.ScoreTenthFrame(10, 10, 10);
        //    Assert.AreEqual(30, score, "The score is a turkey.");
        //}

        //[TestMethod]
        //public void ScoreTenthFrame_Spare_ReturnsScore()
        //{
        //    int score = bowling.ScoreTenthFrame(5, 5, 7);
        //    Assert.AreEqual(17, score, "The score is 17.");
        //}

        //[TestMethod]
        //public void ScoreTenthFrame_NoSpareOrStrike_ReturnsScore()
        //{
        //    int score = bowling.ScoreTenthFrame(5, 4, 0);
        //    Assert.AreEqual(9, score, "The score is 9.");
        //}
    }
}
