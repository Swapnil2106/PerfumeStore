namespace PerfumeStore.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }            //Foreign Key for Order
        public Order Order { get; set; }            //Navigation Property for Order
        public int PerfumeId { get; set; }          //Foreign Key for Perfume
        public Perfume Perfume { get; set; }        //Navigation Property for Perfume
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
