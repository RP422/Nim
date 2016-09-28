using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    public class HumanPlayer : Player
    {
        public string name { get; set; }
        public HumanPlayer(string name)
        {
            this.name = name;
        }
        public override string GetMove()
        {
            string move = "";
            bool validInput;
            int row, amount = 0;
            do
            {                
                Console.WriteLine("Player {0}, please pick a row", name);
                validInput = int.TryParse(Console.ReadLine(), out row) && row > 0 && row - 1 < Game.pieces.Length;
                if (validInput)
                {
                    Console.WriteLine("Player {0}, please pick an amount",  name);
                    validInput = (int.TryParse(Console.ReadLine(), out amount) && amount <= Game.pieces[row - 1] && amount > 0);
                }
            } while (!validInput);
            move += row;
            move += amount;
            return move;
        }
        public override string GetName()
        {
            return "Player " + name;
        }
    }
}
