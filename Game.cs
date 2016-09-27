using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    public class Game
    {
        private NimState[,,] states = new NimState[4, 6, 8]; // The coordinates here correspond to the number of pieces in each row
        private List<int[]> currentMoveHistory = new List<int[]>(); // The int arrays should always be 3 in length. They are corrdinates sets for states

        public static int[] pieces = new int[3];
        private bool turn;
        private bool isAgainstCPU;

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
            int quit;
            do
            {
                InstantiateBoard();
                quit = startGameType(Menu());
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
        public int startGameType(int type)
        {
            switch (type)
            {
                //Start a PVP game
                case 1:
                    startPVPGame();
                    isAgainstCPU = false;
                    return type;
                //Start a Player vs CPU game
                case 2:
                    startPVCGame();
                    isAgainstCPU = true;
                    return type;
                //Start a CPU vs CPU Game
                //Ask how many games to play
                case 3:
                    startCVCGame(getNumCPUGames());
                    return type;
                //Quit the game
                default:
                    return 4;
            }
        }

        public void startPVPGame()
        {
            DecideFirstMove();
            PlayGame();
        }
        public void startPVCGame()
        {
            DecideFirstMove();
        }

        public void startCVCGame(int numGames)
        {
            DecideFirstMove();
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

        public void DecideFirstMove() // Rename to DecideFirstMove
        {
            Random r = new Random();
            turn = (r.Next(0, 11) % 2 == 0);
        }
        public void PlayGame() // Change this block to use 3 methods: Player turn, CPU turn, and a turn change
        {                         // Use interface for a Player type object? Superclass/Subclass?
            bool done;
            if (isAgainstCPU)
            {
                HumanPlayer p1 = new HumanPlayer("1");
                CPUPlayer p2 = new CPUPlayer();
                do
                {
                    displayBoard();
                    //Players' turn
                    string move = getPlayerMove(true);
                    pieces[int.Parse(move[0].ToString()) - 1] -= int.Parse(move[1].ToString());
                    //checks if the game is over after each move
                    done = GameOver();
                    if (!done) changeTurn();
                } while (!done);
            }
            else
            {
                HumanPlayer p1 = new HumanPlayer("1");
                HumanPlayer p2 = new HumanPlayer("2");
                do
                {
                    displayBoard();
                    //Players' turn
                    string move = turn ? p1.GetMove() : p2.GetMove();
                    pieces[int.Parse(move[0].ToString()) - 1] -= int.Parse(move[1].ToString());
                    //checks if the game is over after each move
                    done = GameOver();
                    if (!done) changeTurn();
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
        }
        public void PlayPVCTurn()
        {
            bool done, validInput;
            int row, amount;

            throw new NotImplementedException();
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
                Console.WriteLine("{0}, please pick a row", isCPU ? "Player 1" : turn ? "Player 1" : "Player 2");
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
        public void changeTurn()
        {
            turn = !turn;
        }

        public bool GameOver()  // Rename to GameOver()?
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
