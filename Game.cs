using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    public class Game
    {
        private NimState[,,] states = new NimState[4, 6, 8];
        private List<int[]> currentMoveHistory = new List<int[]>();

        private int[] pieces = new int[3];
        private bool turn;

        public static void Main(string[] args)
        {
            Game g = new Game();
        }

        private void InitializeNimStates()
        {
            // Builds every NimState object for learning purposes throughout runtime
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    for (int z = 0; z < 8; z++)
                    {
                        states[x, y, x] = new NimState();
                    }
                }
            }
        }
        private void InstantiateBoard()
        {
            // Resets the board to its initial state
            pieces[0] = 3;
            pieces[1] = 5;
            pieces[2] = 7;
        }

        public Game()
        {
            startGame();
        }
        public void startGame()
        {
            InstantiateBoard();    // Move the do-while game restart stuff to here
            performAction(Menu()); // That'll dodge stack problems
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
        public void performAction(int action) // Rename to StartGameType
        {                                     // Rename the parameter to type; Change parameter type to an enum?
            switch (action)
            {
                //Start a PVP game
                case 1:
                    startPVPGame();
                    break;
                //Start a Player vs CPU game
                case 2:
                    startPVCGame();
                    break;
                //Start a CPU vs CPU Game
                //Ask how many games to play
                case 3:
                    startCVCGame(getNumCPUGames());
                    break;
                //Quit the game
                default:
                    break;
            }
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

        public void randomTurn() // Rename to DecideFirstMove
        {
            Random r = new Random();
            turn = (r.Next(0, 11) % 2 == 0);
        }

       
        public void PlayPVPTurn() // Change this block to use 3 methods: Player turn, CPU turn, and a turn change
        {                         // Use interface for a Player type object? Superclass/Subclass?
            bool done, validInput;
            int row, amount = 0;
            do
            {
                //Players' turn
                do
                {
                    displayBoard();
                    Console.WriteLine("Player {0}, please pick a row", turn ? "1" : "2");
                    validInput = int.TryParse(Console.ReadLine(), out row) && row > 0 && row - 1 < pieces.Length;
                    if (validInput)
                    {
                        Console.WriteLine("Player {0}, please pick an amount", turn ? "1" : "2");
                        validInput = (int.TryParse(Console.ReadLine(), out amount) && amount <= pieces[row-1] && amount > 0);
                    }
                } while (!validInput);
                pieces[row-1] -= amount;
                //checks if the game is over after each move
                done = isOver();                
                if (done)
                {
                    if (turn)
                    {
                        Console.WriteLine("Player 1 has lost");
                    }
                    else
                    {
                        Console.WriteLine("Player 2 has lost");
                    }
                }
                changeTurn();
            } while (!done);
            startGame();
        }
        public void PlayPVCTurn()
        {

        }
        public void changeTurn()
        {
            turn = !turn;
        }

        public bool isOver()  // Rename to GameOver()?
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
        
    }
}
