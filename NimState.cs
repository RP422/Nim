using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    public class NimState
    {
        public double averageState { get; private set; }
        private int occuranceCount { get; set; }

        public NimState()
        {
            // Sets the initial state
            averageState = 1;
            occuranceCount = 0;
        }

        public void AppendAverage(double value)
        {
            // Recalculates the average based on a value passed in
            // @param value A state value that has been calculated by the system's state quantifyer
            averageState = ((averageState * occuranceCount) + value) / (occuranceCount + 1);
            occuranceCount++;
        }
    }
}
