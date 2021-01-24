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
            int y = currentCell.RowNumber;
            int x = currentCell.ColNumber;
            switch (chessPiece)
            {
                case "WhiteKing":

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

                case "WhiteKnight":
                    theGrid[currentCell.RowNumber + 2, currentCell.ColNumber + 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 2, currentCell.ColNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 2, currentCell.ColNumber + 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 2, currentCell.ColNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 1, currentCell.ColNumber + 2].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 1, currentCell.ColNumber - 2].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColNumber + 2].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColNumber - 2].LegalNextMove = true;
                    break;


                case "WhiteRook":
                    
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
                
                case "WhitePawn":
                    //if (isSafe(currentCell.RowNumber - 1, currentCell.ColNumber))
                    //{
                        if (theGrid[currentCell.RowNumber - 1, currentCell.ColNumber].CurrentlyOccupied == false)
                        { 
                            theGrid[currentCell.RowNumber - 1, currentCell.ColNumber].LegalNextMove = true;
                            if (y == 6)
                                theGrid[currentCell.RowNumber - 2, currentCell.ColNumber].LegalNextMove = true;
                        }
                    //}
                    break;

               

                

                case "WhiteQueen":
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

                case "WhiteBishop":
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



                case "BlackKing":

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

                case "BlackKnight":
                    theGrid[currentCell.RowNumber + 2, currentCell.ColNumber + 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 2, currentCell.ColNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 2, currentCell.ColNumber + 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 2, currentCell.ColNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 1, currentCell.ColNumber + 2].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 1, currentCell.ColNumber - 2].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColNumber + 2].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColNumber - 2].LegalNextMove = true;
                    break;


                case "BlackRook":
                  //  int y2 = currentCell.RowNumber;
                  //  int x2 = currentCell.ColNumber;
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

                case "BlackPawn":
                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColNumber))    
                    {
                        theGrid[currentCell.RowNumber + 1, currentCell.ColNumber].LegalNextMove = true;
                        if (y == 1)
                            theGrid[currentCell.RowNumber + 2, currentCell.ColNumber].LegalNextMove = true;
                    }
                    break;


                case "BlackQueen":
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

                case "BlackBishop":
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

                /* case " ":
                     theGrid[currentCell.RowNumber, currentCell.ColNumber].LegalNextMove = true;*/


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
