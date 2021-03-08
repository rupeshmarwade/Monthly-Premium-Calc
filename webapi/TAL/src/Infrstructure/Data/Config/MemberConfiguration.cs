using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TAL.AppCore.Entities;

namespace TAL.Infrastructure.Data.Config
{

    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
           builder.Property(b => b.OccupationId).IsRequired();
        }
    }
}
