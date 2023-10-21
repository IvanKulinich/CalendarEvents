using CalendarEvents.Application.Interfaces;
using CalendarEvents.Infrastructure.Contexts;

namespace CalendarEvents.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CalendarEventsDbContext _dbContext;

        public IEventRepository Events { get; }

        public UnitOfWork(CalendarEventsDbContext dbContext, IEventRepository eventRepository)
        {
            _dbContext = dbContext;
            Events = eventRepository;
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}
