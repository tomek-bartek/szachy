using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess1
{
    public class Board
    {
        public int Size { get; set; }
        public Cell[,] theGrid { get; set; }

        public Board(int s)
        {
            Size = s;
            theGrid = new Cell[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j] = new Cell(i, j);
                }
            }
        }

        public void MarkNextLegalMoves(Cell currentCell, string chessPiece)
        {
            //czyszczę tablicę
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j].LegalNextMove = false;
                    theGrid[i, j].CurrentlyOccupied = false;
                }
            }
            //oznaczneie legalnych ruchów

            switch (chessPiece)
            {
                case "King":
                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColNumber))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColNumber].LegalNextMove = true;
                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColNumber - 1))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColNumber - 1].LegalNextMove = true;
                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColNumber + 1))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColNumber + 1].LegalNextMove = true;
                    if (isSafe(currentCell.RowNumber, currentCell.ColNumber + 1))
                        theGrid[currentCell.RowNumber, currentCell.ColNumber + 1].LegalNextMove = true;
                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColNumber + 1))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColNumber + 1].LegalNextMove = true;
                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColNumber))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColNumber].LegalNextMove = true;
                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColNumber - 1))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColNumber - 1].LegalNextMove = true;
                    if (isSafe(currentCell.RowNumber, currentCell.ColNumber - 1))
                        theGrid[currentCell.RowNumber, currentCell.ColNumber - 1].LegalNextMove = true;
                    break;

                case "Knight":
                    theGrid[currentCell.RowNumber + 2, currentCell.ColNumber + 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 2, currentCell.ColNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 2, currentCell.ColNumber + 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 2, currentCell.ColNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 1, currentCell.ColNumber + 2].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 1, currentCell.ColNumber - 2].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColNumber + 2].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColNumber - 2].LegalNextMove = true;
                    break;


                case "Rook":
                    int y = currentCell.RowNumber;
                    int x = currentCell.ColNumber;
                    for (int i = 0; i < Size; i++)
                    {
                        if (y == (i))
                        {
                            for (int j = 0; j < Size; j++)
                            {
                                if (theGrid[i, j].CurrentlyOccupied == true)
                                {; }
                                else
                                {
                                    theGrid[i, j].LegalNextMove = true;
                                }

                            }

                        }
                        else
                        {
                            theGrid[i, x].LegalNextMove = true;

                        }

                    }
                    break;

                case "PawnWhite":
                    if (isSafe(currentCell.RowNumber-1, currentCell.ColNumber)) 
                        theGrid[currentCell.RowNumber-1, currentCell.ColNumber].LegalNextMove = true;
                    
                    break;

                case "PawnBlack":
                    if (isSafe(currentCell.RowNumber+1, currentCell.ColNumber))
                        theGrid[currentCell.RowNumber+1, currentCell.ColNumber].LegalNextMove = true;
                    break;

                case "Queen":
                    for (int i = 0; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber - i, currentCell.ColNumber - i))
                            theGrid[currentCell.RowNumber - i, currentCell.ColNumber - i].LegalNextMove = true;
                        if (isSafe(currentCell.RowNumber - i, currentCell.ColNumber))
                            theGrid[currentCell.RowNumber - i, currentCell.ColNumber].LegalNextMove = true;
                        if (isSafe(currentCell.RowNumber - i, currentCell.ColNumber + i))
                            theGrid[currentCell.RowNumber - i, currentCell.ColNumber + i].LegalNextMove = true;
                        if (isSafe(currentCell.RowNumber, currentCell.ColNumber + i))
                            theGrid[currentCell.RowNumber, currentCell.ColNumber + i].LegalNextMove = true;
                        if (isSafe(currentCell.RowNumber + i, currentCell.ColNumber + i))
                            theGrid[currentCell.RowNumber + i, currentCell.ColNumber + i].LegalNextMove = true;
                        if (isSafe(currentCell.RowNumber + i, currentCell.ColNumber))
                            theGrid[currentCell.RowNumber + i, currentCell.ColNumber].LegalNextMove = true;
                        if (isSafe(currentCell.RowNumber + i, currentCell.ColNumber - i))
                            theGrid[currentCell.RowNumber + i, currentCell.ColNumber - i].LegalNextMove = true;
                        if (isSafe(currentCell.RowNumber, currentCell.ColNumber - i))
                            theGrid[currentCell.RowNumber, currentCell.ColNumber - i].LegalNextMove = true;
                    }
                    break;

                case "Bishop":
                    for (int i = 1; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber - i, currentCell.ColNumber - i))
                            theGrid[currentCell.RowNumber - i, currentCell.ColNumber - i].LegalNextMove = true;
                        if (isSafe(currentCell.RowNumber - i, currentCell.ColNumber + i))
                            theGrid[currentCell.RowNumber - i, currentCell.ColNumber + i].LegalNextMove = true;
                        if (isSafe(currentCell.RowNumber + i, currentCell.ColNumber + i))
                            theGrid[currentCell.RowNumber + i, currentCell.ColNumber + i].LegalNextMove = true;
                        if (isSafe(currentCell.RowNumber + i, currentCell.ColNumber - i))
                            theGrid[currentCell.RowNumber + i, currentCell.ColNumber - i].LegalNextMove = true;
                    }
                    break;
                

                default:
                    break;
            }

            theGrid[currentCell.RowNumber, currentCell.ColNumber].CurrentlyOccupied = true;
        }

        public bool isSafe(int row, int col)
        {
            if (row >= 0 && col >= 0 && row < Size && col < Size)
                return true;
            else 
                return false;

        }

        


    }
}
