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

namespace tili_toli
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        byte[,] tilitoliState;
        UIElementCollection tiliToliElemek;
        public MainWindow()
        {
            InitializeComponent();
            tiliToliElemek = elemTartó.Children;
            NewGame();
        }
        public void NewGame()
        {
            tilitoliState = new byte[,]{
                {1,2,3},{4,5,6},{7,8,9}
            };
            Shuffle();

            UpdateUI();
        }

        void Shuffle()
        {
            Random rnd = new Random();

            for (int x = 0; x < 3; x++)
            {
                for(int y = 0; y < 3; y++)
                {
                    int[] shuffleTarget = { rnd.Next(0, 3), rnd.Next(0, 3) };

                    byte a = tilitoliState[x, y];
                    byte b = tilitoliState[shuffleTarget[0], shuffleTarget[1]];

                    tilitoliState[shuffleTarget[0], shuffleTarget[1]] = a;
                    tilitoliState[x, y] = b;
                }
            }
        }

        void UpdateUI()
        {
            byte[] flatArray = tilitoliState.Cast<byte>().ToArray();
            for(int i = 0; i < 9; i++)
            {
                (tiliToliElemek[i] as Button).Content = flatArray[i].ToString();
            }
        }

        private void newgame_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {

        }
    }
}
