namespace Modul.Data.Entities
{
    public class SupplierEntity
    {
        public int SupplierID { get; set; }
        public string CompanyName { get; set; } = null!;
        public string ContactFName { get; set; } = null!;
        public string ContactLName { get; set; } = null!;
        public string ContactTitle { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public int? CustomerID { get; set; }
        public List<ProductEntity>? Products { get; set; } = new List<ProductEntity>();
    }
}
