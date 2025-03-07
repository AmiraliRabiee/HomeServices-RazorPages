using App.Domain.Core.Entites.Service;
using App.Domain.Core.Enum;

namespace App.Domain.Core.Dto.HomeService
{
    public class SummSuggestionDto
    {
        public int Id { get; set; }
        public int ExpertId { get; set; }
        public string Description { get; set; }
        public StausServiceEnum StausService { get; set; }
        public string? City { get; set; }
        public string HouseWork { get; set; }
        public int HouseWorkId { get; set; }
        public string ExpertName { get; set; }
        public TimeOnly RunungTimeOrder { get; set; }
        public string CompletionDate { get; set; }
        public string CategoryName { get; set; }
        public string ParentCategoryName { get; set; }
        public int OrderId { get; set; }
        public bool IsAccepted { get; set; }

        public float SuggestPrice { get; set; }
        public string CustomerAddress { get; set; }
        public List<ExpertHouseWork>? ExpertHouseWorks { get; set; }
    }
}
