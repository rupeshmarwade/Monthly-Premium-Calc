using System.ComponentModel.DataAnnotations.Schema;

namespace TAL.AppCore.Entities
{
    public class Occupation
    {
        public int OccupationId { get; set; }
        public string Name { get; set; }
        public virtual int OccupationRatingId { get; set; }
        
        public virtual OccupationRating OccupationRating { get; set; }
    }
}
