using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    public class Game
    {              
        public Game()
        {
            performAction(Menu()); 
        }        
        //Gets user's input and returns an integer
        public static int Menu()
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
        public static void performAction(int action)
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
        public static int getNumCPUGames()
        {
            int numGames; bool valid;
            do
            {
                Console.WriteLine("How many games would you like the CPU to play against itself");
                valid = int.TryParse(Console.ReadLine(), out numGames);
            } while (!valid || numGames <= 0);
            return numGames;
        }
        public static void startPVPGame()
        {

        }
        public static void startPVCGame()
        {

        }
        public static void startCVCGame(int numGames)
        {

        }
    }
}
