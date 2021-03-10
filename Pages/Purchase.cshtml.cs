using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Infrastructure;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Pages
{
    public class PurchaseModel : PageModel
    {
        private IBookRepository repository;
        //Contstructor
        public PurchaseModel(IBookRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }
        //Properties
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        //Methods
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        //Function adds an item to the cart
        public IActionResult OnPost(long bookId, string returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(b => b.BookId == bookId);
            Cart.AddItem(book, 1); //Could change this code later to receive a qty variable and add more than one at a time
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        //Function removes single item from cart
        public IActionResult OnPostRemove(long bookId, string returnUrl)
        {
            Book book = Cart.Lines.First(b => b.Book.BookId == bookId).Book;
            Cart.RemoveLine(book);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        //Function removes all items from cart
        public IActionResult OnPostClear(string returnUrl)
        {
            Cart.Clear();
            return RedirectToPage(new { returnUrl = returnUrl });
        }

    }
}
