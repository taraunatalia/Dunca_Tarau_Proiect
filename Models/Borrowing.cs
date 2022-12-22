using System.ComponentModel.DataAnnotations;

namespace Dunca_Tarau_Proiect.Models
{
    public class Borrowing
    {
        public int ID { get; set; }
        public int? MemberID { get; set; }
        public Member? Member { get; set; }
        public int? TourID { get; set; }
        public Tour? Book { get; set; }
        [DataType(DataType.Date)]
        public DateTime FinishingTourDate { get; set; }
    }
}
