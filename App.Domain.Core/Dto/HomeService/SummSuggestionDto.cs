namespace App.Domain.Core.Dto.HomeService
{
    public class SummSuggestionDto
    {
        public string Description { get; set; }
        public float SuggestPrice { get; set; }
        public DateTime DeliverDate { get; set; }
        public int CityId { get; set; }
        public int HomeServiceId { get; set; }
        public int OrderId { get; set; }
        public int ExpertId { get; set; }
    }
}
