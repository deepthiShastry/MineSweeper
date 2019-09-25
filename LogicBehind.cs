using MineSweeperGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineSweeper
{
    class LogicBehind : Chequered
    {
        public Random random { get; set; }
        public Chequered chequered { get; set; }
        public void InitiateGame(Random rand)
        {
            random = rand;
            int height = 0, width = 0, noOfBombs = 0;
            if (width <= 0)
            {
                Console.WriteLine("The width should be greater than 0.");
            }
            if (height <= 0)
            {
                Console.WriteLine("The heght should be greater than 0.");
            }
            if (noOfBombs <= 0)
            {
                Console.WriteLine("The number of bombs should be greater than 0.");

            }

            MineSweeperField field = null;

            //First move
            var randomX = random.Next(1, field.Width - 1);
            var randomY = random.Next(1, field.Height - 1);
        }

        /*public bool HiddenBox()
        {
            //Find the numbered square and the number of flags arounf it. the no of squares are equal to the number of flags
            var numberedSquare = Panels.Where(a => a.AdjacentMines > 0 && a.IsShown);
        }*/
        public void RandomMove()
        {
            var randomID = random.Next(1, chequered.Panels.Count);
            var panel = chequered.Panels.First(x => x.ID == randomID);
            while (panel.IsShown || panel.IsFlagged)
            {
                randomID = random.Next(1, chequered.Panels.Count);
                panel = chequered.Panels.First(x => x.ID == randomID);
            }

            chequered.IdentifyPanel(panel.X, panel.Y);
        }

        public bool HasAvailableMoves()
        {
            var numberedPanels = chequered.Panels.Where(x => x.IsShown && x.AdjacentMines > 0);
           
            foreach (var numberPanel in numberedPanels)
            {
                var adjacentPanels = chequered.GetNext(numberPanel.X, numberPanel.Y);
                var flaggedNeighbors = adjacentPanels.Where(x => x.IsFlagged);
                if (flaggedNeighbors.Count() == numberPanel.AdjacentMines && adjacentPanels.Any(x => !x.IsShown && !x.IsFlagged))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
