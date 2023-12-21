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

namespace cafe_system
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Manager.MainWindowFrame = MainWindowFrame;
            MainWindowFrame.Content = new Stuff();
        }

        private void Button_Click_Stuff(object sender, RoutedEventArgs e)
        {
            MainWindowFrame.Content = new Stuff();
        }

        private void Button_Click_Products(object sender, RoutedEventArgs e)
        {
            MainWindowFrame.Content = new Products();
        }

        private void Button_Click_Smena(object sender, RoutedEventArgs e)
        {
            MainWindowFrame.Content = new Smena();
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            Manager.MainWindowFrame.GoBack();
        }

        private void MainWindowFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainWindowFrame.CanGoBack)
            {
                btnBack.Visibility = Visibility.Visible;
            }
            else
            {
                btnBack.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.ShowDialog();
        }
    }
}
