﻿using App.Domain.Core.Enum;

namespace App.Domain.Core.Dto.HomeService
{
    public class SummOrderDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CompletionDate { get; set; }
        public DateTime RunningTime { get; set; }
        public DateTime? CreateAt { get; set; }
        public StausServiceEnum StausService { get; set; }
        public float BasePrice { get; set; }
        public string HouseWork { get; set; }
        public int CustomerId { get; set; }
        public string City { get; set; }
    }
}
