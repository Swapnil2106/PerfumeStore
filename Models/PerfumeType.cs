namespace PerfumeStore.Models
{
    public class PerfumeType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Perfume> Perfumes { get; set; }      //One Type -> Many Perfumes
    }
}
