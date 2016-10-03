using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    public class Game
    {
        private bool turn;
        Board board = new Board();

        public Game(NimState[,,] states)
        {
            CPUPlayer.RegisterNimStates(states);
        }
        
        public void DecideFirstMove()
        {
            Random r = new Random();
            turn = r.Next(2) == 0;
        }

        public void PlayGame(Player p1, Player p2)
        {                         
            bool done = false;
            do
            {
                board.DisplayBoard();

                int[] move = turn ? p1.GetMove() : p2.GetMove();
                if (move[1] > 0)
                {
                    board.RemovePieces((move[0] - 1), move[1]);
                    currentMoveHistory.Add(board.GetBoardState()); // Adds the move into the move history

                    done = GameOver(); //Checks if the player that just moved lost

                    if (!done)
                    {
                        ChangeTurn();
                    }
                }
            } while (!done);

            Console.WriteLine("{0} has lost", turn ? p1.GetName() : p2.GetName());
            ReviewGame();
        }
        public void ChangeTurn()
        {
            turn = !turn;
        }
        public bool GameOver()
        {
            return board.GameOver();
        }

        public void Reset()
        {
            board.ResetBoard();
        }


        //public void ReviewGame()
        //{
        //    int stateCountWin = currentMoveHistory.Count;
        //    int stateCountLose = stateCountWin;

        //    double temp;
        //    int[] coordinates;

        //    if (currentMoveHistory.Count % 2 == 1)
        //    {
        //        stateCountWin--;
        //    }

        //    temp = stateCountLose;
        //    Console.WriteLine("Starting temp: {0}", temp);
        //    for(int x = currentMoveHistory.Count - 1; x >= 0; x -= 2)
        //    {
        //        coordinates = currentMoveHistory[x];
        //        states[coordinates[0], coordinates[1], coordinates[2]].AppendAverage(temp / -stateCountLose);
        //        Console.WriteLine("{0}, {1}, {2} has value of {3}", coordinates[0], coordinates[1], coordinates[2], states[coordinates[0], coordinates[1], coordinates[2]].averageState);       
        //        temp--;
        //    }

        //    temp = stateCountWin;
        //    for (int x = currentMoveHistory.Count - 2; x >= 0; x -= 2)
        //    {
        //        coordinates = currentMoveHistory[x];

        //        states[coordinates[0], coordinates[1], coordinates[2]].AppendAverage(temp / stateCountLose);
        //        Console.WriteLine("{0}, {1}, {2} has value of {3}", coordinates[0], coordinates[1], coordinates[2], states[coordinates[0], coordinates[1], coordinates[2]].averageState);
                
        //        temp--;
        //    }
        //    DisplayAllStateValues();
        //    CPUPlayer.RegisterNimStates(states);

        //    currentMoveHistory.Clear(); // This line should be the last one called in the method
        //}
    }
}
