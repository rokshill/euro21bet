using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TournamentForm.Application.Common.Interfaces;
using TournamentForm.Application.Common.Mappings;

namespace TournamentForm.Application.Items.Queries
{
    public class GetItemsQuery : IRequest<ItemsPageVm>
    {

    }

    public class GetItemsQueryHandler : IRequestHandler<GetItemsQuery, ItemsPageVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetItemsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ItemsPageVm> Handle(GetItemsQuery request, CancellationToken cancellationToken)
        {
            var items = await _context.Items.AsNoTracking().ProjectToListAsync<ItemVm>(_mapper.ConfigurationProvider);

            return new ItemsPageVm()
            {
                Items = items
            };
        }
    }
}