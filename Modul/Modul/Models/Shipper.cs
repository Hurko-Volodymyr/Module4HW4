namespace Modul.Models
{
    public class Shipper
    {
        public int ShipperID { get; set; }
        public string CompanyName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
