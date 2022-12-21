namespace Dunca_Tarau_Proiect.Models
{
    public class TourData
    {
        public IEnumerable<Tour> Tours { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<TourCategory> TourCategories { get; set; }
    }
}
