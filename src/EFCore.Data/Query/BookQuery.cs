using EFCore.Data.DTO;
using EFCore.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCore.Data.Query
{
    public static class BookQuery
    {
        public static IQueryable<BookListDto> OrderBooksBy(this IQueryable<BookListDto> books, OrderOption orderOption)
        {
            switch(orderOption)
            {
                case OrderOption.SimpleOrder:
                    return books.OrderByDescending(x => x.BookId);
                case OrderOption.ByVotes:
                    return books.OrderByDescending(x => x.ReviewAverageVotes);
                case OrderOption.ByPublicationDate:
                    return books.OrderByDescending(x => x.PublishedOn);
                case OrderOption.ByPriceLowestFirst:
                    return books.OrderBy(x => x.ActualPrice);
                case OrderOption.ByPriceHighestFirst:
                    return books.OrderByDescending(x => x.ActualPrice);
                default:
                    throw new ArgumentOutOfRangeException(nameof(orderOption), orderOption, null);
            }
        }

        public static IQueryable<BookListDto> FilterBooksBy(this IQueryable<BookListDto> books, BooksFilterBy filterBy, string filterValue)
        {
            if (string.IsNullOrEmpty(filterValue))
                return books;

            switch(filterBy)
            {
                case BooksFilterBy.NoFilter:
                    return books;
                case BooksFilterBy.ByVotes:
                    var filterVotes = int.Parse(filterValue);
                    return books.Where(x => x.ReviewAverageVotes > filterVotes);
                case BooksFilterBy.ByPublicationYear:
                    var filterYear = int.Parse(filterValue);
                    return books.Where(x => x.PublishedOn.Year == filterYear);
                case BooksFilterBy.ContainsString:
                    // Note: Contains, StartsWith and EndsWith are the only methods that can be translated to SQL
                    // to compare strings
                    return books.Where(x => x.Title.Contains(filterValue));
                default:
                    throw new ArgumentOutOfRangeException(nameof(filterBy), filterBy, null);
            }
        }
    }
}
