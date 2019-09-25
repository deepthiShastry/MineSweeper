using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineSweeper
{
    class Chequered
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int MineCount { get; set; }
        public List<Panel> Panels { get; set; }
        public Status Status { get; set; }

        public List<Panel> GetNext(int x, int y)
        {
            return GetNext(x, y, 1);
        }

        public List<Panel> GetNext(int x, int y, int occupancy)
        {
            var nearbyPanels = Panels.Where(panel => panel.X >= (x - occupancy) && panel.X <= (x + occupancy)
                                                 && panel.Y >= (y - occupancy) && panel.Y <= (y + occupancy));
            var currentPanel = Panels.Where(panel => panel.X == x && panel.Y == y);
            return nearbyPanels.Except(currentPanel).ToList();
        }
        public void IdentifyPanel(int x, int y)
        {
            var selectedPanel = Panels.First(panel => panel.X == x && panel.Y == y);
            selectedPanel.IsShown = true;
            selectedPanel.IsFlagged = false; 

            if (selectedPanel.IsMine) Status = Status.Failed; 

            if (!selectedPanel.IsMine)
            {
                CompletionCheck();
            }
        }
        public void Display()
        {
            string output = "";
            foreach (var panel in Panels)
            {
                if (panel.X == 1)
                {
                    Console.WriteLine(output);
                    output = "";
                }
                if (panel.IsFlagged)
                {
                    output += "F ";
                }
                else if (!panel.IsShown)
                {
                    output += "U ";
                }
                else if (panel.IsShown && !panel.IsMine)
                {
                    output += panel.AdjacentMines + " ";
                }
                else if (panel.IsShown && panel.IsMine)
                {
                    output += "X ";
                }
            }
            Console.WriteLine(output); //Write the last line
        }

        private void CompletionCheck()
        {
            var hiddenPanels = Panels.Where(x => !x.IsShown).Select(x => x.ID);
            var minePanels = Panels.Where(x => x.IsMine).Select(x => x.ID);
            if (!hiddenPanels.Except(minePanels).Any())
            {
                Status = Status.Completed;
            }
        }

    }
}
