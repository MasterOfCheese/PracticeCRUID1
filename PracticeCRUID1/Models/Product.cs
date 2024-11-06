using System.ComponentModel.DataAnnotations;

namespace PracticeCRUID1.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string ?Name { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [StringLength(250, ErrorMessage = "Description cannot be longer than 250 characters")]
        public string ?Description { get; set; }

        [Range(0.01, 10000.00, ErrorMessage = "Price must be between 0.01 and 10,000")]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

         
    }
}
