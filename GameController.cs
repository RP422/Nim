﻿using System;
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

            string[] options = new string[games.GetLength(0) + 1]; // That +1 is for the quit option
            options[games.GetLength(0) - 1] = "Quit";

            for (int x = 0; x < games.GetLength(0); x++)
            {
                options[x] = games[x].GetPrompt();
            }

            do
            {
                choice = Menu(options);
                numGames = games[choice].GetType().ToString().Equals("Nim.CVCGame") ? GetNumCPUGames() : 1;
                //     I admit, that statement is a bit weird looking with so many method calls
                //     Basically we're looking to see if the game chosen was an instance of CVCGame
                //         and then using that boolean to decide if we want to call GetNumCPUGames()

                games[choice].DecideFirstMove();

                for (int x = 0; x < numGames; x++)
                {
                    games[choice].PlayGame();
                }
            } while (choice < games.GetLength(0));
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

        public int Menu(string[] options)
        {
            // Returns the index of the selected option
            int choice;
            bool validInput;
            do
            {
                Console.WriteLine("Pick an option:");
                for (int x = 0; x < options.GetLength(0); x++)
                {
                    Console.WriteLine((x + 1) + " - " + options[x]);
                }
                validInput = int.TryParse(Console.ReadLine(), out choice);
            } while (!validInput || (choice < 0 || choice >= options.GetLength(0)));

            return choice - 1;
        }
    }
}
