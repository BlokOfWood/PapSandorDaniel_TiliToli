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
    /* Szerintem érthetően neveztem el a változókat és átláthatóan rendeztem a kódom, 
     * ezért csak szükség esetén kommentáltam, amikor ránézésre szerintem nem nyilvánvaló, hogy mit csinál.
     * (valami olyasfajta gondolatmenetet tartalmaz, ami nem azonnal nyilvánvaló, vagy nem tudtam érthetően elnevezni)
     * Például nem akartam odaírni a NewGame()-hez, hogy új játékot indít.*/
    public partial class MainWindow : Window
    {
        /// <summary>
        /// A tilitoli négyzeteinek elhelyezkedése szám szerint. 
        /// </summary>
        byte[,] tilitoliState;
        int stepsTaken = 0;
        UIElementCollection tiliToliElemek;

        public MainWindow()
        {
            InitializeComponent();
            tiliToliElemek = elemTartó.Children;
            NewGame();
        }

        public void NewGame()
        {
            stepsTaken = 0;

            tilitoliState = new byte[,]{
                {0,1,2},{3,4,5},{6,7,8}
            };
            Shuffle();
            UpdateUI();

            Győzelem.Visibility = Visibility.Hidden;
            foreach (var i in tiliToliElemek)
            {
                (i as Button).IsEnabled = true;
            }
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
                if (flatArray[i] == 0)
                    (tiliToliElemek[i] as Button).Visibility = Visibility.Hidden;
                else
                {
                    (tiliToliElemek[i] as Button).Visibility = Visibility.Visible;
                    (tiliToliElemek[i] as Button).Content = flatArray[i].ToString();
                }
            }

            StepCounter.Text = stepsTaken.ToString();
        }

        bool CheckWin()
        {
            //Létrehoz egy változatot a listáról, amit növekvő sorrendbe rendez és egyet, amit nem. 
            //Ha megegyezik, akkor már eddig is növekvő sorrendben volt tehát nyert a játékos.
            List<byte> tempsorted = tilitoliState.Cast<byte>().ToList();
            tempsorted.Sort();
            tempsorted.RemoveAt(0);
            List<byte> tempbase = tilitoliState.Cast<byte>().ToList();
            //Azt feltételezzük, hogy csak akkor nyertes a játék állapot, ha a jobb alsó négyzet üres.
            //Ha .Remove(0) lenne, akkor eltávolítaná a 0-t bárhol is van, így csak a sorrend számítana, de ez túl egyszerűvé tenné a játékot.
            tempbase.RemoveAt(8);

            for(int i = 0; i < 8; i++)
            {
                if (tempsorted[i] != tempbase[i]) return false;
            }

            return true;
        }

        /// <summary>
        /// Meghívódik minden négyzetre nyomáskor
        /// </summary>
        /// <param name="index">
        /// A lenyomott négyzet indexe, ha a UI négyzetek mátrixát kilapítjuk.
        /// </param>
        void ButtonClick(int index)
        {
            //Egy rövidítés a kiválaszott négyzet 2d-s indexéről.
            int[] i = { index / 3, index % 3 };

            //Végignézi a 4 szomszédos négyzetet, hogy üresek-e.

            /*Balra lévő*/
            if(i[0] != 0 && tilitoliState[i[0]-1, i[1]] == 0)
            {
                byte a = tilitoliState[i[0], i[1]];
                byte b = tilitoliState[i[0] - 1, i[1]];

                tilitoliState[i[0]-1, i[1]] = a;
                tilitoliState[i[0], i[1]] = b;
            }
            /*Jobbra lévő*/
            else if (i[0] != 2 && tilitoliState[i[0] + 1, i[1]] == 0)
            {
                byte a = tilitoliState[i[0], i[1]];
                byte b = tilitoliState[i[0] + 1, i[1]];

                tilitoliState[i[0] + 1, i[1]] = a;
                tilitoliState[i[0], i[1]] = b;
            }
            /*Alatta lévő*/
            else if (i[1] != 0 && tilitoliState[i[0], i[1] - 1] == 0)
            {
                byte a = tilitoliState[i[0], i[1]];
                byte b = tilitoliState[i[0], i[1] - 1];

                tilitoliState[i[0], i[1] - 1] = a;
                tilitoliState[i[0], i[1]] = b;
            }
            /*Felette lévő*/
            else if (i[1] != 2 && tilitoliState[i[0], i[1] + 1] == 0)
            {
                byte a = tilitoliState[i[0], i[1]];
                byte b = tilitoliState[i[0], i[1] + 1];

                tilitoliState[i[0], i[1] + 1] = a;
                tilitoliState[i[0], i[1]] = b;
            }
            else
            {
                //Így, hogyha a megtett lépés nem eredményes, akkor levon egyet előre, ezért a végeredmény az, hogy a számláló nem változik.
                //Elegánsabb, mint minden hova berakni a stepsTaken++ utasítást.
                stepsTaken--;
            }

            stepsTaken++;
            UpdateUI();

            if(CheckWin())
            {
                foreach (var button in tiliToliElemek)
                {
                    (button as Button).IsEnabled = false;
                    Győzelem.Visibility = Visibility.Visible;
                }
            }
        }

        private void newgame_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(0);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ButtonClick(1);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ButtonClick(2);

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ButtonClick(3);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            ButtonClick(4);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            ButtonClick(5);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            ButtonClick(6);
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            ButtonClick(7);
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            ButtonClick(8);
        }
    }
}
