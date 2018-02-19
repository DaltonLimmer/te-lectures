using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.Classes
{
    public class Bowling
    {
        const int MaxFrameScore = 10;
        const int Strike = MaxFrameScore;

        private int[] _balls = new int[21];
        private int _ballCtr = 0;

        public int Score
        {
            get
            {
                return Scoring(_balls);
            }
        }

        public Bowling()
        {
        }

        /// <summary>
        /// Adds the pins knocked down to the score
        /// </summary>
        /// <param name="pinsKnockedDown">Number of pins knocked down</param>
        public void AddScore(int pinsKnockedDown)
        {
            if (_ballCtr < 20)
            {
                _balls[_ballCtr] = pinsKnockedDown;
                _ballCtr++;
            }
            else
            {
                throw new Exception("Game Over");
            }
        }

        /// <summary>
        /// Scores an entire game of bowling
        /// </summary>
        /// <param name="balls">Array of all the ball scores</param>
        /// <returns>Returns the total score</returns>
        public int Scoring(int[] balls)
        {
            int result = 0;
            
            // Scores all the balls for frames 1 - 9
            for (int ballCtr = 0; ballCtr < 18; ballCtr += 2)
            {
                result += ScoreFrame(balls[ballCtr], 
                                     balls[ballCtr + 1], 
                                     balls[ballCtr + 2], 
                                     balls[ballCtr + 3], 
                                     balls[ballCtr + 4]);
            }

            // Scores the last 3 balls of the array for frame 10
            result += ScoreTenthFrame(balls[18], balls[19], balls[20]);

            return result;
        }

        private int ScoreFrame(int f1B1, int f1B2, int f2B1, int f2B2, int f3B1)
        {
            int result = f1B1 + f1B2;
            bool isStrike = (f1B1 == Strike);
            bool isSpare = ((f1B1 + f1B2) == MaxFrameScore) && !isStrike;

            // If we are a strike in the first frame
            if (isStrike)
            {
                if (f2B1 == Strike)
                {
                    result += (f2B1 + f3B1);
                }
                else
                {
                    result += (f2B1 + f2B2);
                }
            }
            // If we are a spare in the first frame
            else if (isSpare)
            {
                result += f2B1;
            }

            return result;
        }

        private int ScoreTenthFrame(int ball1, int ball2, int ball3)
        {
            int result = ball1 + ball2;

            // If we are a strike on the first ball
            if (ball1 == Strike || (ball1 + ball2 == MaxFrameScore))
            {
                result += ball3;
            }

            return result;
        }
    }
}
