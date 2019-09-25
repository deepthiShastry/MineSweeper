﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineSweeper
{
    class Panel
    {
        public int ID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int AdjacentMines { get; set; }
        public bool IsFlagged { get; set; }
        public bool IsShown { get; set; }
        public bool IsMine { get; set; }

        public Panel(int id, int x, int y)
        {
            ID = id;
            X = x;
            Y = y;
        }
    }
}
