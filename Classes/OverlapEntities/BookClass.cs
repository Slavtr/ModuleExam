using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using ModuleExam.Classes.DataModel;

namespace ModuleExam.Classes.OverlapEntities
{
    public class BookClass
    {
        public Exam_Books Book { get; set; }

        private BitmapImage _mainImage;
        public BitmapImage MainImage
        {
            get
            {
                if(_mainImage == null)
                {
                    _mainImage = new BitmapImage();
                    _mainImage.BeginInit();
                    string path = Environment.CurrentDirectory + "\\" + Book.Cover;
                    _mainImage.UriSource = new Uri(path, UriKind.Absolute);
                    _mainImage.EndInit();
                }
                return _mainImage;
            }
        }
        public BookClass(Exam_Books book)
        {
            Book = book;
        }
    }
}
