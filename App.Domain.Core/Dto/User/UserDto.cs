using App.Domain.Core.Entites.User;
using App.Domain.Core.Enum;
using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.Dto.User
{
    public class UserDto
    {
        public int? Id { get; set; }
        public Customer Customer { get; set; }
        public Expert Expert { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public IFormFile? ProfileImgFile { get; set; }
        public string? FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public float Balance { get; set; }
        public int CityId { get; set; }
        public string? Address { get; set; }
        public City City { get; set; }
        public List<Order> Orders { get; set; }
        public List<Suggestion> Suggestions { get; set; }
        public string? ImagePath { get; set; }
    }
}
