using App.Domain.Core.Entites;
using System.ComponentModel.DataAnnotations;

public class Suggestion
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    [MaxLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
    public string Description { get; set; }

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Suggested price must be a non-negative number.")]
    public float SuggestPrice { get; set; }
    public DateTime DeliverDate { get; set; }

    public int CityId { get; set; }
    public int HomeServiceId { get; set; }
    public int OrderId { get; set; }
    public int ExpertId { get; set; }

    public Expert Expert { get; set; }
    public Order Order { get; set; }
    public HomeService HomeService { get; set; }
    public City City { get; set; }
}
