﻿using CalendarEvents.Application.Models.RequestModels;
using CalendarEvents.Application.Models.ResponseModels;

namespace CalendarEvents.Application.Interfaces
{
    public interface IEventRepository
    {
        Task AddEventsAsync(CreateEventsRequestModel model);

        Task<List<GetDaysWithEventsResponseModel>> GetAllDaysWithEventsByMonth(GetDaysWithEventsRequestModel model);
    }
}