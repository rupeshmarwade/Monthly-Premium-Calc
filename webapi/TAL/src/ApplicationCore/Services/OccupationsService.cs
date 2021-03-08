using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TAL.AppCore.Entities;
using TAL.AppCore.Interfaces;

namespace TAL.AppCore.Services
{
    public class OccupationsService : IOccupationsService
    {
        private readonly IOccupationRepository _occupationRepository;
        private readonly ILogger<OccupationsService> _logger;

        public OccupationsService(ILogger<OccupationsService> logger, IOccupationRepository repository)
        {
            _occupationRepository = repository;
            _logger = logger;
        }
        public async Task<Occupation> GetOccupation(int id)
        {
            return await _occupationRepository.GetByIdAsync( id);
        }

        public async Task<IEnumerable<Occupation>> GetOccupations()
        {
           return await _occupationRepository.ListAllAsync();
        }
    }
}
