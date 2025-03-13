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
        public DateTime CompletionDate { get; set; }
        public string CategoryName { get; set; }
        public string ParentCategoryName { get; set; }
        public int OrderId { get; set; }
        public bool IsAccepted { get; set; }
        public string CityName { get; set; }
        public string CustomerName { get; set; }
        public int CusomerId { get; set; }
        public string CustomerImagePath { get; set; }
        public string ImagePath { get; set; }
        public float SuggestPrice { get; set; }
        public string CustomerAddress { get; set; }
        public List<ExpertHouseWork>? ExpertHouseWorks { get; set; }
    }
}
