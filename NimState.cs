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
        public int occuranceCount { get; private set; }

        public NimState()
        {
            averageState = 0;
            occuranceCount = 0;
        }

        public void AppendAverage(double value)
        {
            averageState = ((averageState * occuranceCount) + value) / (occuranceCount + 1);
            occuranceCount++;
        }
    }
}
