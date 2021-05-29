using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Euro21bet.Application.Common.Interfaces;
using Euro21bet.Application.Common.Mappings;
using MediatR;

namespace Euro21bet.Application.Teams.Queries
{
    public class GetAllTeamsQuery : IRequest<IReadOnlyCollection<TeamDto>>
    {
        
    }
    public class GetAllTeamsQueryHandler : IRequestHandler<GetAllTeamsQuery, IReadOnlyCollection<TeamDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        
        public GetAllTeamsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<TeamDto>> Handle(GetAllTeamsQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Teams.ProjectToListAsync<TeamDto>(_mapper.ConfigurationProvider);

            return result;
        }
    }
}