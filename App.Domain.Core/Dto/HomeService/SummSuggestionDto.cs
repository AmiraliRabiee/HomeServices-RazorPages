using App.Domain.Core.Enums;

namespace App.Domain.Core.Dto.HomeService
{
    public class SummSuggestionDto
    {
        public string Description { get; set; }
        public float SuggestPrice { get; set; }
        public DateTime DeliverDate { get; set; }
        public StausServiceEnum StausService { get; set; }
        public string City { get; set; }
        public string HouseWork { get; set; }
        public string Order { get; set; }
        public int ExpertId { get; set; }
    }
}
