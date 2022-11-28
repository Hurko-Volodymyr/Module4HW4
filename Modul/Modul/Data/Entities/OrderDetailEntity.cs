namespace Modul.Data.Entities
{
    public class OrderDetailEntity
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public string Size { get; set; } = null!;
        public string Color { get; set; } = null!;
        public ProductEntity? Product { get; set; }
        public OrderEntity? Order { get; set; }
    }
}
