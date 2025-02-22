using App.Domain.Core.Enum;

namespace App.Domain.Core.Dto.HomeService
{
    public class SummSuggestionDto
    {
        public string Description { get; set; }
        public string DeliverDate { get; set; }
        public StausServiceEnum StausService { get; set; }
        public string? City { get; set; }
        public string HouseWork { get; set; }
        public int OrderId { get; set; }
        public string ExpertName { get; set; }
        public TimeOnly RunungTimeOrder { get; set; }
    }
}
