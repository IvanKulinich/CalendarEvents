using CalendarEvents.Constants;
using CalendarEvents.Contexts;
using CalendarEvents.Entities;
using CalendarEvents.Interfaces;
using CalendarEvents.Models.RequestModels;
using CalendarEvents.Models.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace CalendarEvents.Services
{
    public class EventService : IEventService
    {
        private readonly CalendarEventsDbContext _dbContext;

        public EventService(CalendarEventsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddEventsAsync(CreateEventsRequestModel model)
        {
            IEnumerable<Event> addedEvents = model.Events.Select(m => new Event
            {
                Title = m.Title,
                Date = model.Date
            });

            await _dbContext.Events.AddRangeAsync(addedEvents);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<GetDaysWithEventsResponseModel>> GetAllDaysWithEventsByMonth(GetDaysWithEventsRequestModel model)
        {
            return await _dbContext.Events
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
