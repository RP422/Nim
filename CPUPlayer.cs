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
        public override int[] GetMove()
        {
            int[] move = new int[2];
            int[] moveState;

            int row, amount = 0;

            Random r = new Random();

            LookForBestMove(Game.pieces);

            if(bestmoves.Count > 0)
            {
                moveState = bestmoves[r.Next(bestmoves.Count)];
                Console.WriteLine(moveState[0] + "" + moveState[1] + moveState[2]);

                if (moveState[0] != Game.pieces[0])
                {
                    amount = Game.pieces[0] - moveState[0];
                    row = 1;
                }
                else if (moveState[1] != Game.pieces[1])
                {
                    amount = Game.pieces[1] - moveState[1];
                    row = 2;
                }
                else
                {
                    amount = Game.pieces[2] - moveState[2];
                    row = 3;
                }
                move[0] = row;
                move[1] = amount;

                bestmoves.Clear(); // We kinda forgot this line of code earlier. This is how we got piece replacement
            }

            return move;
        }

        public override string GetName()
        {
            return "Computer";
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
