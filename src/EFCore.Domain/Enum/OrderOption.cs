using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Domain.Enum
{
    public enum OrderOption
    {
        SimpleOrder,
        ByVotes,
        ByPublicationDate,
        ByPriceLowestFirst,
        ByPriceHighestFirst
    }
}
