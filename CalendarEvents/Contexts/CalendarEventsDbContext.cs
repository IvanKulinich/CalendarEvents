using CalendarEvents.Entities;
using Microsoft.EntityFrameworkCore;

namespace CalendarEvents.Contexts
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
