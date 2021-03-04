using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            BookStoreDbContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BookStoreDbContext>();

            if (context.Database.GetPendingMigrations().Any()) /*If there are any migrations, migrate them*/
            {
                context.Database.Migrate();
            }

            if (!context.Books.Any()) /*If there are no books in the databse, add the seed data below*/
            {
                context.Books.AddRange(

                    new Book
                    {
                        Title = "Les Miserables",
                        AuthorFName = "Victor",
                        AuthorMName = null,
                        AuthorLName = "Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Classification = "Fiction",
                        Category = "Classic",
                        NumPages = 1488,
                        Price = 9.95
                    },

                    new Book
                    {
                        Title = "Team of Rivals",
                        AuthorFName = "Doris",
                        AuthorMName = "Kearns",
                        AuthorLName = "Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        NumPages = 944,
                        Price = 14.58
                    },

                    new Book
                    {
                        Title = "The Snowball",
                        AuthorFName = "Alice",
                        AuthorMName = null,
                        AuthorLName = "Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        NumPages = 832,
                        Price = 21.54
                    },

                    new Book
                    {
                        Title = "American Ulysses",
                        AuthorFName = "Ronald",
                        AuthorMName = "C.",
                        AuthorLName = "White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        NumPages = 864,
                        Price = 11.61
                    },

                    new Book
                    {
                        Title = "Unbroken",
                        AuthorFName = "Laura",
                        AuthorMName = null,
                        AuthorLName = "Hillenbrand",
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        Classification = "Non-Fiction",
                        Category = "Historical",
                        NumPages = 528,
                        Price = 13.33
                    },

                    new Book
                    {
                        Title = "The Great Train Robbery",
                        AuthorFName = "Michael",
                        AuthorMName = null,
                        AuthorLName = "Crichton",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        Classification = "Fiction",
                        Category = "Historical Fiction",
                        NumPages = 288,
                        Price = 15.95
                    },

                    new Book
                    {
                        Title = "Deep Work",
                        AuthorFName = "Cal",
                        AuthorMName = null,
                        AuthorLName = "Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455586691",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        NumPages = 304,
                        Price = 14.99
                    },

                    new Book
                    {
                        Title = "It's Your Ship",
                        AuthorFName = "Michael",
                        AuthorMName = null,
                        AuthorLName = "Abrashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        NumPages = 240,
                        Price = 21.66
                    },

                    new Book
                    {
                        Title = "The Virgin Way",
                        AuthorFName = "Richard",
                        AuthorMName = null,
                        AuthorLName = "Branson",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        Classification = "Non-Fiction",
                        Category = "Business",
                        NumPages = 400,
                        Price = 29.16
                    },

                    new Book
                    {
                        Title = "Sycamore Row",
                        AuthorFName = "John",
                        AuthorMName = null,
                        AuthorLName = "Grisham",
                        Publisher = "Bantam",
                        ISBN = "978-0553393613",
                        Classification = "Fiction",
                        Category = "Thrillers",
                        NumPages = 642,
                        Price = 15.03
                    },
                    /*New books added by me*/
                    new Book
                    {
                        Title = "The Book of Mormon",
                        AuthorFName = "Many",
                        AuthorMName = "Ancient",
                        AuthorLName = "Prophets",
                        Publisher = "The Church of Jesus Christ of Latter-day Saints",
                        ISBN = "978-0385513166",
                        Classification = "Non-Fiction",
                        Category = "Scripture",
                        NumPages = 532,
                        Price = 0.00
                    },

                    new Book
                    {
                        Title = "How to Win Friends and Influence People",
                        AuthorFName = "Dale",
                        AuthorMName = null,
                        AuthorLName = "Carnegie",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0671027032",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        NumPages = 291,
                        Price = 11.85
                    },

                    new Book
                    {
                        Title = "East of Eden",
                        AuthorFName = "John",
                        AuthorMName = null,
                        AuthorLName = "Steinbeck",
                        Publisher = "The Viking Press",
                        ISBN = "978-0140186390",
                        Classification = "Fiction",
                        Category = "Historical Fiction",
                        NumPages = 608,
                        Price = 30.84
                    }

                );

                context.SaveChanges();
            }
        }
    }
}
