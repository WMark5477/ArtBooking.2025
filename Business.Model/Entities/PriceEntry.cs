namespace Business.Model.Entities;

public class PriceEntry
{
    public int PriceEntryId { get; set; }
    public string Name { get; set; }
    public string Price { get; set; }
    public Area? area { get; set; }
    public PriceList? PriceList { get; set; }
}