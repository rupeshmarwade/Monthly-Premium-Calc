using Microsoft.EntityFrameworkCore;
using TAL.AppCore.Entities;

namespace TAL.Infrastructure.Data
{
    /// <summary>
    /// Insurance db context fro EF
    /// </summary>
    public class InsuranceDbContext : DbContext
    {
        public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options)
            : base(options)
        {
        }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<OccupationRating> OccupationRating { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Occupation>()
                .HasOne<OccupationRating>()
                .WithMany(x => x.Occupations)
                .HasForeignKey(x=>x.OccupationRatingId);
                
            builder.Entity<OccupationRating>().HasMany<Occupation>()
                .WithOne(x=>x.OccupationRating)
                .HasForeignKey(x=>x.OccupationRatingId);
        }
    }
}
