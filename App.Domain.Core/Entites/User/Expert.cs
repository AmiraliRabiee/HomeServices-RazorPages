using App.Domain.Core.Entites.Service;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.Entites.User
{
    public class Expert
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255, ErrorMessage = "Address cannot exceed 255 characters.")]
        public string? Address { get; set; }
        public int? Points { get; set; }
        [MaxLength(2000, ErrorMessage = "Biography cannot exceed 2000 characters.")]
        public string? Biographi { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int CityId { get; set; }


        public List<Comment>? Comments { get; set; }
        public List<Suggestion>? Suggestions { get; set; }
        public List<HouseWork> Skills { get; set; }
        public City City { get; set; }
    }
}
