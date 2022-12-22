namespace Dunca_Tarau_Proiect.Models.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<TourCategory> TourCategories { get; set; }
        public IEnumerable<Tour> Tours { get; set; }
    }
}
