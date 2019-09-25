using MineSweeperGenerator;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System;

namespace MineSweeper
{
    class Program
    {
        //static MineSweeperField field = MineSweeperFactory.CreateMineField(16, 16, 40);

        public MineSweeperField field { get; set; }
        public Random random { get; set; }
        public List<Panel> Panels { get; set; }

        static void Main(string[] args)
        {
            /*
             * You can play the game here: https://geekprank.com/minesweeper/
             * */
            
            try
            {
                // field.IdentifyBomb(0, 1);
                char input = 'S';
                while (input != 'Q')
                {
                    RunTypeCommands();

                    input = Console.ReadLine().ToUpper().First();

                    if (input == 'P')
                    {
                        PlayGame();
                    }
                }
            }
            catch (BombExplodedException)
            {
                // do stuff
            }
            catch (MineFieldClearedException)
            {
                // game won.
            }

        }

        private static void PlayCommands()
        {
            Console.WriteLine("Please enter a command to execute:");
            
            Console.WriteLine("B - Display Board");
            Console.WriteLine("N - New Game");
            Console.WriteLine("Q - Quit Game");
        }

        private static void RunTypeCommands()
        {
            Console.WriteLine("How do you want to play?");
            Console.WriteLine("P - Play Game");
            Console.WriteLine("Q - Quit");
        }

        private static void PlayGame()
        {
            char input = 'S';
            Random rand = new Random();
            while (input != 'Q')
            {
               
                    PlayCommands();
               
               
                    int x = 0, y = 0;
                    while (x <= 0)
                    {
                        //Get Horizontal Coordinate
                        Console.WriteLine("Enter horizontal coordinate:");
                        string xEntered = Console.ReadLine();
                        bool isValid = int.TryParse(xEntered, out x);
                    }

                    while (y <= 0)
                    {
                        Console.WriteLine("Enter vertical coordinate:");
                        string yEntered = Console.ReadLine();
                        bool isValid = int.TryParse(yEntered, out y);
                    }
                Chequered chequered = null;
                chequered.IdentifyPanel(x, y);
                chequered.Display();
                    
                    if (chequered.Status == Status.Failed)
                    {
                        Console.WriteLine("Game Over!");
                    }
                    //Check for board completion
                    if (chequered.Status == Status.Completed)
                    {
                        Console.WriteLine("CONGRATULATIONS!");
                    }
                }

                input = Console.ReadLine().ToUpper().First();
            
            }
        }

    }



