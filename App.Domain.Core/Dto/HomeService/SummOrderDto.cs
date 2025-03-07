using App.Domain.Core.Enum;
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
        public decimal? BasePrice { get; set; }
        public string CityName { get; set; }
        public string ImagePath { get; set; }
        public int HouseWorkId { get; set; }
        public string ExpertName { get; set; }
        public int SuggestionId { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
