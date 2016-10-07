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
        private Game g;

        public static void Main(string[] args)
        {
            InitializeNimStates();
            Game g = new Game(states);
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
            int quit;
            do
            {
                quit = Menu();
                g.DecideFirstMove();
                switch (quit)
                {
                    //PVP game
                    case 1:
                        g.PlayGame(new HumanPlayer("1"), new HumanPlayer("2"));
                        break;
                    //Player vs CPU game
                    case 2:
                        g.PlayGame(new HumanPlayer("1"), new CPUPlayer(g.GetBoard()));
                        break;
                    //CPU vs CPU Game(s)
                    case 3:
                        int gameCount = GetNumCPUGames();
                        for (int x = 0; x < gameCount; x++)
                        {
                            g.PlayGame(new CPUPlayer(g.GetBoard()), new CPUPlayer(g.GetBoard()));
                        }
                        break;
                }

            } while (quit != 4);
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
