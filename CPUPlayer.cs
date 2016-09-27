using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    public class CPUPlayer : Player
    {
        private static NimState[,,] nimStates;
        public override string GetMove()
        {
            throw new NotImplementedException();
        }

        public static void InitializeNimStates(NimState[,,] states)
        {
            nimStates = states;
        }
    }
}
