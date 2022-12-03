using Modul.Data.Entities;

namespace Modul.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public string? Picture { get; set; }
        public bool? Active { get; set; }
        public List<ProductEntity>? Products { get; set; } = new List<ProductEntity>();
    }
}
