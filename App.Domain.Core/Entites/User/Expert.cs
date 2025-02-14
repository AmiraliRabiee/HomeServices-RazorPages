using App.Domain.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.Entites
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


        public List<Comment>? Comments { get; set; }
        public List<Suggestion>? Suggestions { get; set; }
        public List<Order> AcceptedOrders { get; set; }
        public List<HouseWork> Skills { get; set; }
    }
}
