using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.Dto.User
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public IFormFile? ProfileImgFile { get; set; }
        public string? ImagePath { get; set; }
    }
}
