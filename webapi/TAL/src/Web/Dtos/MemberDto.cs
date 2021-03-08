using System;

namespace TAL.WebApi.Dtos
{
    public class MemberDto
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime? Dob { get; set; }

        public int OccupationId { get; set; }
        public decimal DeathSumInsured { get; set; }
    }
}
