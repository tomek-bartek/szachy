using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chess1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Board myBoard = new Board(8);
        //private static Board myPossibleMove = new Board(8);

        private Button[,] btnGrid = new Button[myBoard.Size, myBoard.Size];

        private static Cell prevoiusClickedCell = null; //zapamiętywanie klikniętego poprzedniego kliknięcia
        private bool WhiteTurn = true;

        private bool someoneWon = false;
        private string ktoWygral = "";

        public MainWindow()
        {
            InitializeComponent();
            showStartBoard();
        }

        public void showStartBoard()
        {
            bool WhiteCell;
            //metoda pokazuje plansze na Windows Formsie
            for (int i = 0; i < 8; i++)
            {
                if (i % 2 == 0)
                { WhiteCell = true; }
                else
                {    WhiteCell = false; }


                for (int j = 0; j < 8; j++)
                {

                    //Startowa plansza z ustawionymi pionkami 

                    //      Czarne Pionki
                    if (i == 1)
                    {
                        myBoard.theGrid[i, j].PieceName = "BlackPawn";
                        myBoard.theGrid[i, j].CurrentlyOccupied = true;
                    }
                    else if (i == 0 && (j == 0 || j == 7))
                    {
                        myBoard.theGrid[i, j].PieceName = "BlackRook";
                        myBoard.theGrid[i, j].CurrentlyOccupied = true;
                    }
                    else if (i == 0 && (j == 1 || j == 6))
                    {
                        myBoard.theGrid[i, j].PieceName = "BlackKnight";
                        myBoard.theGrid[i, j].CurrentlyOccupied = true;
                    }

                    else if (i == 0 && (j == 2 || j == 5))
                    {
                        myBoard.theGrid[i, j].PieceName = "BlackBishop";
                        myBoard.theGrid[i, j].CurrentlyOccupied = true;
                    }
                    else if (i == 0 && j == 3)
                    {
                        myBoard.theGrid[i, j].PieceName = "BlackQueen";
                        myBoard.theGrid[i, j].CurrentlyOccupied = true;

                    }
                    else if (i == 0 && j == 4)
                    {
                        myBoard.theGrid[i, j].PieceName = "BlackKing";
                        myBoard.theGrid[i, j].CurrentlyOccupied = true;
                    }
                    //     Białe Pionki
                    else if (i == 6)
                    {
                        myBoard.theGrid[i, j].PieceName = "WhitePawn";
                        myBoard.theGrid[i, j].CurrentlyOccupied = true;
                    }
                    else if (i == 7 && (j == 0 || j == 7))
                    {
                        myBoard.theGrid[i, j].PieceName = "WhiteRook";
                        myBoard.theGrid[i, j].CurrentlyOccupied = true;
                    }
                    else if (i == 7 && (j == 1 || j == 6))
                    {
                        myBoard.theGrid[i, j].PieceName = "WhiteKnight";
                        myBoard.theGrid[i, j].CurrentlyOccupied = true;
                    }
                    else if (i == 7 && (j == 2 || j == 5))
                    {
                        myBoard.theGrid[i, j].PieceName = "WhiteBishop";
                        myBoard.theGrid[i, j].CurrentlyOccupied = true;
                    }
                    else if (i == 7 && j == 3)
                    {
                        myBoard.theGrid[i, j].PieceName = "WhiteQueen";
                        myBoard.theGrid[i, j].CurrentlyOccupied = true;
                    }
                    else if (i == 7 && j == 4)
                    {
                        myBoard.theGrid[i, j].PieceName = "WhiteKing";
                        myBoard.theGrid[i, j].CurrentlyOccupied = true;
                    }
                    else
                    {
                        myBoard.theGrid[i, j].PieceName = "";
                        myBoard.theGrid[i, j].CurrentlyOccupied = false;
                    }

                

                    //  Button poleButton = new Button();
                    btnGrid[i, j] = new Button();
                    btnGrid[i, j].Click += Grid_Button_Click;
                    btnGrid[i, j].Content = myBoard.theGrid[i, j].PieceName;
                    
                    
                    //Kolorowanie planszy:
                    if(WhiteCell == true)
                    {
                        btnGrid[i, j].Background = Brushes.Beige;
                        WhiteCell = false;
                    }else
                    {
                        btnGrid[i, j].Background = Brushes.Brown;
                        WhiteCell = true;
                    }
                    //Oznaczenie numeru pola


                    btnGrid[i, j].Tag = new Point(i, j);

                    Grid.SetColumn(btnGrid[i, j], j);
                    Grid.SetRow(btnGrid[i, j], i);
                    grid.Children.Add(btnGrid[i, j]);

                }
            }

        }
         public void showBoard()
        {
            bool WhiteCell;
            for (int i = 0; i < myBoard.Size; i++)
            {

                if (i % 2 == 0)
                {
                    WhiteCell = true;

                }
                else
                {
                    WhiteCell = false;
                }
                for (int j = 0; j < myBoard.Size; j++)
                {   //stworzenie przycisku z nazwa pionka
                    btnGrid[i, j] = new Button();
                    btnGrid[i, j].Click += Grid_Button_Click;
                    btnGrid[i, j].Content = myBoard.theGrid[i, j].PieceName;

                    //Kolorowanie planszy:
                    if (WhiteCell == true)
                    {
                        btnGrid[i, j].Background = Brushes.Beige;
                        WhiteCell = false;
                    }
                    else
                    {
                        btnGrid[i, j].Background = Brushes.Brown;
                        WhiteCell = true;
                    }
                    //otagowanie lokacją
                    btnGrid[i, j].Tag = new Point(i, j);
                    //dodanie do winformsa
                    Grid.SetColumn(btnGrid[i, j], j);
                    Grid.SetRow(btnGrid[i, j], i);
                    grid.Children.Add(btnGrid[i, j]);
                }

            }
        }

        
        private void Grid_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!someoneWon)
            {
                Button clickedCell = (Button)sender;
                string clickedLabel = "";

                if (clickedCell.Content.ToString() == null || clickedCell.Content.ToString() == "")
                {
                    MessageBox.Show("Tu nie ma pionka");
                }
                else if (clickedCell.Content.ToString().Contains("White") && WhiteTurn == false)
                {
                    MessageBox.Show("Tura czarnego");
                }
                else if (clickedCell.Content.ToString().Contains("Black") && WhiteTurn == true)
                {
                    MessageBox.Show("Tura białego");
                }
                else
                {
                    clickedLabel = clickedCell.Content.ToString();


                    Point lokacja = (Point)clickedCell.Tag;
                    int x = (int)lokacja.X;
                    int y = (int)lokacja.Y;


                    Cell currentCell = myBoard.theGrid[x, y];
                    currentCell.CurrentlyOccupied = true;



                    if (clickedLabel == "MoveHere" || clickedLabel.Contains("Beat"))
                    {
                        //warunek wygrania - uproszczona wersja szachów
                        if (myBoard.theGrid[x, y].PieceName.Contains("WhiteKing"))
                        {
                            someoneWon = true;
                            ktoWygral = "Szach Mat - wygrywa Czarny Gracz";
                            MessageBox.Show(ktoWygral);
                            ktoWygral = "Wygrał Czarny Gracz";
                            showBoard();
                        }
                        else if (myBoard.theGrid[x, y].PieceName.Contains("BlackKing"))
                        {
                            someoneWon = true;
                            ktoWygral = "Szach Mat - wygrywa Biały Gracz";
                            MessageBox.Show(ktoWygral);
                            ktoWygral = "wygrał Biały Gracz";
                            showBoard();
                        }
                        else
                        {
                            myBoard.theGrid[currentCell.RowNumber, currentCell.ColNumber].PieceName = prevoiusClickedCell.PieceName;
                            prevoiusClickedCell.PieceName = "";
                            prevoiusClickedCell.CurrentlyOccupied = false;
                            WhiteTurn = !WhiteTurn;
                            showBoard();
                        }


                    }
                    else
                    {
                        showBoard();
                        myBoard.MarkNextLegalMoves(currentCell, clickedLabel);
                        for (int i = 0; i < myBoard.Size; i++)
                        {
                            for (int j = 0; j < myBoard.Size; j++)
                            {
                                if (myBoard.theGrid[i, j].LegalNextMove == true)
                                {
                                    if (btnGrid[i, j].Content.Equals(""))
                                        btnGrid[i, j].Content = "MoveHere";
                                    else
                                        btnGrid[i, j].Content = "Beat";

                                }
                                else if (myBoard.theGrid[i, j].CurrentlyOccupied == true)
                                {
                                    btnGrid[i, j].Content = myBoard.theGrid[i, j].PieceName;
                                }

                            }
                            /*  grid.Children.Clear();*/
                        }
                    }

                    prevoiusClickedCell = currentCell;

                }
            }
            else
            {
                MessageBox.Show(ktoWygral);
            }
            
        }
    }
}
