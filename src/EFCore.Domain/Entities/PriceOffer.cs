using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Domain.Entities
{
    public class PriceOffer
    {
        public int PriceOfferId { get; set; }
        public decimal NewPrice { get; set; }
        public string PromotionalText { get; set; }
        public int BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}
