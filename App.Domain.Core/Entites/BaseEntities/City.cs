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

}
