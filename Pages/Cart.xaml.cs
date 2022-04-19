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

namespace ModuleExam.Pages
{
    /// <summary>
    /// Логика взаимодействия для Cart.xaml
    /// </summary>
    public partial class Cart : Page
    {
        public Cart()
        {
            InitializeComponent();
            this.Loaded += Cart_Loaded;
        }

        private void Cart_Loaded(object sender, RoutedEventArgs e)
        {
            lbCart.ItemsSource = MainWindow.BookManagingClass.Cart;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.BookManagingClass.Cart.Remove(MainWindow.BookManagingClass.Cart.First(x => x.Book.id.ToString() == (sender as Button).Uid));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow.BookManagingClass.Buy();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            MainWindow.ChangePage(0);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (MainWindow.BookManagingClass.Cart.Contains(MainWindow.BookManagingClass.Books.First(x => x.Book.id.ToString() == (sender as Button).Uid)))
            {
                MainWindow.BookManagingClass.Cart.First(x => x.Book.id.ToString() == (sender as Button).Uid).Count++;
            }
            else
            {
                MainWindow.BookManagingClass.Cart.Add(MainWindow.BookManagingClass.Books.First(x => x.Book.id.ToString() == (sender as Button).Uid));
            }
        }
    }
}
