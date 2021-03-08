using System;

namespace TAL.AppCore.Entities
{
    public class Member
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Dob { get; set; }

        public int OccupationId { get; set; }
        public Occupation Occupation { get; set; }
        public decimal DeathSumInsured { get; set; }        
    }
}
