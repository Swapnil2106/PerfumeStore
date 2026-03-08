namespace PerfumeStore.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }                  //Foreign key reference for CartId from Cart Table
        public int PerfumeId { get; set; }
        public Perfume Perfume { get; set; }            //Foreign key reference for PerfumeId from Perfume Table
        public int Quantity { get; set; }
    }
}
