using System.ComponentModel.DataAnnotations;

namespace PerfumeStore.Models
{
    public class Perfume
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Range(1, 100000)]
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string? ImageUrl { get; set; }
        public int PerfumeCategoryId { get; set; }              //Foreign Key for Category
        public Category? PerfumeCategory { get; set; }    //Navigation Property for Category
        public int PerfumeTypeId { get; set; }                  //Foreign Key for Type
        public Type? PerfumeType { get; set; }            //Navigation Property for Type
    }
}
