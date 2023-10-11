using System.ComponentModel.DataAnnotations;

namespace CalendarEvents.Models.RequestModels
{
    public class CreateEventsRequestModel
    {
        [Required]
        public DateTime Date { get; set; }

        [Required, MinLength(1)]
        public List<EventRequestModel> Events { get; set; }
    }
}
