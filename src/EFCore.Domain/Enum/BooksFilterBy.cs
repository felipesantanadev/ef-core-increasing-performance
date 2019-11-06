using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Domain.Enum
{
    public enum BooksFilterBy
    {
        NoFilter,
        ByVotes,
        ByPublicationYear,
        ContainsString
    }
}
