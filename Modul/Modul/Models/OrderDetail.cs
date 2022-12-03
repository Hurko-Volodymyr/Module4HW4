namespace Modul.Models
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }
        public Product? Product { get; set; }
        public Order? Order { get; set; }
    }
}
