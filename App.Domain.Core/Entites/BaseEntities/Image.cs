using App.Domain.Core.Entites.Service;
using System.ComponentModel.DataAnnotations;

public class Image
{
    [Key]
    public int Id { get; set; }
    [MaxLength(500, ErrorMessage = "Image path cannot exceed 500 characters.")]
    public string? Path { get; set; }

    public HouseWork HouseWork { get; set; }
    public int HouseWorkId { get; set; }
}
