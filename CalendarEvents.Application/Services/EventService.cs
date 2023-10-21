using CalendarEvents.Application.Interfaces;
using CalendarEvents.Application.Models.RequestModels;
using CalendarEvents.Application.Models.ResponseModels;

namespace CalendarEvents.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddEventsAsync(CreateEventsRequestModel model)
        {
            await _unitOfWork.Events.AddEventsAsync(model);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<GetDaysWithEventsResponseModel>> GetByMonthAsync(GetDaysWithEventsRequestModel model)
        {
            return await _unitOfWork.Events.GetByMonthAsync(model);
        }
    }
}
