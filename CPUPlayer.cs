using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    public class CPUPlayer : Player
    {
        private static List<int[]> bestmoves = new List<int[]>();
        private static NimState[,,] nimStates;
        
        public static void RegisterNimStates(NimState[,,] states)
        {
            nimStates = states;
        }

        //Randomly generates a simple CPU move
        public override string GetMove()
        {
            LookForBestMove(Game.pieces);
            string move = "";
            bool validInput;
            int row, amount = 0;
            Random r = new Random();
            int[] hi = bestmoves[r.Next(bestmoves.Count)];
            Console.WriteLine(hi[0] + "" + hi[1] + hi[2]);
            //do
            //{
            //    row = r.Next(1, Game.pieces.Length + 1);
            //    validInput = Game.pieces[row - 1] > 0;
            //    if (validInput)
            //    {
            //        Console.WriteLine("There are {0} pieces on {1} left", Game.pieces[row - 1], row);

            //    }
            //} while (!validInput);
            //do
            //{
            //    amount = r.Next(1, Game.pieces[row - 1]);
            //    validInput = amount <= Game.pieces[row - 1] && amount > 0;
            //} while (!validInput);
            //Console.WriteLine("Computer is removing {0} pieces from row {1}", amount, row);
            if (hi[0] != Game.pieces[0])
            {
                amount = Game.pieces[0] - hi[0];
                row = 1;
            }
            else if (hi[1] != Game.pieces[1])
            {
                amount = Game.pieces[1] - hi[1];
                row = 2;
            }
            else
            {
                amount = Game.pieces[2] - hi[2];
                row = 3;
            }
            move += row;
            move += amount;
            return move;
        }

        public void LookForBestMove(int[] currentState)
        {
            for (int i = 0; i < 3; i++)
            {
            int[] temp = (int[])currentState.Clone();
                while (temp[i] > 0)
                {
                    temp[i]--;
                    BetterMove(temp);
                }
            }
        }

        private void BetterMove(int[] temp)
        {
            if (bestmoves.Count > 0)
            {
                int[] storedBestMove = bestmoves[0];
                double movesAverage = nimStates[temp[0], temp[1], temp[2]].averageState;
                if (movesAverage > nimStates[storedBestMove[0], storedBestMove[1], storedBestMove[2]].averageState)
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
