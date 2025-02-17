using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.Entites
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(255, ErrorMessage = "Title cannot exceed 255 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Image is required.")]
        [MaxLength(500, ErrorMessage = "Image path cannot exceed 500 characters.")]
        public string? ImagePath { get; set; }
        public bool? IsDeleted { get; set; }

        public int? ParentId { get; set; }

        public Category? ParentCategory { get; set; }
        public List<Category> SubCategories { get; set; }
    }
}
