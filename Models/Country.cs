namespace Dunca_Tarau_Proiect.Models
{
    public class Country
    {
        public int ID { get; set; }
        public string CountryName { get; set; }
        public ICollection<Tour>? Tours { get; set; }
    }
}
