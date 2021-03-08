using System.Collections.Generic;

namespace TAL.AppCore.Entities
{
    public class OccupationRating
    {
        public int OccupationRatingId { get; set; }
        public string Rating { get; set; }
        public double Factor { get; set; }

        public virtual List<Occupation> Occupations { get; set; }
    }
}
