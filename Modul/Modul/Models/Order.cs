using Modul.Data.Entities;

namespace Modul.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int OrderNumber { get; set; }
        public int CustomerID { get; set; }
        public int PaymentID { get; set; }
        public int ShipperID { get; set; }
        public DateTime OrderDate { get; set; }
        public CustomerEntity? Customer { get; set; }
        public Payment? Payment { get; set; }
        public Shipper? Shipper { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
