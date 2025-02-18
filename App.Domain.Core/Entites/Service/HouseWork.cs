using App.Domain.Core.Entites.User;
using System.ComponentModel.DataAnnotations;
namespace App.Domain.Core.Entites.Service
{
    public class HouseWork
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [MaxLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string? Description { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "ViewCount must be a positive number.")]
        public int ViewCount { get; set; }

        [Required(ErrorMessage = "Base price is required.")]
        [Range(0.01, 5000000, ErrorMessage = "Base price must be between 0.01 and 5,000,000.")]
        public decimal BasePrice { get; set; }
        public string? ImagePath { get; set; }
        public bool IsDeleted { get; set; } = false;


        public int CategoryId { get; set; }

        public List<Expert>? Expert { get; set; }
        public Category Category { get; set; }
        public List<Order> Orders { get; set; }
        public Image Image { get; set; }
    }
}
