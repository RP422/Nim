using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    public class Program
    {
        private NimState[,,] states = new NimState[3, 5, 7];

        private int[] pieces = new int[3];

        static void Main(string[] args)
        {

        }

        private void InitializeNimStates()
        {
            // Builds every NimState object for learning purposes throughout runtime
            for(int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    for (int z = 0; z < 7; z++)
                    {
                        states[x, y, x] = new NimState();
                    }
                }
            }
        }

        private void ResetBoard()
        {
            // Resets the board to its initial state
            pieces[0] = 3;
            pieces[1] = 5;
            pieces[2] = 7;
        }
    }
}
