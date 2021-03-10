using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent /*Inherits from the ViewComponents class in the Microsoft.AspNetCore.Mvc library*/
    {
        private IBookRepository repository;

        public NavigationMenuViewComponent(IBookRepository r) /*Constructor that will initialize the repository variable to last the life of the program*/
        {
            repository = r;
        }
        public IViewComponentResult Invoke() /*Function to create list of unique categories*/
        {
            ViewBag.SelectedType = RouteData?.Values["category"]; /*This is used to determine which filter to highlight in the view*/

            return View(repository.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }

    }
}
