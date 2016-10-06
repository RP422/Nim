﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    class PVCGame : Game
    {
        public override void CreatePlayers()
        {
            p1 = new HumanPlayer("1");
            p2 = new CPUPlayer(GetBoard());
        }

        public override string GetPrompt()
        {
            return "PVC";
        }
    }
}