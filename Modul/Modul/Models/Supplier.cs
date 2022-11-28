namespace Modul.Models
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        public string CompanyName { get; set; } = null!;
        public string ContactFName { get; set; } = null!;
        public string ContactLName { get; set; } = null!;
        public string ContactTitle { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public int CustomerID { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
