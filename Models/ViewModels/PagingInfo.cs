using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.ViewModels
{
    public class PagingInfo
    {
        public int TotalNumItems { get; set; }

        public int ItemsPerPage { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages => (int)(Math.Ceiling((decimal)TotalNumItems / ItemsPerPage));    //Funtion to determine how many whole pages are needed 
                                                                                                //to diplay all the records with the given number of records 
                                                                                                //per page.
    }
}
