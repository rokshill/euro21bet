using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Euro21bet.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Euro21bet.Application.Users.Queries
{
    public class GetUserByEmailQuery : IRequest<UserDto>
    {
        public GetUserByEmailQuery(string email)
        {
            Email = email;
        }

        public string Email { get; }
    }

    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUserByEmailQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email.Equals(request.Email), cancellationToken);
            return _mapper.Map<UserDto>(user);
        }
    }
}