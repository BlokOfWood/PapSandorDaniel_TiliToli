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
        UIElementCollection tiliToliElemek;  
        public MainWindow()
        {
            InitializeComponent();
            tiliToliElemek = elemTartó.Children;

            for (int i = 0; i < tiliToliElemek.Count; i++)
            {
                (tiliToliElemek[i] as Button).Content = (i + 1).ToString();
            }
        }

        private void newgame_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
