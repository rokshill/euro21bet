using System;
using Euro21bet.Application.Common.Interfaces;

namespace Euro21bet.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.UtcNow;

        public static IDateTime Instance => new DateTimeService();
    }
}
