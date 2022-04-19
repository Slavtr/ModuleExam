﻿using System;
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

            foreach(BookClass book in _cart)
            {
                if(book.Count > book.Book.CountInShop + book.Book.CountInStore)
                {
                    MessageBox.Show("Невозможно предоставить требуемое количество книг " + book.Book.Name);
                    return -1;
                }
            }

            return ret;
        }
    }
}
