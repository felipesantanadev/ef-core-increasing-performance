using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCore.Data.Query
{
    public static class GenericQuery
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> query, int page, int size)
        {
            if (size <= 0)
                throw new ArgumentOutOfRangeException(nameof(size), "page size cannot be 0 or negative.");

            query = query.Skip(page * size);
            return query.Take(size);
        }
    }
}
