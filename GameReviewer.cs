using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    class GameReviewer
    {
        List<int[]> currentMoveHistory = new List<int[]>();
        NimState[,,] states = new NimState[4, 6, 8];
        public GameReviewer(List<int[]> currentMoveHistory, NimState[,,] states)
        {
            this.currentMoveHistory = currentMoveHistory;
            this.states = states;
        }
        public void ReviewGame()
        {
            int stateCountWin = currentMoveHistory.Count;
            int stateCountLose = stateCountWin;
            if (currentMoveHistory.Count % 2 == 1)
            {
                stateCountWin--;
            }

            int[] coordinates;
            double temp;
            temp = stateCountLose;
            for (int x = currentMoveHistory.Count - 1; x >= 0; x -= 2)
            {
                coordinates = currentMoveHistory[x];
                states[coordinates[0], coordinates[1], coordinates[2]].AppendAverage(temp / -stateCountLose);
                temp--;
            }

            temp = stateCountWin;
            for (int x = currentMoveHistory.Count - 2; x >= 0; x -= 2)
            {
                coordinates = currentMoveHistory[x];
                states[coordinates[0], coordinates[1], coordinates[2]].AppendAverage(temp / stateCountWin);
                temp--;
            }

            CPUPlayer.RegisterNimStates(states);

            currentMoveHistory.Clear(); // This line should be the last one called in the method
        }
    }
}
