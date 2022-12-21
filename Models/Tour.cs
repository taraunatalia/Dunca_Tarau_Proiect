using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Xml.Linq;

namespace Dunca_Tarau_Proiect.Models
{
    public class Tour
    {
        public int ID { get; set; }
        [Display(Name = "Tour Name")]
        public string Name { get; set; }
        public string Location { get; set; }
        public string GroupSize { get; set; }
        public string Time { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartingTourDate { get; set; }
        public int? CountryID { get; set; }
        public Country? Country { get; set; }
        public ICollection<TourCategory>? TourCategories { get; set; }
    }
}
