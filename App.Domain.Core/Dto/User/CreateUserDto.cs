using App.Domain.Core.Enum;
using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.Dto.User
{
    public class CreateUserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? RePassword { get; set; }
        public string? Address { get; set; }
        public RoleEnum Role { get; set; }
        public int RoleId { get; set; }
        public IFormFile? ProfileImgFile { get; set; }
        public string? ImagePath { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
    }
}
