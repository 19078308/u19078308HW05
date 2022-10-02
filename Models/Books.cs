using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u19078308HW05.Models
{
    public class Books
    {
        public int bookId { get; set; }
        public string name { get; set; }
        public int pagecount { get; set; }
        public int point { get; set; }
        public int authorId { get; set; }
        public int typeId { get; set; }

        
    }
}