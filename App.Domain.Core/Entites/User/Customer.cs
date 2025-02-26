using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.Entites.User
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255, ErrorMessage = "Address cannot exceed 255 characters.")]
        public bool IsDeleted { get; set; } = false;
        public string? Address { get; set; }
        public int CityId { get; set; }
        //public int AppUserId { get; set; }

        public AppUser? User { get; set; }
        public City? City { get; set; }
        public List<Order> Orders { get; set; }

    }
}
