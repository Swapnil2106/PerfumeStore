using System.ComponentModel.DataAnnotations;

namespace PerfumeStore.DTOs.Perfume
{
    public class UpdatePerfumeDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string ImageUrl { get; set; }
        public int PerfumeCategoryId { get; set; }
        public int PerfumeTypeId { get; set; }
    }
}
