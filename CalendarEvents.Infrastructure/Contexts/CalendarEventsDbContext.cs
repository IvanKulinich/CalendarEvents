using CalendarEvents.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CalendarEvents.Infrastructure.Contexts
{
    public class CalendarEventsDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }

        public CalendarEventsDbContext(DbContextOptions<CalendarEventsDbContext> options)
            : base(options)
        {
        }
    }
}
