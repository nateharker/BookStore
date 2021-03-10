using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        //Function adds an book to the cart
        public virtual void AddItem(Book bk, int qty)
        {
            CartLine line = Lines
                .Where(b => b.Book.BookId == bk.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = bk,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }
        //Function to remove one item from cart
        public virtual void RemoveLine(Book bk) =>
            Lines.RemoveAll(b => b.Book.BookId == bk.BookId);
        //Function clears all items in the cart
        public virtual void Clear() => Lines.Clear();
        //Function calculates the cost of all items in the cart
        public decimal ComputeTotalSum() =>
            (decimal)Lines.Sum(b => b.Book.Price * b.Quantity); 

        //Info stored about each cart line item
        public class CartLine
        {
            public int CartLineID { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }
        }
    }

}
