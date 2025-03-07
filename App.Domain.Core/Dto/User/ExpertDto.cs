
using App.Domain.Core.Entites.Service;

namespace App.Domain.Core.Dto.User
{
    public class ExpertDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public List<ExpertHouseWork> Skills { get; set; }
        public string Biographi { get; set; }
        public string RoleName { get; set; }
        public string ExpertName { get; set; }
    }
}
