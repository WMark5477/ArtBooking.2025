namespace Business.Model.Entities;

public class Area
{
    public int AreaId { get; set; }
    public string Name { get; set; }
    public Venue? Venue { get; set; }
    public virtual ICollection<Seat>? Seats { get; set; }
    public virtual ICollection<Ticket>? Tickets { get; set; }
    public virtual ICollection<PriceEntry>? PriceEntries { get; set; }
}