using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTime
{
    public abstract class Game
    {
        public abstract string Instructions { get; }
        protected abstract int MinNumPlayers { get; }
        protected abstract int MaxNumPlayers { get; }
        protected int NumPlayers { get; }

        protected abstract void Setup();        
        protected abstract bool IsGameOver();
        protected abstract void TakeTurn();
        protected abstract string CalculateWinner();

        public Game(int numOfPlayers)
        {
            NumPlayers = numOfPlayers;
        }

        /// <summary>
        /// Play an awesome game
        /// </summary>
        /// <returns>The Winner</returns>
        public string PlayGame()
        {
            if (NumPlayers < MinNumPlayers)
            {
                throw new Exception($"The minimum number of players is {MinNumPlayers}.");
            }

            if (NumPlayers > MaxNumPlayers)
            {
                throw new Exception($"The maximum number of players is {MaxNumPlayers}.");
            }

            Setup();

            while(!IsGameOver())
            {
                TakeTurn();
            }

            return CalculateWinner();
        }
    }
}
