using App.Domain.Core.Entites.User;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

public class City
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }

    public List<Order> Orders { get; set; }
    public List<Expert>? Experts { get; set; }
}
