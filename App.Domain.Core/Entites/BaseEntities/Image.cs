using App.Domain.Core.Entites;
using System.ComponentModel.DataAnnotations;

public class Image
{
    [Key]
    public int Id { get; set; }
    [MaxLength(500, ErrorMessage = "Image path cannot exceed 500 characters.")]
    public string? Path { get; set; }

    public HomeService HomeService { get; set; }
    public int HomeServiceId { get; set; }
}
