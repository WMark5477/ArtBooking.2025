namespace Business.Model.Entities;

public class ScheduleItem
{
    public int ScheduleItemId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Venue? Venue { get; set; }
    public ArtEvent? Event { get; set; }
    public virtual ICollection<Ticket> Tickets { get; set; }
}