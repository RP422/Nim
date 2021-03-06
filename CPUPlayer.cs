﻿using System;
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
        public override int[] GetMove()
        {
            //Randomly generates a simple CPU move
            int[] move = new int[2];
            int[] moveState;
            int[] pieces = Board.GetBoardState();

            int row = 0, amount = 0;

            Random r = new Random();

            LookForBestMove(pieces);

            if (bestmoves.Count > 0)
            {
                moveState = bestmoves[r.Next(bestmoves.Count)];
                Console.WriteLine(moveState[0] + "" + moveState[1] + moveState[2]);

                for (int i = 0; i < Board.NUM_ROWS; i++)
                {
                    if (moveState[i] != pieces[i])
                    {
                        amount = pieces[i] - moveState[i];
                        row = i + 1;
                    }
                }
                move[0] = row;
                move[1] = amount;
                bestmoves.Clear();
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
                while (temp[i] > 0 && temp[0] + temp[1] + temp[2] > 1)// the added boolean makes sure it will try to go for the win
                {
                    temp[i]--;
                    BetterMove((int[])temp.Clone());
                }
                if (currentState[0] + currentState[1] + currentState[2] == 1)
                {
                    if (temp[i] > 0)
                    {
                        temp[i]--;
                        BetterMove((int[])temp.Clone());
                    }
                    //making sure that if it has to move it will
                }
            }
        }
        private void BetterMove(int[] prospectiveMove)
        {
            if (bestmoves.Count > 0)
            {
                int[] storedBestMove = bestmoves[0];
                double movesAverage = nimStates[prospectiveMove[0], prospectiveMove[1], prospectiveMove[2]].averageState;
                double bestMovesAverage = nimStates[storedBestMove[0], storedBestMove[1], storedBestMove[2]].averageState;
                if (movesAverage > bestMovesAverage)
                {
                    bestmoves.Clear();
                    bestmoves.Add(prospectiveMove);
                }
                else if (movesAverage == bestMovesAverage)
                {
                    bestmoves.Add(prospectiveMove);
                }
            }
            else
            {
                bestmoves.Add(prospectiveMove);
            }
        }
    }
}
