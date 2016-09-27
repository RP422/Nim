using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    public class Program
    {
        private NimState[,,] states = new NimState[4, 6, 8];
        private List<int[]> currentMoveHistory = new List<int[]>();

        public static void Main(string[] args)
        {
            Game g = new Game();
        }

        private void InitializeNimStates()
        {
            // Builds every NimState object for learning purposes throughout runtime
            for(int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    for (int z = 0; z < 8; z++)
                    {
                        states[x, y, x] = new NimState();
                    }
                }
            }
        }

      
    }
}
