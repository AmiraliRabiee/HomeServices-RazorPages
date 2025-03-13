using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.Dto.HomeService
{
    public class UpdateHouseWork
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? SubCategory { get; set; }
        public int? SubCategoryId { get; set; }
        public float BasePrice { get; set; }
        public string? ImagePath { get; set; }
        public IFormFile? ServiceImage { get; set; }
        public int? ViewCount { get; set; }
    }
}
