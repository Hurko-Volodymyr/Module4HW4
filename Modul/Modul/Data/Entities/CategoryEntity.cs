namespace Modul.Data.Entities
{
    public class CategoryEntity
    {
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public string? Picture { get; set; } = null!;
        public string? Active { get; set; } = null!;
        public List<ProductEntity>? Products { get; set; } = new List<ProductEntity>();
    }
}
