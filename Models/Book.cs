using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Book
    {
        [Key] /*Primary key for database*/
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string AuthorFName { get; set; }
        #nullable enable
        public string? AuthorMName { get; set; }
        #nullable disable
        [Required]
        public string AuthorLName { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        [RegularExpression(@"^\d{3}-\d{10}$", ErrorMessage = "The ISBN must be in this format: 333-3333333333")] /*Ensures ISBN is in proper format*/
        public string ISBN { get; set; }
        [Required]
        public string Classification { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
