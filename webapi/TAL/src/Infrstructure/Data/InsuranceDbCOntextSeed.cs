using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TAL.AppCore.Entities;

namespace TAL.Infrastructure.Data
{
    public class InsuranceDbContextSeed
    {
        public static void Seed(InsuranceDbContext insuranceDbContext, ILoggerFactory loggerFactory)
        {
            try
            {

                if (!insuranceDbContext.Occupations.Any())
                {
                    insuranceDbContext.Occupations.AddRangeAsync(GetPreconfiguredOccupations());
                    insuranceDbContext.OccupationRating.AddRangeAsync(GetPreconfiguredOccupationRatings());

                    insuranceDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var log = loggerFactory.CreateLogger<InsuranceDbContext>();
                log.LogError(ex.Message);
                throw;
            }
        }

        static IEnumerable<OccupationRating> GetPreconfiguredOccupationRatings()
        {
            return new List<OccupationRating>()
            {
                new OccupationRating {OccupationRatingId = 1, Rating = "Professional", Factor = 1.0},
                new OccupationRating {OccupationRatingId = 2, Rating = "White Collar", Factor = 1.25},
                new OccupationRating {OccupationRatingId = 3, Rating = "Light Manual", Factor = 1.50},
                new OccupationRating {OccupationRatingId = 4, Rating = "Heavy Manual", Factor = 1.75}
            };
        }

        static IEnumerable<Occupation> GetPreconfiguredOccupations()
        {
            return new List<Occupation>()
            {
                new Occupation
                {
                    OccupationId =  1,
                    Name = "Cleaner",
                    OccupationRatingId = 3
                },
                new Occupation
                {
                    OccupationId =  2,
                    Name = "Author",
                    OccupationRatingId =2
                },
                new Occupation
                {
                    OccupationId = 3,
                    Name = "Doctor",
                    OccupationRatingId =1
                },
                new Occupation
                {
                    OccupationId = 4,
                    Name = "Farmer",
                    OccupationRatingId =4
                },
                new Occupation
                {
                    OccupationId = 5,
                    Name = "Mechanic",
                    OccupationRatingId =4
                },
                new Occupation
                {
                    OccupationId = 6,
                    Name = "Florist",
                    OccupationRatingId =3
                }
            };
        }
    }
}

