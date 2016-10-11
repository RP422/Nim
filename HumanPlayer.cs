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
        public override int[] GetMove()
        {
            int[] move = new int[2];
            bool validInput;
            int row, amount = 0;

            int[] pieces = Board.GetBoardState();

            do
            {                
                Console.WriteLine("Player {0}, please pick a row", name);
                validInput = int.TryParse(Console.ReadLine(), out row) && row > 0 && row - 1 < pieces.Length;
                if (validInput)
                {
                    Console.WriteLine("Player {0}, please pick an amount",  name);
                    validInput = (int.TryParse(Console.ReadLine(), out amount) && amount <= pieces[row - 1] && amount > 0);
                }
            } while (!validInput);
            move[0] = row;
            move[1] = amount;
            return move;
        }
        public override string GetName()
        {
            return "Player " + name;
        }
    }
}
