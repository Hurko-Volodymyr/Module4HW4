namespace Modul.Data.Entities
{
    public class PaymentEntity
    {
        public int PaymentID { get; set; }
        public string PaymentType { get; set; } = null!;
        public string Allowed { get; set; } = null!;
        public List<OrderEntity> Orders { get; set; } = new List<OrderEntity>();
    }
}
