using System.ComponentModel.DataAnnotations;

namespace CalendarEvents.Models.RequestModels
{
    public class EventRequestModel
    {
        [Required]
        public string Title { get; set; }
    }
}
