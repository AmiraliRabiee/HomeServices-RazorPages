using App.Domain.Core.Entites.User;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

public class City
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }

    //public List<Customer>? Customers { get; set; }
    //public List<Expert>? Experts { get; set; }
}
