using System;
using System.Collections.Generic;

namespace Cricket.Models
{
    public partial class Stadium
    {
        public string StadiumName { get; set; }
        public int? MatchesAllowed { get; set; }
        public long? StadiumCapacity { get; set; }
        public int? StadiumId { get; set; }

        public Country StadiumNavigation { get; set; }
    }
}
