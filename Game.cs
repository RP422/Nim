using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    public abstract class Game
    {
        private static NimState[,,] states = new NimState[4, 6, 8];
        protected Player p1, p2;
        private bool turn;
        Board board = new Board();

        public Game(NimState[,,] states)
        {
            InitializeNimStates();
            GameReviewer.RegisterNimStates(states);
        }

        private static void InitializeNimStates()
        {
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    for (int z = 0; z < 8; z++)
                    {
                        states[x, y, z] = new NimState();
                    }
                }
            }
        }

        public Game()
        {
            CPUPlayer.RegisterNimStates(states);
        }

        public void DecideFirstMove()
        {
            Random r = new Random();
            turn = r.Next(2) == 0;
        }

        public void PlayGame()
        {
            List<int[]> currentMoveHistory = new List<int[]>();
            bool done = false;

            do
            {
                board.DisplayBoard();

                int[] move = turn ? p1.GetMove() : p2.GetMove();
                if (move[1] > 0)
                {
                    board.RemovePieces((move[0] - 1), move[1]);
                    currentMoveHistory.Add(board.GetBoardState());

                    done = GameOver();

                    if (!done)
                    {
                        ChangeTurn();
                    }
                }
            } while (!done);

            Console.WriteLine("{0} has lost", turn ? p1.GetName() : p2.GetName());
            GameReviewer.ReviewGame(currentMoveHistory);
            board.ResetBoard();
        }
        public void ChangeTurn()
        {
            turn = !turn;
        }
        public bool GameOver()
        {
            return board.GameOver();
        }
        
        public Board GetBoard()
        {
            return board;
        }
        public abstract void CreatePlayers();
        public abstract string GetPrompt();
    }
}
