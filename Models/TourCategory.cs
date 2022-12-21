namespace Dunca_Tarau_Proiect.Models
{
    public class TourCategory
    {
        public int ID { get; set; }
        public int TourID { get; set; }
        public Tour Tour { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
