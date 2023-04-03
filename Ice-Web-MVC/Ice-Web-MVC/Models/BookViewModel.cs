using System.ComponentModel.DataAnnotations;

namespace Ice_Web_MVC.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string? Title { get; set; }
        [Range(0, double.MaxValue)]
        public int Price { get; set; }
    }
}
