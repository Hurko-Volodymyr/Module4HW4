namespace Modul.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public string PaymentType { get; set; } = null!;
        public string Allowed { get; set; } = null!;
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
