﻿using System;
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
            InstantiateBoard();
            performAction(Menu());
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
        public void performAction(int action)
        {
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
