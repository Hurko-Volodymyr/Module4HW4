namespace Modul.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public string? PaymentType { get; set; }
        public string? Allowed { get; set; }
        public List<Order>? Orders { get; set; } = new List<Order>();
    }
}
