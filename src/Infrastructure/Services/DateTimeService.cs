using System;
using TournamentForm.Application.Common.Interfaces;

namespace TournamentForm.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.UtcNow;

        public static IDateTime Instance => new DateTimeService();
    }
}
