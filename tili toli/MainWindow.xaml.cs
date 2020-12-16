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
        void NewGame()
        {
            tilitoliState = new byte[,]{
                {0,1,2},{3,4,5},{6,7,8}
            };

            UpdateUI();
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
