using System.ComponentModel.DataAnnotations;

namespace BookAPI.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Cover { get; set; }

        [DataType(DataType.Currency)]
        public float Price { get; set; }
    }
}
