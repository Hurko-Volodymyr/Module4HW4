namespace Modul.Data.Entities
{
    public class OrderEntity
    {
        public int OrderID { get; set; }
        public int OrderNumber { get; set; }
        public int CustomerID { get; set; }
        public int PaymentID { get; set; }
        public int ShipperID { get; set; }
        public DateTime OrderDate { get; set; }
        public CustomerEntity? Customer { get; set; }
        public PaymentEntity? Payment { get; set; }
        public ShipperEntity? Shipper { get; set; }
        public List<ProductEntity> Products { get; set; } = new List<ProductEntity>();
    }
}
