namespace Business.Model.Entities;

public class Ticket
{
    public int TicketId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public Area? Area { get; set; }
    public int SeatId { get; set; }
    public Seat? Seat { get; set; }
    public ScheduleItem? ScheduleItem { get; set; }
}