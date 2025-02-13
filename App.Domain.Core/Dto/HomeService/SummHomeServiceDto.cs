using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.Dto.HomeService
{
    public class SummHomeServiceDto
    {
        public string Tiltle { get; set; }
        public string Description { get; set; }
        public int SubCategoryId { get; set; }
        public int? CustomerId { get; set; }
        public decimal BasePrice { get; set; }
        public string ImagePath { get; set; }
        //public List<IFormFile>? Images { get; set; }

    }
}
