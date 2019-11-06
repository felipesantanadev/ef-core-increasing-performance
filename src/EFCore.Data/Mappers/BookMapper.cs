using EFCore.Data.DTO;
using EFCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCore.Data.Mappers
{
    public static class BookMapper
    {
        /* 
         * NOTE:
         * Query Object Pattern
         * This patter is all about encapsulating a query or a part of it in a method.
         * That way, the query is isolated in one place, which makes it easier to find, debug and
         * performance-tune.
         * This patter is also in the sort, filter and paging queries of this project (Data.Query namespace).
        */

        public static IQueryable<BookListDto> MapBookToDto(this IQueryable<Book> books)
        {
            return books.Select(x => new BookListDto
            {
                BookId = x.BookId,
                Title = x.Title,
                Price = x.Price,
                PublishedOn = x.PublishedOn,
                ActualPrice = x.Promotion == null ? x.Price : x.Promotion.NewPrice,
                PromotionalText = x.Promotion == null ? null : x.Promotion.PromotionalText,
                AuthorsOrdered = string.Join(", ", x.AuthorsLink.OrderBy(a => a.Order).Select(a => a.Author.Name)),
                ReviewCount = x.Reviews.Count,
                ReviewAverageVotes = x.Reviews.Select(r => (double?)r.NumberOfStars).Average()
            });
        }
    }
}
