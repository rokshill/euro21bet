using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Euro21bet.Application.Common.Interfaces;
using Euro21bet.Application.Common.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Euro21bet.Application.Matches.Queries
{
    public class GetMatchesQuery : IRequest<MatchesPageVm>
    {

    }

    public class GetMatchesQueryHandler : IRequestHandler<GetMatchesQuery, MatchesPageVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetMatchesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MatchesPageVm> Handle(GetMatchesQuery request, CancellationToken cancellationToken)
        {
            var rounds = await _context.Rounds.AsNoTracking().Include(g => g.Matches.OrderBy(m => m.MatchDateTime)).ProjectToListAsync<RoundVm>(_mapper.ConfigurationProvider);

            return new MatchesPageVm()
            {
                Rounds = rounds
            };
        }
    }
}