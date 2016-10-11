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
        public static const int FIRST_ROW_LENGTH = 3;
        public static const int SECOND_ROW_LENGTH = 5;
        public static const int THIRD_ROW_LENGTH = 7;
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
            Console.Write("1:");
            for (int firstRow = 0; firstRow < pieces[0]; firstRow++)
            {
                Console.Write(" X ");
            }
            Console.WriteLine();

            Console.Write("2:");
            for (int secondRow = 0; secondRow < pieces[1]; secondRow++)
            {
                Console.Write(" X ");
            }
            Console.WriteLine();

            Console.Write("3:");
            for (int thirdRow = 0; thirdRow < pieces[2]; thirdRow++)
            {
                Console.Write(" X ");
            }
            Console.WriteLine();
        }
    }
}