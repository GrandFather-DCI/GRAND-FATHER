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

namespace Xiangqi01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Grid grid = new Grid();
        GameBoard gameboard = new GameBoard();
        public int ShowPosition = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void CreateGrid()
        {
            ImageBrush background = new ImageBrush();
            background.ImageSource = new BitmapImage(new Uri("..\\..\\..\\Resource\\bg3.jpg", UriKind.RelativeOrAbsolute));
            Background = background;

            for (int col = 0; col < 9; col++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int row = 0; row < 10; row++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }
            Draw();
        }

        private void ChessMouseDown(object sender, MouseButtonEventArgs e)
        {
            Image image = (Image)sender;
            int row = Grid.GetRow(image);
            int column = Grid.GetColumn(image);

            if (GameBoard.ChoseChess == 0) 
            {
                gameboard.JudgeSide();
                gameboard.SelectPiece(row, column);
                if (GameBoard.Selected)
                {
                    ShowPosition = 1;
                    Draw();
                }
            }
            else // To move piece
            {
                gameboard.MovePiece(row, column);
                if (GameBoard.Moveable)
                {
                    ShowPosition = 0;
                    Draw();
                    gameboard.Message();
                }
            }
        }
        public void Draw()
        {
            grid.Children.Clear();
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    Image image = new Image();
                    image.MouseDown += new MouseButtonEventHandler(ChessMouseDown);

                    if(ShowPosition == 0)
                    image.Source = new BitmapImage(new Uri(GameBoard.board[row, col].ToString(), UriKind.Relative));

                    if(ShowPosition == 1)
                    {   if (row == GameBoard.posy && col == GameBoard.posx)
                            image.Source = new BitmapImage(new Uri(GameBoard.board[row, col].SelcetChess(), UriKind.Relative));
                        else if (GameBoard.board[GameBoard.posy, GameBoard.posx].Move(GameBoard.posx, GameBoard.posy, col, row, GameBoard.board))  
                            image.Source = new BitmapImage(new Uri(GameBoard.board[row, col].SelcetChess(), UriKind.Relative));                      
                        else  
                            image.Source = new BitmapImage(new Uri(GameBoard.board[row, col].ToString(), UriKind.Relative));
                    }

                    Grid.SetRow(image, row);
                    Grid.SetColumn(image, col);
                    grid.Children.Add(image);
                }
            }
        }

      
        private void Button_Start(object sender, RoutedEventArgs e)
        {
            gameboard.InitializeBoard();
            CreateGrid();
            this.Content = grid;
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
