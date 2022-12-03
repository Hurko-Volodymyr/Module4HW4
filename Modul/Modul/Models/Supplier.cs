namespace Modul.Models
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        public string? CompanyName { get; set; }
        public string? ContactFName { get; set; }
        public string? ContactLName { get; set; }
        public string? ContactTitle { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public int? CustomerID { get; set; }
        public List<Product>? Products { get; set; } = new List<Product>();
    }
}
