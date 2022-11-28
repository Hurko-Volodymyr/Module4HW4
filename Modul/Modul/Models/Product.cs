namespace Modul.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = null!;
        public string ProductDescription { get; set; } = null!;
        public int? CategoryID { get; set; }
        public int? SupplierID { get; set; }
        public Supplier? Supplier { get; set; }
        public Category? Category { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
