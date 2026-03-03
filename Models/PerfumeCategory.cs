namespace PerfumeStore.Models
{
    public class PerfumeCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Perfume> Perfumes { get; set; }      //One Category -> Many Perfumes
    }
}
