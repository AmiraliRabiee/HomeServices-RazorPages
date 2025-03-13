using App.Domain.Core.Entites.Service;
using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.Dto.Dashboard
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public IFormFile? CategoryImage { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public string? ParentName { get; set; }
        public string? ImagePath { get; set; }
        public string? HouseWorkName { get; set; }
        public string? ChildName { get; set; }
        public int? CategoryId { get; set; }
    }
}
