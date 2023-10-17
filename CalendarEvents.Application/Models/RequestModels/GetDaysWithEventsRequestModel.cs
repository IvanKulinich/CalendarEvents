using System.ComponentModel.DataAnnotations;

namespace CalendarEvents.Application.Models.RequestModels
{
    public class GetDaysWithEventsRequestModel
    {
        [Required]
        public int Year { get; set; }

        [Required]
        public Month Month { get; set; }
    }

    public enum Month
    {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }
}
