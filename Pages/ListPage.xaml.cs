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
    /// Логика взаимодействия для ListPage.xaml
    /// </summary>
    public partial class ListPage : Page
    {
        public ListPage()
        {
            InitializeComponent();
            lbMainListBox.ItemsSource = MainWindow.BookManagingClass.Books;
            this.Loaded += ListPage_Loaded;
        }

        private void ListPage_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                tbBookCount.Text = MainWindow.BookManagingClass.Cart.Count.ToString();
                tbDiscountSize.Text = MainWindow.BookManagingClass.CalculateDiscount();
                if (tbDiscountSize.Text != "0")
                {
                    tbRegularPrice.TextDecorations = TextDecorations.Strikethrough;
                    tbDiscountPrice.Text = Convert.ToString(Convert.ToDouble(tbRegularPrice.Text) / 100 * (100 - Convert.ToDouble(tbDiscountSize.Text)));
                }
                else
                {
                    tbRegularPrice.TextDecorations = TextDecorations.Baseline;
                }
                tbRegularPrice.Text = MainWindow.BookManagingClass.CalculateCost();
            }
            catch
            {
                return;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.BookManagingClass.Cart.Contains(MainWindow.BookManagingClass.Books.First(x => x.Book.id.ToString() == (sender as Button).Uid)))
            {
                MainWindow.BookManagingClass.Cart.First(x => x.Book.id.ToString() == (sender as Button).Uid).Count++;
            }
            else
            {
                MainWindow.BookManagingClass.Cart.Add(MainWindow.BookManagingClass.Books.First(x => x.Book.id.ToString() == (sender as Button).Uid));
            }
            tbBookCount.Text = MainWindow.BookManagingClass.Cart.Count.ToString();
            tbDiscountSize.Text = MainWindow.BookManagingClass.CalculateDiscount();
            if(tbDiscountSize.Text != "0")
            {
                tbRegularPrice.TextDecorations = TextDecorations.Strikethrough;
                tbDiscountPrice.Text = Convert.ToString(Convert.ToDouble(tbRegularPrice.Text) / 100 * (100 - Convert.ToDouble(tbDiscountSize.Text)));
            }
            else
            {
                tbRegularPrice.TextDecorations = TextDecorations.Baseline;
            }
            tbRegularPrice.Text = MainWindow.BookManagingClass.CalculateCost();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            MainWindow.ChangePage(1);
        }
    }
}
