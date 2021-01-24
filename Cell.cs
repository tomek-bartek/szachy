using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess1
{
    public class Cell
    {
            public int RowNumber { get; set; }
            public int ColNumber { get; set; }
            public bool CurrentlyOccupied { get; set; }
            public bool LegalNextMove { get; set; }
            public string PieceName { get; set; }

        public Player PieceColor;

        public Cell(int y, int x)
            {
                RowNumber = y;
                ColNumber = x;
            }
        

    }
}
