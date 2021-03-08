using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TAL.AppCore.Entities;
using TAL.AppCore.Interfaces;
using TAL.Infrastructure.Data;

namespace TAL.Infrastructure
{
    /// <summary>
    /// Occupation repository to return occupations
    /// </summary>
    public class OccupationRepository : BaseRepository<Occupation>, IOccupationRepository
    {
        private readonly InsuranceDbContext _insuranceDbContext;
        public readonly ILogger<OccupationRepository> _logger;

        public OccupationRepository(ILogger<OccupationRepository> logger, InsuranceDbContext dbContext) : base(dbContext)
        {
            _insuranceDbContext = dbContext;
            _logger = logger;
        }

        public async Task<Occupation> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = _insuranceDbContext.Occupations.Include(x=>x.OccupationRating).ToList();
            return await _insuranceDbContext.Occupations.Include(x=>x.OccupationRating)
                .FirstOrDefaultAsync(x=>x.OccupationId==id, cancellationToken: cancellationToken);
        }
    }
}
