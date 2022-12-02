namespace Modul.Data.Entities
{
    public class ShipperEntity
    {
        public int ShipperID { get; set; }
        public string? CompanyName { get; set; }
        public string? Phone { get; set; }
        public List<OrderEntity>? Orders { get; set; } = new List<OrderEntity>();
    }
}
