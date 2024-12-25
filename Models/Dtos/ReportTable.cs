using System.ComponentModel.DataAnnotations;

namespace Thi.Models.Dtos
{
    public class ReportTable
    {
        public string BookName { get; set; }
        public DateTime RentalDate  { get; set; }
        public DateTime ReturnDate { get; set; }
        public int Quantity { get; set; }
        
    }
}
