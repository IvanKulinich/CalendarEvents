using CalendarEvents.Application.Interfaces;
using CalendarEvents.Application.Models.RequestModels;
using CalendarEvents.Application.Models.ResponseModels;

namespace CalendarEvents.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task AddEventsAsync(CreateEventsRequestModel model)
        {
            await _eventRepository.AddEventsAsync(model);
        }

        public async Task<List<GetDaysWithEventsResponseModel>> GetAllDaysWithEventsByMonth(GetDaysWithEventsRequestModel model)
        {
            return await _eventRepository.GetAllDaysWithEventsByMonth(model);
        }
    }
}
