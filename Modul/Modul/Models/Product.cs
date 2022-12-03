using Modul.Data.Entities;

namespace Modul.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = null!;
        public string ProductDescription { get; set; } = null!;
        public int? CategoryID { get; set; }
        public int? SupplierID { get; set; }
        public Category? Category { get; set; }
        public Supplier? Supplier { get; set; }
        public List<OrderDetail>? Products { get; set; } = new List<OrderDetail>();
    }
}
