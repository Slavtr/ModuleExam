using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ModuleExam.Classes.DataModel;
using ModuleExam.Classes.OverlapEntities;

namespace ModuleExam.Classes
{
    public class BookManagingClass
    {
        public List<BookClass> Books { get; set; } = new List<BookClass>();
        private List<BookClass> _cart = new List<BookClass>();
        public List<BookClass> Cart { get { return _cart; } }
        private BookShopDataModel _dataModel = new BookShopDataModel();
        public BookManagingClass()
        {
            FillBooks(_dataModel.Exam_Books);
        }
        private void FillBooks(IEnumerable<Exam_Books> _books)
        {
            Books.Clear();
            foreach(Exam_Books book in _books)
            {
                Books.Add(new BookClass(book));
            }
        }
        public string CalculateCost()
        {
            decimal ret = 0;
            foreach(BookClass b in _cart)
            {
                ret += (decimal)b.Book.Price;
            }
            return Math.Round(ret, 2).ToString();
        }
        public string CalculateDiscount()
        {
            List<double> discount = new List<double>();
            foreach(BookClass b in _cart)
            {
                discount.Add(Convert.ToDouble(b.Book.Price));
            }
            return DiscountDll.DiscountCount.CalculateDiscount(discount, CalculateCost());
        }
        public int Buy()
        {
            int ret = _dataModel.Exam_BookSale.Last().SaleCode + 1;
            int time = 0;
            int count = 0;

            foreach(BookClass book in _cart)
            {
                if(book.Count > book.Book.CountInShop + book.Book.CountInStore)
                {
                    MessageBox.Show("Невозможно предоставить требуемое количество книг " + book.Book.Name);
                    return -1;
                }
            }

            foreach(BookClass book in _cart)
            {
                count += book.Count;
                _dataModel.Exam_Books.First(x => x.id == book.Book.id).CountInShop -= book.Count;
                if(_dataModel.Exam_Books.First(x => x.id == book.Book.id).CountInShop < 0)
                {
                    _dataModel.Exam_Books.First(x => x.id == book.Book.id).CountInStore += _dataModel.Exam_Books.First(x => x.id == book.Book.id).CountInShop;
                    _dataModel.Exam_Books.First(x => x.id == book.Book.id).CountInShop = 0;
                    time = 72;
                }
            }

            double price = Convert.ToDouble(CalculateCost()) / 100 * (100 - Convert.ToDouble(CalculateDiscount()));

            string str = "Ваш заказ под номером " + ret.ToString() + " будет доступен через " + time.ToString() + " часа.\n Итоговое количество равно " + count + " единиц.\n Доступно резервирование на 1 неделю с текущей даты.";
            MessageBox.Show(str);

            return ret;
        }
    }
}
