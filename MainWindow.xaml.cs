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
using ModuleExam.Classes.DataModel;
using ModuleExam.Classes;

namespace ModuleExam
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Page> Pages { get; set; } = new List<Page>();
        public static BookManagingClass BookManagingClass { get; set; }
        private static Frame MainFrame;
        public MainWindow()
        {
            InitializeComponent();
            MainFrame = mwMainFrame;
            BookManagingClass = new BookManagingClass();
            Pages.Add(new Pages.ListPage());
            mwMainFrame.Content = Pages[0];
            Pages.Add(new Pages.Cart());
        }
        public static void ChangePage(int number)
        {
            MainFrame.Content = Pages[number];
        }
    }
}
