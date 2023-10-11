namespace CalendarEvents.Models.ResponseModels
{
    public class GetDaysWithEventsResponseModel
    {
        public string Date { get; set; }

        public List<EventResponseModel> Events { get; set; }
    }
}
