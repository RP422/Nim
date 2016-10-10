using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    class CVCGame : Game
    {
        public override void CreatePlayers()
        {
            p1 = new CPUPlayer(GetBoard());
            p2 = new CPUPlayer(GetBoard());
        }

        public override string GetPrompt()
        {
            return "CVC";
        }
    }
}
