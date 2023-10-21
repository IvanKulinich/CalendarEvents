using CalendarEvents.Application.Models.RequestModels;
using CalendarEvents.Application.Models.ResponseModels;

namespace CalendarEvents.Application.Interfaces
{
    public interface IEventService
    {
        Task AddEventsAsync(CreateEventsRequestModel model);

        Task<List<GetDaysWithEventsResponseModel>> GetByMonthAsync(GetDaysWithEventsRequestModel model);
    }
}
