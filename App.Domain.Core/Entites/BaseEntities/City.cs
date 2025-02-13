using App.Domain.Core.Entites;
using App.Domain.Core.Entites.User;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

public class City
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(100, ErrorMessage = "Biography cannot exceed 100 characters.")]
    public string Name { get; set; }

    public List<Order> Orders { get; set; }
    public List<Suggestion> Suggestions { get; set; }
}
