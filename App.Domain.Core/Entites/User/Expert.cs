using App.Domain.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.Entites
{
    public class Expert
    {
        [Key]
        public int Id { get; set; }
        public int? Points { get; set; }
        [MaxLength(2000, ErrorMessage = "Biography cannot exceed 2000 characters.")]
        public string? Biographi { get; set; }


        public List<Comment>? Comments { get; set; }
        public List<Suggestion>? Suggestions { get; set; }
        public List<Order> AcceptedOrders { get; set; }
        public List<HomeService> Skills { get; set; }
    }
}
