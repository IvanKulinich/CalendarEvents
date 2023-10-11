using CalendarEvents.Models.RequestModels;
using CalendarEvents.Models.ResponseModels;

namespace CalendarEvents.Interfaces
{
    public interface IEventService
    {
        Task AddEventsAsync(CreateEventsRequestModel model);

        Task<List<GetDaysWithEventsResponseModel>> GetAllDaysWithEventsByMonth(GetDaysWithEventsRequestModel model);
    }
}
