namespace Modul.Data.Entities
{
    public class SupplierEntity
    {
        public int SupplierID { get; set; }
        public string? CompanyName { get; set; }
        public string? ContactFName { get; set; }
        public string? ContactLName { get; set; }
        public string? ContactTitle { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public int CustomerID { get; set; }
        public List<ProductEntity>? SupplyProducts { get; set; } = new List<ProductEntity>();
    }
}
