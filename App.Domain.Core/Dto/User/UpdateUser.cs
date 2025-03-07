using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.Dto.User
{
    public class UpdateUser
    {
        public int? Id { get; set; }
        public IFormFile? ProfileImage { get; set; }
        public string? ImagePath { get; set; }
    }
}
