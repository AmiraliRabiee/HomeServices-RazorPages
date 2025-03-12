
using App.Domain.Core.Entites.Service;
using App.Domain.Core.Entites.User;
using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.Dto.User
{
    public class ExpertDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public List<ExpertHouseWork> Skills { get; set; }
        public string Biographi { get; set; }
        public string ImagePath { get; set; }
        public IFormFile ExpertImage { get; set; }
        public float Balance { get; set; }
        public string PhoneNumber { get; set; }
        public List<int> SelectedHouseWorkIds { get; set; } = new();
        public AppUser AppUser { get; set; }
    }
}
