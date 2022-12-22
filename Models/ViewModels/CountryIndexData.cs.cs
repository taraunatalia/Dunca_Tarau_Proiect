using System.Security.Policy;

namespace Dunca_Tarau_Proiect.Models.ViewModels
{
    public class CountryIndexData
    {
        public IEnumerable<Country> Countries { get; set; }
        public IEnumerable<Tour> Tours { get; set; }
    }
}
