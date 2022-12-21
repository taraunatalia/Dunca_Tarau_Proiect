namespace Dunca_Tarau_Proiect.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<TourCategory>? TourCategories { get; set; }
    }
}
