using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TAL.AppCore.Entities;
using TAL.AppCore.Interfaces;
using TAL.Infrastructure.Data;

namespace TAL.Infrastructure
{
    /// <summary>
    /// Occupation repository to return occupations
    /// </summary>
    public class MemberRepository : BaseRepository<Member>, IMemberRepository
    {
        private readonly InsuranceDbContext _insuranceDbContext;
        public readonly ILogger<MemberRepository> _logger;

        public MemberRepository(ILogger<MemberRepository> logger,InsuranceDbContext dbContext) : base(dbContext)
        {
            _insuranceDbContext = dbContext;
            _logger = logger;
        }

        public async Task<Member> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _insuranceDbContext.Members.FindAsync(id);
        }
    }
}
