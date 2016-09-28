using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    public abstract class Player
    {
        public abstract int[] GetMove();
        public abstract string GetName();
    }
}
