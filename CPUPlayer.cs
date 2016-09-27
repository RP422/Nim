using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    public class CPUPlayer : Player
    {
        List<int[]> bestmoves;
        private static NimState[,,] nimStates;
        //Randomly generates a simple CPU move

        public override string GetMove()
        {
            LookForBestMove(currentState);
            throw new NotImplementedException();
            string move = "";
            bool validInput;
            int row, amount = 0;
            Random r = new Random();
            do
            {
                row = r.Next(1, Game.pieces.Length + 1);
                validInput = Game.pieces[row - 1] > 0;
                if(validInput)
                {
                    Console.WriteLine("There are {0} pieces on {1} left",Game.pieces[row-1], row);

                }
            } while (!validInput);
            do
            {
                amount = r.Next(1, Game.pieces[row - 1]);
                validInput = amount <= Game.pieces[row - 1] && amount > 0;
            } while (!validInput) ;
            Console.WriteLine("Computer is removing {0} pieces from row {1}", amount, row);
            move += row;
            move += amount;
            return move;
        }

        public static void InitializeNimStates(NimState[,,] states)
        {
            nimStates = states;
        }

        public void LookForBestMove(int [] currentState)
        {
            int[] temp = currentState;
            for (int i = 0; i < 3; i++)
            {
                while (temp[i] > 0)
                {
                    temp[i]--;
                    BetterMove(temp);
                }
            }
        }

        private void BetterMove(int[] temp)
        {
            int[] storedBestMove = bestmoves[0];
            double movesAverage = nimStates[temp[0], temp[1], temp[2]].averageState;
            if(bestmoves.Count > 0)
            {
                if(movesAverage > nimStates[storedBestMove[0], storedBestMove[1], storedBestMove[2]].averageState)
                {
                    bestmoves.Clear();
                    bestmoves.Add(temp);
                }
                else if (movesAverage == nimStates[storedBestMove[0], storedBestMove[1], storedBestMove[2]].averageState)
                {
                    bestmoves.Add(temp);
                }
            }
            else
            {
                bestmoves.Add(temp);
            }
        }
    }
}
