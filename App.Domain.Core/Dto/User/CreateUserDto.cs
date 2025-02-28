using App.Domain.Core.Enum;
using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.Dto.User
{
    public class CreateUserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string? Address { get; set; }
        public int RoleId { get; set; }
        public IFormFile? ProfileImgFile { get; set; }
        public string? ImagePath { get; set; }
        public int CityId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }

    }
}
