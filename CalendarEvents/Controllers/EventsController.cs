using CalendarEvents.Application.Interfaces;
using CalendarEvents.Application.Models.RequestModels;
using CalendarEvents.Application.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace CalendarEvents.API.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.Created)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateEventsAsync([FromBody] CreateEventsRequestModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Request model is NULL");
                }

                await _eventService.AddEventsAsync(model);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<GetDaysWithEventsResponseModel>))]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDaysWithEventsAsync([FromQuery] GetDaysWithEventsRequestModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Request model is NULL");
                }

                var eventsByMonth = await _eventService.GetByMonthAsync(model);
                if (!eventsByMonth.Any())
                {
                    return NotFound();
                }

                return Ok(eventsByMonth);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
