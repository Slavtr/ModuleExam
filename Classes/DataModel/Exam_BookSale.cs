//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModuleExam.Classes.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Exam_BookSale
    {
        public int id { get; set; }
        public int SaleCode { get; set; }
        public int BookId { get; set; }
        public Nullable<System.DateTime> SendDate { get; set; }
    
        public virtual Exam_Books Exam_Books { get; set; }
    }
}
