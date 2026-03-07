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
        [Range(0, 1000)]
        public int StockQuantity { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }              //Foreign Key for Category
        public Category? Category { get; set; }    //Navigation Property for Category
        public int TypeId { get; set; }                  //Foreign Key for Type
        public Type? Type { get; set; }            //Navigation Property for Type
    }
}
