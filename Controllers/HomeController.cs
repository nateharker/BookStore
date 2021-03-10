using BookStore.Models;
using BookStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IBookRepository _repository;

        public int PageSize = 5; //Adjust this number to change how many records are displayed on each page

        public HomeController(ILogger<HomeController> logger, IBookRepository repository)
        {
            _logger = logger;
            _repository = repository; /*Repository is assigned a value here so that it can be accessed within the controller*/
        }

        public IActionResult Index(string category, int pageNum = 1)
        {
            return View(new BookListViewModel
            {
                Books = _repository.Books //Helps determine which records to send to the view based on the page it's on
                .Where(b => category == null || b.Category == category) //Filters by category, if arguement is passed to function
                .OrderBy(p => p.BookId)
                .Skip((pageNum - 1) * PageSize)
                .Take(PageSize)
                ,
                PagingInfo = new PagingInfo //Helps determine how many pages there should be total
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = PageSize,
                    TotalNumItems = category == null ? _repository.Books.Count() :      //Dynamically adjust number of page links based on filtration
                        _repository.Books.Where(x => x.Category == category).Count()
                },
                CurrentCategory = category
            });
            /*Books are sent to the Index page to be used there*/
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
