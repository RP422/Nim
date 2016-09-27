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
        //Randomly generates a simple CPU move

        public override string GetMove()
        {
            string move = "";
            bool validInput;
            int row, amount = 0;
            Random r = new Random();
            do
            {
                row = r.Next(1, Game.pieces.Length + 1);
                validInput = Game.pieces[row - 1] > 0;
                if(validInput)
                {
                    Console.WriteLine("There are {0} pieces on {1} left",Game.pieces[row-1], row);

                }
            } while (!validInput);
            do
            {
                amount = r.Next(1, Game.pieces[row - 1]);
                validInput = amount <= Game.pieces[row - 1] && amount > 0;
            } while (!validInput) ;
            Console.WriteLine("Computer is removing {0} pieces from row {1}", amount, row);
            move += row;
            move += amount;
            return move;
        }

        public static void InitializeNimStates(NimState[,,] states)
        {
            nimStates = states;
        }
    }
}
