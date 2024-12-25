using System.ComponentModel.DataAnnotations;

namespace Thi.Models
{
    public class ComicBooks
    {
        [Key]
        public int ComicBookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal PricePerDay { get; set; }
    }
}
