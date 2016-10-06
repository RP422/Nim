using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    class GameController
    {
        private static NimState[,,] states = new NimState[4, 6, 8];
        private Game[] games = { new PVPGame(), new PVCGame(), new CVCGame() };

        public static void Main(string[] args)
        {
            InitializeNimStates();
            GameController control = new GameController();
        }

        public GameController()
        {
            StartGame();
        }

        private static void InitializeNimStates()
        {
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    for (int z = 0; z < 8; z++)
                    {
                        states[x, y, z] = new NimState();
                    }
                }
            }
        }

        public void StartGame()
        {
            int choice;
            int numGames;
            do
            {
                choice = Menu();
                numGames = games[choice].GetType().ToString().Equals("Nim.CVCGame") ? GetNumCPUGames() : 1;
                //     That last statement was a bit weird looking.
                //     Basically we're looking to see if the game chosen was an instance of CVCGame
                //         and then using that boolean to decide if we want to call GetNumCPUGames()

                games[choice].DecideFirstMove();

                for (int x = 0; x < numGames; x++)
                {
                    games[choice].PlayGame();
                }
            } while (choice < games.Length);
        }
        public int GetNumCPUGames()
        {
            int numGames; bool valid;
            do
            {
                Console.WriteLine("How many games would you like the CPU to play against itself");
                valid = int.TryParse(Console.ReadLine(), out numGames);
            } while (!valid || numGames <= 0);
            return numGames;
        }

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
    }
}
