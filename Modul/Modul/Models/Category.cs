namespace Modul.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Picture { get; set; } = null!;
        public string Active { get; set; } = null!;
        public List<Product> Categories { get; set; } = new List<Product>();
    }
}
