using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public interface IBookRepository //Set up to be inherited by the EFBookRepository
    {
        IQueryable<Book> Books { get; }
    }
}
