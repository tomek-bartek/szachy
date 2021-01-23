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
        public static Board myBoard = new Board(8);
        public static Board myPossibleMove = new Board(8);
     
        public Button[,] btnGrid = new Button[myBoard.Size, myBoard.Size];

        public MainWindow()
        {
            InitializeComponent();
            showStartBoard();
        }

        public void showStartBoard()
        {

            //metoda pokazuje plansze na Windows Formsie
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    //Startowy board z ustawionymi pionkami 
                    
                        //      Czarne Pionki
                    if (i == 1)
                        myBoard.theGrid[i, j].PieceName = "PawnBlack";
                    myBoard.theGrid[i, j].CurrentlyOccupied = true;


                         //     Białe Pionki

                    if (i == 6)
                        myBoard.theGrid[i, j].PieceName = "PawnWhite";
                    myBoard.theGrid[i, j].CurrentlyOccupied = true;



                    //  Button poleButton = new Button();
                    btnGrid[i, j] = new Button();
                    btnGrid[i, j].Click += Grid_Button_Click;
                    btnGrid[i, j].Content = myBoard.theGrid[i, j].PieceName;
                   
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
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {   //stworzenie przycisku z nazwa pionka
                    btnGrid[i, j] = new Button();
                    btnGrid[i, j].Click += Grid_Button_Click;
                    btnGrid[i, j].Content = myBoard.theGrid[i, j].PieceName;
                    //otagowanie lokacją
                    btnGrid[i, j].Tag = new Point(i, j);
                    //dodanie do winformsa
                    Grid.SetColumn(btnGrid[i, j], j);
                    Grid.SetRow(btnGrid[i, j], i);
                    grid.Children.Add(btnGrid[i, j]);
                }

            }
        }





        public static Cell prevoiusClickedCell = null;
        
        private void Grid_Button_Click(object sender, RoutedEventArgs e)
        {
            
            Button clickedCell = (Button)sender;
            string clickedLabel ="";
            if (null == clickedCell.Content.ToString())
            {
                MessageBox.Show("Tu nie ma pionka");
            }
            else
            {

            clickedLabel = clickedCell.Content.ToString();
            }
            Point lokacja = (Point)clickedCell.Tag;
            int x = (int)lokacja.X;
            int y = (int)lokacja.Y;
           





            Cell currentCell = myBoard.theGrid[x, y];
            currentCell.CurrentlyOccupied = true;
            
            if (clickedLabel == "Legal")
            {
                myBoard.theGrid[currentCell.RowNumber, currentCell.ColNumber].PieceName = prevoiusClickedCell.PieceName;
                prevoiusClickedCell.PieceName = "";
                prevoiusClickedCell.CurrentlyOccupied = false;
                showBoard();

            }
            else
            {
            myBoard.MarkNextLegalMoves(currentCell, clickedLabel);
             for (int i = 0; i < myBoard.Size; i++)
                        {
                            for (int j = 0; j < myBoard.Size; j++)
                            {
                                if (myBoard.theGrid[i, j].LegalNextMove == true)
                                {
                                    btnGrid[i, j].Content = "Legal";
                                }
                                else if (myBoard.theGrid[i, j].CurrentlyOccupied == true)
                                {
                                    btnGrid[i, j].Content = myBoard.theGrid[i,j].PieceName;
                                }

                            }  
                            
                            
                            
                            
                          /*  grid.Children.Clear();*/
                

                        }
            }

                prevoiusClickedCell = currentCell;
            
              
            
            
            
            

           


        }
    }
}
