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
        public override string GetMove()
        {
            LookForBestMove(currentState);
            throw new NotImplementedException();
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
