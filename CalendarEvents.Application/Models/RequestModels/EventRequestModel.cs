using System.ComponentModel.DataAnnotations;

namespace CalendarEvents.Application.Models.RequestModels
{
    public class EventRequestModel
    {
        [Required]
        public string Title { get; set; }
    }
}
