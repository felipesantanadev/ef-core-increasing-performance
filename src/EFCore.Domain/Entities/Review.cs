using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Domain.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string VoterName { get; set; }
        public int NumberOfStars { get; set; }
        public string Comment { get; set; }
        public int BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}
