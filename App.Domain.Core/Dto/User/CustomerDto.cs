using App.Domain.Core.Entites.User;
using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.Dto.User
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public IFormFile? CustomerImage { get; set; }
        public string? ImagePath { get; set; }
        public string CityName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public float Balance { get; set; }
        public AppUser User { get; set; }
    }
}
