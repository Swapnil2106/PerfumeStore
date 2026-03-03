namespace PerfumeStore.DTOs
{
    public class UpdatePerfumeDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int PerfumeCategoryId { get; set; }
        public int PerfumeTypeId { get; set; }
    }
}
