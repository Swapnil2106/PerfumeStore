namespace PerfumeStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }                                                     //Foreign Key for User
        public User User { get; set; }                                                      //Navigation Property for User
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "Pending";
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();     //One Order -> Many OrderItems
    }
}
