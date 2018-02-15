using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameTime
{
    public class Chess : Game
    {
        private int _totalNumberOfTurns = 0;
        private int _numberOfTurnsPlayed = 1;

        public Chess(int numOfPlayers) : base (numOfPlayers)
        {
            Random random = new Random();
            _totalNumberOfTurns = random.Next(5, 15);
        }

        public override string Instructions
        {
            get
            {
                string beeps = "";
                for (int i = 0; i < NumPlayers; i++)
                {
                    Console.Beep();
                    if(i != 0)
                    {
                        beeps += " ";
                    }
                    beeps += "beep";
                }

                beeps = beeps.Substring(1);
                return $"Instructions: B{beeps}!";
            }
        }

        protected override int MinNumPlayers
        {
            get
            {
                return 2;
            }
        }

        protected override int MaxNumPlayers
        {
            get
            {
                return 2;
            }
        }

        protected override string CalculateWinner()
        {
            Random random = new Random();
            int winner = random.Next(1, NumPlayers+1);
            return winner.ToString();
        }

        protected override bool IsGameOver()
        {
            return (_numberOfTurnsPlayed >= _totalNumberOfTurns);
        }

        protected override void Setup()
        {
            Console.WriteLine("Game is setup");
        }

        protected override void TakeTurn()
        {
            Console.WriteLine($"Taking turn {_numberOfTurnsPlayed}");
            Thread.Sleep(1000);
            _numberOfTurnsPlayed++;
        }
    }
}
