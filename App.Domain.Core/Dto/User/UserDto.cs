using App.Domain.Core.Enum;
using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.Dto.User
{
    public class UserDto
    {
        public int? Id { get; set; }
        public string? FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public float Balance { get; set; }
        public int CityId { get; set; }
        public string? Address { get; set; }
        public City City { get; set; }
        public int RoleId { get; set; }
        public List<Order> Orders { get; set; }
        public List<Suggestion> Suggestions { get; set; }
        public string? ImagePath { get; set; }
    }
}
