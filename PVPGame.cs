﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    class PVPGame : Game
    {

        protected override Player CreatePlayerOne()
        {
            return new HumanPlayer("1");
        }
        protected override Player CreatePlayerTwo()
        {
            return new HumanPlayer("2");
        }

        public override string GetPrompt()
        {
            return "PVP";
        }
    }
}
