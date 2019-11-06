using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Data.DTO
{
    public class BookListDto
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public DateTime PublishedOn { get; set; }
        public decimal Price { get; set; } // Normal Price
        public decimal ActualPrice { get; set; } // Selling price - either the normal price or the promotional.NewPrice
        public string PromotionalText { get; set; }
        public string AuthorsOrdered { get; set; } // String to hold the comma-delimited list of author's names
        public int ReviewCount { get; set; } // Number of people who reviewed the book
        public double? ReviewAverageVotes { get; set; }
    }
}
