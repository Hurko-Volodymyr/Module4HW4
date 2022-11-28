namespace Modul.Data.Entities
{
    public class ProductEntity
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = null!;
        public string ProductDescription { get; set; } = null!;
        public int? CategoryID { get; set; }
        public int? SupplierID { get; set; }
        public SupplierEntity? Supplier { get; set; }
        public CategoryEntity? Category { get; set; }
        public List<OrderEntity> Orders { get; set; } = new List<OrderEntity>();
    }
}
