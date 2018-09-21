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

namespace Sudoku
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


        }

        //  Routed Event code. Right clicking any element puts a border around the element
        void Sudoku_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Control source = e.Source as Control;
            if (source.BorderThickness != new Thickness(5))
            {
                source.BorderThickness = new Thickness(5);
                source.BorderBrush = Brushes.Yellow;
            }
            else
                source.BorderThickness = new Thickness(0);
        }

        //  Keyboard event so pressing the letter Q will cause the game to quit
        protected override void OnKeyDown(KeyEventArgs e)
        {
            {
                this.Close();
            }
            base.OnKeyDown(e);
        }

        // Everything else here are button handlers for the game

        void newGameButtonClicked(object sender, RoutedEventArgs e)
        {
            int[,] board = createBoard();
            bool[,] picked = createPickedArray();
            for (int i = 0; i < 30; i++)
            {
                showHint(board, picked);
            }
        }
        void gameButtonClicked(object sender, RoutedEventArgs e)
        {
            var numButton = sender as Button;
            String strButton = numButton.Content as String;
            int intValue = 0;
            if (strButton == null)
            {
                intValue = 1;
            }
            else
            {
                intValue = int.Parse(strButton) + 1;
            }
            if (intValue > 9)
            {

                numButton.Content = null;
            }
            else
            {
                numButton.Content = intValue.ToString();
            }

        }

        void lockedClicked(object sender, RoutedEventArgs e)
        {
            return;
        }

        void QuitClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public int[,] createBoard()
        {
            int[,] solution = { { 1,5,2,4,6,9,3,7,8 },
                                { 7,8,9,2,1,3,4,5,6 },
                                { 4,3,6,5,8,7,2,9,1 },
                                { 6,1,3,8,7,2,5,4,9 },
                                { 9,7,4,1,5,6,8,2,3 },
                                { 8,2,5,9,3,4,1,6,7 },
                                { 5,6,7,3,4,8,9,1,2 },
                                { 2,4,8,6,9,1,7,3,5 },
                                { 3,9,1,7,2,5,6,8,4 } };
            return solution;
        }

        public bool[,] createPickedArray()
        {
            bool[,] picked = {  { false,false,false,false,false,false,false, false,false},
                                { false,false,false,false,false,false,false, false,false},
                                { false,false,false,false,false,false,false, false,false},
                                { false,false,false,false,false,false,false, false,false},
                                { false,false,false,false,false,false,false, false,false},
                                { false,false,false,false,false,false,false, false,false},
                                { false,false,false,false,false,false,false, false,false},
                                { false,false,false,false,false,false,false, false,false},
                                { false,false,false,false,false,false,false, false,false} };
            return picked;

        }

        public void showHint(int[,] board, bool[,] picked)
        {
            if (isSolved(board))
            {
                return;
            }
            int randRow = 0;
            int randCol = 0;
            Button button = new Button();
            Random rnd = new Random();

            // if Random location is != false, find another random location
            do
            {
                randRow = rnd.Next(1, 9);
                randCol = rnd.Next(1, 9);
            } while (picked[randRow, randCol] != false);

            // set its picked value to true
            picked[randRow, randCol] = true;

            // Select the button with that row/col, change text to solution at that value, 
            //  Change the color to black, and change the 'click' function associated with that button
            //  so the player cannot change that button again.

            // String hintBox = "Box" + randRow.toString() + randCol.toString;
           
            //button = (Button)this.Controls(hintBox);

        }


        public void nullClicked()
        {
            return;
        }

        public UIElement GetGridElement(Grid g, int r, int c)
        {
            for (int i = 0; i < g.Children.Count; i++)
            {
                UIElement e = g.Children[i];
                if (Grid.GetRow(e) == r && Grid.GetColumn(e) == c)
                {
                    e = g.Children[i + 1];
                    return e;
                }
            }
            return null;
        }

        public bool isSolved(int[,] board)
        {
            return false;
        }
    }
}
