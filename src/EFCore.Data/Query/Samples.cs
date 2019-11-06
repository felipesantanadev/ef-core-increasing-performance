using EFCore.Data.Contexts;
using EFCore.Data.DTO;
using EFCore.Data.Mappers;
using EFCore.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCore.Data.Query
{
    public class Samples
    {
        private readonly EFCoreContext _context;
        public Samples(EFCoreContext context)
        {
            _context = context;
        }

        public void GetBookAuthors()
        {

            var query = _context.Books.Select(p =>
                                // It is a nondatabase command
                                // string.Join is executed on client in software
                                string.Join(", ", p.AuthorsLink.OrderBy(a => a.Order).Select(a => a.Author.Name)
                           ));

            query.First(); // executes
        }

        public void GetBookVotesAverage()
        {
            var query = _context.Books.Select(p => p.Reviews.Select(r => (double?)r.NumberOfStars).Average());
            query.First();
        }

        public void GetBookReviewsCount()
        {
            var query = _context.Books.Select(p => p.Reviews.Count);
            query.First();
        }

        public void GetBookPromotionalOrOriginalPrice()
        {
            var query = _context.Books.Select(p => p.Promotion == null ? p.Price : p.Promotion.NewPrice);
            query.First();
        }

        public void GetBookPromotionalText()
        {
            var query = _context.Books.Select(p => p.Promotion == null ? null : p.Promotion.PromotionalText);
            query.First();
        }

        public IQueryable<BookListDto> SearchBooks(OrderOption orderOption, BooksFilterBy filterBy, string filterValue, int pageNumber = 0, int pageSize = 10)
        {
            var query = _context.Books
                                .AsNoTracking() // Because this is a read only query, you add AsNoTracking
                                .MapBookToDto() // Uses the Select query object, which will pick out/calculate the data it needs
                                .OrderBooksBy(orderOption) // Adds the commands to order the data by using the given option
                                .FilterBooksBy(filterBy, filterValue); // Adds the commands to filter data

            return query.Page(pageNumber, pageSize);
        }
    }
}
