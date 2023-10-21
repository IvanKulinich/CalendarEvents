using CalendarEvents.Application.Interfaces;
using CalendarEvents.Application.Models.RequestModels;
using CalendarEvents.Application.Models.ResponseModels;
using CalendarEvents.Common.Constants;
using CalendarEvents.Domain.Entities;
using CalendarEvents.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CalendarEvents.Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly CalendarEventsDbContext _dbContext;

        public EventRepository(CalendarEventsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddEventsAsync(CreateEventsRequestModel model)
        {
            await _dbContext.Events.AddRangeAsync(model.Events.Select(m => new Event
            {
                Title = m.Title,
                Date = model.Date
            }));
        }

        public async Task<List<GetDaysWithEventsResponseModel>> GetByMonthAsync(GetDaysWithEventsRequestModel model)
        {
            return await _dbContext.Events
                .AsNoTracking()
                .Where(e => e.Date.Year == model.Year && e.Date.Month == (int)model.Month)
                .GroupBy(g => g.Date.Day)
                .Select(e => new GetDaysWithEventsResponseModel
                {
                    Date = e.Select(m => m.Date.ToString(DateTimeFormatConstants.ShortDate)).First(),
                    Events = e.Select(t => new EventResponseModel
                    {
                        Title = t.Title
                    }).ToList()
                })
                .ToListAsync();
        }
    }
}
