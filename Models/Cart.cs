namespace PerfumeStore.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }                  // Foreign Key reference for UserId from User Table
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();            //one Cart --> Many CartItems

    }
}
