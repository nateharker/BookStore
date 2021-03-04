using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.ViewModels
{
    public class BookListViewModel //Class built to bundle all the code needed to send to the view
    {
        public IEnumerable<Book> Books { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public string CurrentCategory { get; set; } //Enables passing of the selected category that's being filtered to be sent to the view

    }
}
