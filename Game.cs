using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    public class Game
    {
        private bool turn;
        private int[] pieces = new int[3];
        public Game()
        {
            startGame();
        }
        public void startGame()
        {
            int quit;
            do
            {
                InstantiateBoard();
                quit = performAction(Menu());
            } while (quit != 4);
        }
        //Gets user's input and returns an integer
        public int Menu()
        {
            int x;
            bool validInput;
            do
            {
                Console.WriteLine("Pick an option\n1:Player vs Player\n2:Player vs CPU\n3:CPU vs CPU\n4:Quit");
                validInput = int.TryParse(Console.ReadLine(), out x);
            } while (!validInput || (x <= 0 || x > 4));
            return x;
        }
        //Performs the action based on parameter passed in
        public int performAction(int action)
        {
            switch (action)
            {
                //Start a PVP game
                case 1:
                    startPVPGame();
                    return action;
                //Start a Player vs CPU game
                case 2:
                    startPVCGame();
                    return action;
                //Start a CPU vs CPU Game
                //Ask how many games to play
                case 3:
                    startCVCGame(getNumCPUGames());
                    return action;
                //Quit the game
                default:
                    return 4;
            }
        }
        //Get the number of CPU Games to be played
        //Returns an integer
        public int getNumCPUGames()
        {
            int numGames; bool valid;
            do
            {
                Console.WriteLine("How many games would you like the CPU to play against itself");
                valid = int.TryParse(Console.ReadLine(), out numGames);
            } while (!valid || numGames <= 0);
            return numGames;
        }
        public void startPVPGame()
        {
            randomTurn();
            PlayPVPTurn();
        }
        public void startPVCGame()
        {
            randomTurn();
        }
        public void startCVCGame(int numGames)
        {
            randomTurn();
        }
        public void randomTurn()
        {
            Random r = new Random();
            turn = (r.Next(0, 11) % 2 == 0);
        }
        public void changeTurn()
        {
            turn = !turn;
        }
        public void PlayPVPTurn()
        {
            bool done;            
            do
            {
                //Players' turn
                string move = getPlayerMove(false);
                pieces[int.Parse(move[0].ToString())-1] -= int.Parse(move[1].ToString());
                //checks if the game is over after each move
                done = isOver();
                if(!done) changeTurn();
            } while (!done);
            if (turn)
            {
                Console.WriteLine("Player 1 has lost");
            }
            else
            {
                Console.WriteLine("Player 2 has lost");
            }
            
        }
        public void PlayPVCTurn()
        {
            bool done, validInput;
            int row, amount;
        }
        //get the players' moves for a turn
        public string getPlayerMove(bool isCPU)
        {
            string move = "";
            bool validInput;
            int row, amount = 0;
            do
            {
                displayBoard();
                Console.WriteLine("{0}, please pick a row", isCPU ? "Player 1" : turn ? "Player 1" : "Player 2" );
                validInput = int.TryParse(Console.ReadLine(), out row) && row > 0 && row - 1 < pieces.Length;
                if (validInput)
                {
                    Console.WriteLine("{0}, please pick an amount", isCPU ? "Player 1" : turn ? "Player 1" : "Player 2");
                    validInput = (int.TryParse(Console.ReadLine(), out amount) && amount <= pieces[row - 1] && amount > 0);
                }
            } while (!validInput);
            move += row;
            move += amount;
            return move;
        }

        public bool isOver()
        {
            return (pieces[0] == 0 && pieces[1] == 0 && pieces[2] == 0);
        }
        public void displayBoard()
        {
            Console.Write("1:");
            for (int firstRow = 0; firstRow < pieces[0]; firstRow++)
            {
                Console.Write(" X ");
            }
            Console.WriteLine();

            Console.Write("2:");
            for (int secondRow = 0; secondRow < pieces[1]; secondRow++)
            {
                Console.Write(" X ");
            }
            Console.WriteLine();

            Console.Write("3:");
            for (int thirdRow = 0; thirdRow < pieces[2]; thirdRow++)
            {
                Console.Write(" X ");
            }
            Console.WriteLine();

        }
        private void InstantiateBoard()
        {
            // Resets the board to its initial state
            pieces[0] = 3;
            pieces[1] = 5;
            pieces[2] = 7;
        }
    }
}
