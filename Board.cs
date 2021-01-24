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

                    if (isSafe(y - 1, x) && !theGrid[y - 1, x].PieceName.Contains("White"))
                        theGrid[y - 1, x].LegalNextMove = true;
                    if (isSafe(y - 1, x - 1) && !theGrid[y - 1, x - 1].PieceName.Contains("White"))
                        theGrid[y - 1, x - 1].LegalNextMove = true;
                    if (isSafe(y - 1, x + 1) && !theGrid[y - 1, x + 1].PieceName.Contains("White"))
                        theGrid[y - 1, x + 1].LegalNextMove = true;
                    if (isSafe(y, x + 1) && !theGrid[y, x + 1].PieceName.Contains("White"))
                        theGrid[y, x + 1].LegalNextMove = true;
                    if (isSafe(y + 1, x + 1) && !theGrid[y + 1, x + 1].PieceName.Contains("White"))
                        theGrid[y + 1, x + 1].LegalNextMove = true;
                    if (isSafe(y + 1, x) && !theGrid[y + 1, x].PieceName.Contains("White"))
                        theGrid[y + 1, x].LegalNextMove = true;
                    if (isSafe(y + 1, x - 1) && !theGrid[y + 1, x - 1].PieceName.Contains("White"))
                        theGrid[y + 1, x - 1].LegalNextMove = true;
                    if (isSafe(y, x - 1) && !theGrid[y, x - 1].PieceName.Contains("White"))
                        theGrid[y, x - 1].LegalNextMove = true;
                    break;

                case "WhiteKnight":
                    
                    if (isSafe(y + 2, x + 1) && !theGrid[y + 2, x + 1].PieceName.Contains("White"))
                    {
                        theGrid[y + 2, x + 1].LegalNextMove = true;
                    }
                    if (isSafe(y + 2, x - 1) && !theGrid[y + 2, x - 1].PieceName.Contains("White"))
                    {
                        theGrid[y + 2, x - 1].LegalNextMove = true;
                    }
                    if (isSafe(y - 2, x + 1) && !theGrid[y - 2, x + 1].PieceName.Contains("White"))
                    {
                        theGrid[y - 2, x + 1].LegalNextMove = true;
                    }
                    if (isSafe(y - 2, x - 1) && !theGrid[y - 2, x - 1].PieceName.Contains("White"))
                    {
                        theGrid[y - 2, x - 1].LegalNextMove = true;
                    }
                    if (isSafe(y + 1, x + 2) && !theGrid[y + 1, x + 2].PieceName.Contains("White"))
                    {
                        theGrid[y + 1, x + 2].LegalNextMove = true;
                    }
                    if (isSafe(y + 1, x - 2) && !theGrid[y + 1, x - 2].PieceName.Contains("White"))
                    {
                        theGrid[y + 1, x - 2].LegalNextMove = true;
                    }
                    if (isSafe(y - 1, x + 2) && !theGrid[y - 1, x + 2].PieceName.Contains("White"))
                    {
                        theGrid[y - 1, x + 2].LegalNextMove = true;
                    }
                    if (isSafe(y - 1, x - 2) && !theGrid[y - 1, x - 2].PieceName.Contains("White"))
                    {
                        theGrid[y - 1, x - 2].LegalNextMove = true;
                    }
                    break;

                case "WhiteRook":

                    //checkLine(Cell currentCell, - 1, 0);
                    for (int i = 1; i < Size; i++)
                    {
                        if (isSafe(y - i, x))
                        {
                            if (theGrid[y - i, x].PieceName.Contains("White"))
                            {
                                break;
                            }
                            else if (theGrid[y - i, x].PieceName.Contains("Black"))
                            {
                                theGrid[y - i, x].LegalNextMove = true;
                                break;
                            }
                            else
                                theGrid[y - i, x].LegalNextMove = true;

                        }
                        else break;
                    }
                    for (int i = 1; i < Size; i++)
                    {
                        if (isSafe(y + i, x))
                        {
                            if (theGrid[y + i, x].PieceName.Contains("White"))
                            {
                                break;
                            }
                            else if (theGrid[y + i, x].PieceName.Contains("Black"))
                            {
                                theGrid[y + i, x].LegalNextMove = true;
                                break;
                            }
                            else
                                theGrid[y + i, x].LegalNextMove = true;

                        }
                        else break;
                    }

                    for (int i = 1; i < Size; i++)
                    {

                        if (isSafe(y, x - i))
                        {
                            if (theGrid[y, x - i].PieceName.Contains("White")) 
                            {
                                break;
                            }
                            else if (theGrid[y, x - i].PieceName.Contains("Black"))
                            {
                                theGrid[y, x - i].LegalNextMove = true;
                                break;
                            }
                            else
                                theGrid[y, x - i].LegalNextMove = true;
                        }
                        else break;
                    }
                    for (int i = 1; i < Size; i++)
                    {
                        if (isSafe(y, x + i))
                        {
                            if (theGrid[y, x + i].PieceName.Contains("White"))
                            {
                                break;
                            }
                            else if (theGrid[y, x + i].PieceName.Contains("Black"))
                            {
                                theGrid[y, x + i].LegalNextMove = true;
                                break;
                            }
                            else
                                theGrid[y, x + i].LegalNextMove = true;
                        }
                        else break;
                    }

                    break;

                case "WhitePawn":
                    if (isSafe(y - 1, x))
                    {
                        if (theGrid[y - 1, x].PieceName.Equals(""))
                        { 
                            theGrid[y - 1, x].LegalNextMove = true;
                            if (y == 6 && theGrid[y - 2, x].PieceName.Equals(""))
                                theGrid[y - 2, x].LegalNextMove = true;
                        }

                    }
                    if (isSafe(y - 1, x - 1))
                        if (theGrid[y - 1, x - 1].PieceName.Contains("Black"))
                        {
                            theGrid[y - 1, x - 1].LegalNextMove = true;
                        }
                    if (isSafe(y - 1, x + 1))
                        if (theGrid[y - 1, x + 1].PieceName.Contains("Black"))
                        {
                            theGrid[y - 1, x + 1].LegalNextMove = true;
                        }
                    break;

        
                case "WhiteQueen":
                    for (int i = 1; i < Size; i++)
                    {
                        if (isSafe(y - i, x))
                        {
                            if (theGrid[y - i, x].PieceName.Contains("White"))
                            {
                                break;
                            }
                            else if (theGrid[y - i, x].PieceName.Contains("Black"))
                            {
                                theGrid[y - i, x].LegalNextMove = true;
                                break;
                            }
                            else
                                theGrid[y - i, x].LegalNextMove = true;

                        }
                        else break;
                    }
                    for (int i = 1; i < Size; i++)
                    {
                        if (isSafe(y + i, x))
                        {
                            if (theGrid[y + i, x].PieceName.Contains("White"))
                            {
                                break;
                            }
                            else if (theGrid[y + i, x].PieceName.Contains("Black"))
                            {
                                theGrid[y + i, x].LegalNextMove = true;
                                break;
                            }
                            else
                                theGrid[y + i, x].LegalNextMove = true;

                        }
                        else break;
                    }

                    for (int i = 1; i < Size; i++)
                    {

                        if (isSafe(y, x - i))
                        {
                            if (theGrid[y, x - i].PieceName.Contains("White"))
                            {
                                break;
                            }
                            else if (theGrid[y, x - i].PieceName.Contains("Black"))
                            {
                                theGrid[y, x - i].LegalNextMove = true;
                                break;
                            }
                            else
                                theGrid[y, x - i].LegalNextMove = true;
                        }
                        else break;
                    }
                    for (int i = 1; i < Size; i++)
                    {
                        if (isSafe(y, x + i))
                        {
                            if (theGrid[y, x + i].PieceName.Contains("White"))
                            {
                                break;
                            }
                            else if (theGrid[y, x + i].PieceName.Contains("Black"))
                            {
                                theGrid[y, x + i].LegalNextMove = true;
                                break;
                            }
                            else
                                theGrid[y, x + i].LegalNextMove = true;
                        }
                        else break;
                    }
                    for (int i = 1; i < Size; i++)
                    {
                        if (isSafe(y - i, x - i))
                        {
                            if (theGrid[y - i, x - i].PieceName.Contains("White"))
                            {
                                break;
                            }
                            else if (theGrid[y - i, x - i].PieceName.Contains("Black"))
                            {
                                theGrid[y - i, x - i].LegalNextMove = true;
                                break;
                            }
                            else
                                theGrid[y - i, x - i].LegalNextMove = true;

                        }
                        else break;
                    }
                    for (int i = 1; i < Size; i++)
                    {
                        if (isSafe(y - i, x + i))
                        {
                            if (theGrid[y - i, x + i].PieceName.Contains("White"))
                            {
                                break;
                            }
                            else if (theGrid[y - i, x + i].PieceName.Contains("Black"))
                            {
                                theGrid[y - i, x + i].LegalNextMove = true;
                                break;
                            }
                            else
                                theGrid[y - i, x + i].LegalNextMove = true;

                        }
                        else break;
                    }
                    for (int i = 1; i < Size; i++)
                    {
                        if (isSafe(y + i, x + i))
                        {
                            if (theGrid[y + i, x + i].PieceName.Contains("White"))
                            {
                                break;
                            }
                            else if (theGrid[y + i, x + i].PieceName.Contains("Black"))
                            {
                                theGrid[y + i, x + i].LegalNextMove = true;
                                break;
                            }
                            else
                                theGrid[y + i, x + i].LegalNextMove = true;

                        }
                        else break;
                    }
                    for (int i = 1; i < Size; i++)
                    {
                        if (isSafe(y + i, x - i))
                        {
                            if (theGrid[y + i, x - i].PieceName.Contains("White"))
                            {
                                break;
                            }
                            else if (theGrid[y + i, x - i].PieceName.Contains("Black"))
                            {
                                theGrid[y + i, x - i].LegalNextMove = true;
                                break;
                            }
                            else
                                theGrid[y + i, x - i].LegalNextMove = true;
                        }
                        else break;
                    }
                    break;

                case "WhiteBishop":
                    for (int i = 1; i < Size; i++)
                    {
                        if (isSafe(y - i, x - i))
                        {
                            if (theGrid[y - i, x - i].PieceName.Contains("White"))
                            {
                                break;
                            }
                            else if (theGrid[y - i, x - i].PieceName.Contains("Black"))
                            {
                                theGrid[y - i, x - i].LegalNextMove = true;
                                break;
                            }
                            else
                                theGrid[y - i, x - i].LegalNextMove = true;

                        }   else break;
                    }
                    for (int i = 1; i < Size; i++)
                    {
                        if (isSafe(y - i, x + i))
                        {
                            if (theGrid[y - i, x + i].PieceName.Contains("White"))
                            {
                                break;
                            }
                            else if (theGrid[y - i, x + i].PieceName.Contains("Black"))
                            {
                                theGrid[y - i, x + i].LegalNextMove = true;
                                break;
                            }
                            else
                                theGrid[y - i, x + i].LegalNextMove = true;

                        }     else break;
                    }
                    for (int i = 1; i < Size; i++)
                    {
                        if (isSafe(y + i, x + i))
                        {
                            if (theGrid[y + i, x + i].PieceName.Contains("White"))
                            {
                                break;
                            }
                            else if (theGrid[y + i, x + i].PieceName.Contains("Black"))
                            {
                                theGrid[y + i, x + i].LegalNextMove = true;
                                break;
                            }
                            else
                                theGrid[y + i, x + i].LegalNextMove = true;

                        }      else    break;
                    }
                    for (int i = 1; i < Size; i++)
                    {
                        if (isSafe(y + i, x - i))
                        {
                            if (theGrid[y + i, x - i].PieceName.Contains("White"))
                            {
                                break;
                            }
                            else if (theGrid[y + i, x - i].PieceName.Contains("Black"))
                            {
                                theGrid[y + i, x - i].LegalNextMove = true;
                                break;
                            }
                            else
                                theGrid[y + i, x - i].LegalNextMove = true;
                        } else break;     
                    }
                    break;

                case "BlackKing":

                    if (isSafe(y - 1, x) && !theGrid[y - 1, x].PieceName.Contains("Black"))
                        theGrid[y - 1, x].LegalNextMove = true;
                    if (isSafe(y - 1, x - 1) && !theGrid[y - 1, x - 1].PieceName.Contains("Black"))
                        theGrid[y - 1, x - 1].LegalNextMove = true;
                    if (isSafe(y - 1, x + 1) && !theGrid[y - 1, x + 1].PieceName.Contains("Black"))
                        theGrid[y - 1, x + 1].LegalNextMove = true;
                    if (isSafe(y, x + 1) && !theGrid[y, x + 1].PieceName.Contains("Black"))
                        theGrid[y, x + 1].LegalNextMove = true;
                    if (isSafe(y + 1, x + 1) && !theGrid[y + 1, x + 1].PieceName.Contains("Black"))
                        theGrid[y + 1, x + 1].LegalNextMove = true;
                    if (isSafe(y + 1, x) && !theGrid[y + 1, x].PieceName.Contains("Black"))
                        theGrid[y + 1, x].LegalNextMove = true;
                    if (isSafe(y + 1, x - 1) && !theGrid[y + 1, x - 1].PieceName.Contains("Black"))
                        theGrid[y + 1, x - 1].LegalNextMove = true;
                    if (isSafe(y, x - 1) && !theGrid[y, x - 1].PieceName.Contains("Black"))
                        theGrid[y, x - 1].LegalNextMove = true;
                    break;

                case "BlackKnight":
                    if (isSafe(y + 2, x + 1) && !theGrid[y + 2, x + 1].PieceName.Contains("Black"))
                    {
                        theGrid[y + 2, x + 1].LegalNextMove = true;
                    }
                    if (isSafe(y + 2, x - 1) && !theGrid[y + 2, x - 1].PieceName.Contains("Black"))
                    {
                        theGrid[y + 2, x - 1].LegalNextMove = true;
                    }
                    if (isSafe(y - 2, x + 1) && !theGrid[y - 2, x + 1].PieceName.Contains("Black"))
                    {
                        theGrid[y - 2, x + 1].LegalNextMove = true;
                    }
                    if (isSafe(y - 2, x - 1) && !theGrid[y - 2, x - 1].PieceName.Contains("Black"))
                    {
                        theGrid[y - 2, x - 1].LegalNextMove = true;
                    }
                    if (isSafe(y + 1, x + 2) && !theGrid[y + 1, x + 2].PieceName.Contains("Black"))
                    {
                        theGrid[y + 1, x + 2].LegalNextMove = true;
                    }
                    if (isSafe(y + 1, x - 2) && !theGrid[y + 1, x - 2].PieceName.Contains("Black"))
                    {
                        theGrid[y + 1, x - 2].LegalNextMove = true;
                    }
                    if (isSafe(y - 1, x + 2) && !theGrid[y - 1, x + 2].PieceName.Contains("Black"))
                    {
                        theGrid[y - 1, x + 2].LegalNextMove = true;
                    }
                    if (isSafe(y - 1, x - 2) && !theGrid[y - 1, x - 2].PieceName.Contains("Black"))
                    {
                        theGrid[y - 1, x - 2].LegalNextMove = true;
                    }
                    break;


                case "BlackRook":

                    for (int i = 1; i < Size; i++)
                    {
                        if (isSafe(y - i, x))
                        {
                            if (theGrid[y - i, x].PieceName.Contains("Black"))
                            {
                                break;
                            }
                            else if (theGrid[y - i, x].PieceName.Contains("White"))
                            {
                                theGrid[y - i, x].LegalNextMove = true;
                                break;
                            }
                            else
                                theGrid[y - i, x].LegalNextMove = true;

                        }
                        else break;
                    }
                    for (int i = 1; i < Size; i++)
                    {
                        if (isSafe(y + i, x))
                        {
                            if (theGrid[y + i, x].PieceName.Contains("Black"))
                            {
                                break;
                            }
                            else if (theGrid[y + i, x].PieceName.Contains("White"))
                            {
                                theGrid[y + i, x].LegalNextMove = true;
                                break;
                            }
                            else
                                theGrid[y + i, x].LegalNextMove = true;

                        }
                        else break;
                    }
                    
                    for (int i = 1; i < Size; i++)
                    {
                        
                        if (isSafe(y, x - i))
                        {
                            if (theGrid[y, x - i].PieceName.Contains("Black"))
                            {
                                break;
                            }
                            else if (theGrid[y, x - i].PieceName.Contains("White"))
                            {
                                theGrid[y, x - i].LegalNextMove = true;
                                break;
                            }
                            else
                            theGrid[y, x - i].LegalNextMove = true;
                        }
                        else break;
                    }
                    for (int i = 1; i < Size; i++)
                    {
                        if (isSafe(y, x + i))
                        {
                            if (theGrid[y, x + i].PieceName.Contains("Black"))
                            {
                                break;
                            }
                            else if (theGrid[y, x + i].PieceName.Contains("White"))
                            {
                                theGrid[y, x + i].LegalNextMove = true;
                                break;
                            }
                            else
                                theGrid[y, x + i].LegalNextMove = true;
                        }
                        else break;
                    }
                
                    break;

                case "BlackPawn":
                    if (isSafe(y + 1, x))
                    {
                        if (theGrid[y + 1, x].PieceName.Equals(""))
                        {
                            theGrid[y + 1, x].LegalNextMove = true;
                            if (y == 1 && theGrid[y + 2, x].PieceName.Equals(""))
                                theGrid[y + 2, x].LegalNextMove = true;
                        }              
                    }
                    if (isSafe(y + 1, x - 1))
                        if (theGrid[y + 1, x - 1].PieceName.Contains("White"))
                        {
                            theGrid[y + 1, x - 1].LegalNextMove = true;
                        }
                    if (isSafe(y + 1, x + 1))
                        if (theGrid[y + 1, x + 1].PieceName.Contains("White"))
                        {
                            theGrid[y + 1, x + 1].LegalNextMove = true;
                        }
                    break;


                case "BlackQueen":
                    for (int i = 1; i < Size; i++)
                    {
                        if (isSafe(y - i, x))
                        {
                            if (theGrid[y - i, x].PieceName.Contains("Black"))
                            {
                                break;
                            }
                            else if (theGrid[y - i, x].PieceName.Contains("White"))
                            {
                                theGrid[y - i, x].LegalNextMove = true;
                                break;
                            }
                            else
                                theGrid[y - i, x].LegalNextMove = true;

                        }
                        else break;
                    }
                    for (int i = 1; i < Size; i++)
                    {
                        if (isSafe(y + i, x))
                        {
                            if (theGrid[y + i, x].PieceName.Contains("Black"))
                            {
                                break;
                            }
                            else if (theGrid[y + i, x].PieceName.Contains("White"))
                            {
                                theGrid[y + i, x].LegalNextMove = true;
                                break;
                            }
                            else
                                theGrid[y + i, x].LegalNextMove = true;

                        }
                        else break;
                    }

                    for (int i = 1; i < Size; i++)
                    {

                        if (isSafe(y, x - i))
                        {
                            if (theGrid[y, x - i].PieceName.Contains("Black"))
                            {
                                break;
                            }
                            else if (theGrid[y, x - i].PieceName.Contains("White"))
                            {
                                theGrid[y, x - i].LegalNextMove = true;
                                break;
                            }
                            else
                                theGrid[y, x - i].LegalNextMove = true;
                        }
                        else break;
                    }
                    for (int i = 1; i < Size; i++)
                    {
                        if (isSafe(y, x + i))
                        {
                            if (theGrid[y, x + i].PieceName.Contains("Black"))
                            {
                                break;
                            }
                            else if (theGrid[y, x + i].PieceName.Contains("White"))
                            {
                                theGrid[y, x + i].LegalNextMove = true;
                                break;
                            }
                            else
                                theGrid[y, x + i].LegalNextMove = true;
                        }
                        else break;
                    }

                    for (int i = 1; i < Size; i++)
                    {
                        if (isSafe(y - i, x - i))
                        {
                            if (theGrid[y - i, x - i].PieceName.Contains("Black"))
                            {
                                break;
                            }
                            else if (theGrid[y - i, x - i].PieceName.Contains("White"))
                            {
                                theGrid[y - i, x - i].LegalNextMove = true;
                                break;
                            }
                            else
                                theGrid[y - i, x - i].LegalNextMove = true;

                        }
                        else break;
                    }
                    for (int i = 1; i < Size; i++)
                    {
                        if (isSafe(y - i, x + i))
                        {
                            if (theGrid[y - i, x + i].PieceName.Contains("Black"))
                            {
                                break;
                            }
                            else if (theGrid[y - i, x + i].PieceName.Contains("White"))
                            {
                                theGrid[y - i, x + i].LegalNextMove = true;
                                break;
                            }
                            else
                                theGrid[y - i, x + i].LegalNextMove = true;

                        }
                        else break;
                    }
                    for (int i = 1; i < Size; i++)
                    {
                        if (isSafe(y + i, x + i))
                        {
                            if (theGrid[y + i, x + i].PieceName.Contains("Black"))
                            {
                                break;
                            }
                            else if (theGrid[y + i, x + i].PieceName.Contains("White"))
                            {
                                theGrid[y + i, x + i].LegalNextMove = true;
                                break;
                            }
                            else
                                theGrid[y + i, x + i].LegalNextMove = true;

                        }
                        else break;
                    }
                    for (int i = 1; i < Size; i++)
                    {
                        if (isSafe(y + i, x - i))
                        {
                            if (theGrid[y + i, x - i].PieceName.Contains("Black"))
                            {
                                break;
                            }
                            else if (theGrid[y + i, x - i].PieceName.Contains("White"))
                            {
                                theGrid[y + i, x - i].LegalNextMove = true;
                                break;
                            }
                            else
                                theGrid[y + i, x - i].LegalNextMove = true;
                        }
                        else break;
                    }
                    break;

                case "BlackBishop":
                    for (int i = 1; i < Size; i++)
                    {
                        if (isSafe(y - i, x - i))
                        {
                            if (theGrid[y - i, x - i].PieceName.Contains("Black"))
                            {
                                break;
                            }
                            else if (theGrid[y - i, x - i].PieceName.Contains("White"))
                            {
                                theGrid[y - i, x - i].LegalNextMove = true;
                                break;
                            }
                            else
                                theGrid[y - i, x - i].LegalNextMove = true;

                        }
                        else break;
                    }
                    for (int i = 1; i < Size; i++)
                    {
                        if (isSafe(y - i, x + i))
                        {
                            if (theGrid[y - i, x + i].PieceName.Contains("Black"))
                            {
                                break;
                            }
                            else if (theGrid[y - i, x + i].PieceName.Contains("White"))
                            {
                                theGrid[y - i, x + i].LegalNextMove = true;
                                break;
                            }
                            else
                                theGrid[y - i, x + i].LegalNextMove = true;

                        }
                        else break;
                    }
                    for (int i = 1; i < Size; i++)
                    {
                        if (isSafe(y + i, x + i))
                        {
                            if (theGrid[y + i, x + i].PieceName.Contains("Black"))
                            {
                                break;
                            }
                            else if (theGrid[y + i, x + i].PieceName.Contains("White"))
                            {
                                theGrid[y + i, x + i].LegalNextMove = true;
                                break;
                            }
                            else
                                theGrid[y + i, x + i].LegalNextMove = true;

                        }
                        else break;
                    }
                    for (int i = 1; i < Size; i++)
                    {
                        if (isSafe(y + i, x - i))
                        {
                            if (theGrid[y + i, x - i].PieceName.Contains("Black"))
                            {
                                break;
                            }
                            else if (theGrid[y + i, x - i].PieceName.Contains("White"))
                            {
                                theGrid[y + i, x - i].LegalNextMove = true;
                                break;
                            }
                            else
                                theGrid[y + i, x - i].LegalNextMove = true;
                        }
                        else break;
                    }
                    break;

                /* case " ":
                     theGrid[currentCell.RowNumber, currentCell.ColNumber].LegalNextMove = true;*/
                default:
                    break;
            }

            theGrid[y, x].CurrentlyOccupied = true;
        }
        //do zmniejszenia liczby linii 
        /*
        private void checkLine(Cell currentCell, int v1, int v2)
        {
            int y = currentCell.RowNumber;
            int x = currentCell.ColNumber;
            if (v1 != 0)
                for (int i = 1; i < Size; i += v1)
                {
                    if (isSafe(y + i, x))
                    {
                        if (theGrid[y + i, x].PieceName.Contains("White"))
                        {
                            break;
                        }
                        else if (theGrid[y + i, x].PieceName.Contains("Black"))
                        {
                            theGrid[y - i, x].LegalNextMove = true;
                            break;
                        }
                        else
                            theGrid[y - i, x].LegalNextMove = true;

                    }
                    else break;
                }
            else if 
        }
        */
        public bool isSafe(int row, int col)
        {
            if (row >= 0 && col >= 0 && row < Size && col < Size)
                return true;
            else 
                return false;

        }

    }
}
