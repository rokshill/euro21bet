using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Euro21bet.Application.Common.Interfaces;
using Euro21bet.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Euro21bet.Application.Standings.Queries
{
    public class GetStandingsQuery : IRequest<StandingsPageViewModel>
    {
        
    }

    public class GetStandingsQueryHandler : IRequestHandler<GetStandingsQuery, StandingsPageViewModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        
        public GetStandingsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StandingsPageViewModel> Handle(GetStandingsQuery request, CancellationToken cancellationToken)
        {
            var groups = _context.Groups.Include(g => g.Teams).AsNoTracking().ToList();

            var standingsList = groups.Select(g => new StandingsViewModel()
            {
                Name = g.Name,
                Records = g.Teams.OrderBy(t => t.ShortName).Select(t => new StandingsRecord()
                {
                    TeamId = t.Id,
                    Team = t.Name,
                    CrestUrl = t.CrestUrl,
                    
                    MatchesPlayed = t.Standings.MatchesPlayed,
                    Won = t.Standings.Won,
                    Draw = t.Standings.Draw,
                    Loss = t.Standings.Loss,
                    GoalFor = t.Standings.GoalFor,
                    GoalAgainst = t.Standings.GoalAgainst,
                    GoalDifference = t.Standings.GoalDifference,
                    Points = t.Standings.Points
                }).ToList()
            }).ToList();

            foreach (var standings in standingsList)
            {
                int i = 1;
                foreach (var rec in standings.Records)
                {
                    rec.Position = i++;
                }
            }

            return new StandingsPageViewModel()
            {
                Standings = standingsList
            };
        }
    }
}