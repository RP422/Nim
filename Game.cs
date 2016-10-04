﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    public class Game
    {
        private static NimState[,,] states = new NimState[4, 6, 8];
        
        private bool turn;
        Board board = new Board();

        public Game(NimState[,,] states)
        {
            InitializeNimStates();
            Game g = new Game();
            GameReviewer.RegisterNimStates(states);
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

        public Game()
        {
            CPUPlayer.RegisterNimStates(states);
        }
        public void StartGame()
        {
            int quit;
            do
            {
                quit = StartGameType(Menu());
                board.ResetBoard();
            } while (quit != 4);
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
        public int StartGameType(int type)
        {
            DecideFirstMove();
            switch (type)
            {
                //PVP
                case 1:
                    PlayGame(new HumanPlayer("1"), new HumanPlayer("2"));
                    return type;
                //Player vs CPU
                case 2:
                    PlayGame(new HumanPlayer("1"), new CPUPlayer(board));
                    return type;
                //CPU vs CPU
                case 3:
                    int gameCount = GetNumCPUGames();
                    for (int x = 0; x < gameCount; x++)
                    {
                        PlayGame(new CPUPlayer(board), new CPUPlayer(board));
                    }
                    return type;
                //Quit
                default:
                    return 4;
            }
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

        public void DecideFirstMove()
        {
            Random r = new Random();
            turn = r.Next(2) == 0;
        }

        public void PlayGame(Player p1, Player p2)
        {
            List<int[]> currentMoveHistory = new List<int[]>();
            bool done = false;

            do
            {
                board.DisplayBoard();

                int[] move = turn ? p1.GetMove() : p2.GetMove();
                if (move[1] > 0)
                {
                    board.RemovePieces((move[0] - 1), move[1]);
                    currentMoveHistory.Add(board.GetBoardState());

                    done = GameOver(); //Checks if the player that just moved lost

                    if (!done)
                    {
                        ChangeTurn();
                    }
                }
            } while (!done);

            Console.WriteLine("{0} has lost", turn ? p1.GetName() : p2.GetName());
            GameReviewer.ReviewGame(currentMoveHistory);
        }
        public void ChangeTurn()
        {
            turn = !turn;
        }
        public bool GameOver()
        {
            return board.GameOver();
        }

        public void Reset()
        {
            board.ResetBoard();
        }
    }
}
