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
        
    }
}
