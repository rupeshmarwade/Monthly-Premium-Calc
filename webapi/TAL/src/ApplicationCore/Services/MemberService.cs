using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TAL.AppCore.Entities;
using TAL.AppCore.Interfaces;

namespace TAL.AppCore.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly ILogger<MemberService> _logger;

        public MemberService(ILogger<MemberService> logger, IMemberRepository repository)
        {
            _memberRepository = repository;
            _logger = logger;
        }
        public async Task<Member> GetMember(int id)
        {
            return await _memberRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Member>> GetMembers()
        {
            return await _memberRepository.ListAllAsync();
        }
    }
}
