using App.Domain.Core.Enum;

namespace App.Domain.Core.Dto.HomeService
{
    public class SummOrderDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime CompletionDate { get; set; }
        public TimeOnly RunningTime { get; set; }
        public DateTime? CreateAt { get; set; }
        public StausServiceEnum StausService { get; set; }
        public string HouseWork { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string City { get; set; }
    }
}
