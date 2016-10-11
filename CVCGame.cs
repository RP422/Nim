using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    class CVCGame : Game
    {
        protected override Player CreatePlayerOne()
        {
            return new CPUPlayer();
        }
        protected override Player CreatePlayerTwo()
        {
            return new CPUPlayer();
        }

        public override string GetPrompt()
        {
            return "CVC";
        }
    }
}
