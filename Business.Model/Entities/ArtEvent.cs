namespace Business.Model.Entities;

public class ArtEvent
{
    public int ArtEventId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public DateTime Date { get; set; }
    public Venue? Venue { get; set; }
    public ArtOrganization? ArtOrganization { get; set; }
    public virtual PriceList? PriceList { get; set; }
    public virtual ICollection<ScheduleItem>? ScheduleItems { get; set; }
}