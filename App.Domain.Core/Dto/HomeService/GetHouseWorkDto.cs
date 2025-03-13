using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.Dto.HomeService
{
    public class GetHouseWorkDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CategoryName { get; set; }
    }
}
