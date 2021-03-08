using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TAL.AppCore.Interfaces;
using TAL.Infrastructure.Data;

namespace TAL.Infrastructure
{
    /// <summary>
    /// Base Repository for all repositories
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly InsuranceDbContext _dbContext;

        public BaseRepository(InsuranceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>().ToListAsync(cancellationToken);
        }
    }
}
