using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    public class Board
    {
        private static int[] pieces = new int[3];
        public const int NUM_ROWS = 3;
        public const int FIRST_ROW_LENGTH = 3;
        public const int SECOND_ROW_LENGTH = 5;
        public const int THIRD_ROW_LENGTH = 7;
        public Board()
        {
            ResetBoard();
        }

        public static void ResetBoard()
        {
            pieces[0] = FIRST_ROW_LENGTH;
            pieces[1] = SECOND_ROW_LENGTH;
            pieces[2] = THIRD_ROW_LENGTH;
        }

        public static int[] GetBoardState()
        {
            return (int[])pieces.Clone();
        }

        public static void RemovePieces(int row, int numRemoved)
        {
            if (numRemoved <= pieces[row])
            {
                pieces[row] -= numRemoved;
            }
        }

        public static bool GameOver()
        {
            return (pieces[0] == 0 && pieces[1] == 0 && pieces[2] == 0);
        }

        public static void DisplayBoard()
        {
            for (int i = 0; i < NUM_ROWS; i++)
            {
                Console.Write( (i + 1) +":");
                for (int j = 0; j < pieces[i]; j++)
                {
                    Console.Write(" X ");
                }
                Console.WriteLine();
            }
        }
    }
}