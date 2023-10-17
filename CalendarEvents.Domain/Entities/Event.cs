using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CalendarEvents.Domain.Entities
{
    [Table("Events")]
    public class Event
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Title { get; set; }

        public DateTime Date { get; set; }
    }
}
