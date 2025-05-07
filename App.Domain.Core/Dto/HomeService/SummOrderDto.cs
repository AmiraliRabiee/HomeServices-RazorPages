using App.Domain.Core.Entites.User;
using App.Domain.Core.Enum;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace App.Domain.Core.Dto.HomeService
{
    public class SummOrderDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime CompletionDate { get; set; }
        public TimeOnly RunningTime { get; set; }
        public StausServiceEnum StausService { get; set; }
        public string HouseWork { get; set; }
        public int CustomerId { get; set; }
        public float BasePrice { get; set; }
        public float SuggestPrice { get; set; }
        public string CityName { get; set; }
        public string ImagePath { get; set; }
        public int HouseWorkId { get; set; }
        public string ExpertName { get; set; }
        public DateTime CreationDate { get; set; }
        public string CustomerName { get; set; }
        public bool? IsConfrim { get; set; }
        public string Address { get; set; }
        public List<IFormFile>? Images { get; set; }
        public string ImagePathOfOrder { get; set; }
        public List<Image> UploadImages { get; set; }
    }
}
