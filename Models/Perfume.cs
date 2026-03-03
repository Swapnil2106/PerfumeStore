namespace PerfumeStore.Models
{
    public class Perfume
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int PerfumeCategoryId { get; set; }              //Foreign Key for Category
        public PerfumeCategory PerfumeCategory { get; set; }    //Navigation Property for Category
        public int PerfumeTypeId { get; set; }                  //Foreign Key for Type
        public PerfumeType PerfumeType { get; set; }            //Navigation Property for Type
    }
}
