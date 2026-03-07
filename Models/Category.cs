namespace PerfumeStore.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Perfume> Perfumes { get; set; } = new List<Perfume>();      //One Category -> Many Perfumes
    }
}
