namespace Modul.Data.Entities
{
    public class CategoryEntity
    {
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public string? Picture { get; set; }
        public bool? Active { get; set; }
        public List<ProductEntity> Products { get; set; } = new List<ProductEntity>();
    }
}
