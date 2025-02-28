using App.Domain.Core.Enum;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.Entites.User
{
    public class AppUser : IdentityUser<int>
    {
        [MaxLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
        public string? FirstName { get; set; }

        [MaxLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
        public string? LastName { get; set; }
        public bool IsDeleted { get; set; } = false;
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Balance must be a non-negative number.")]
        public float Balance { get; set; }

        public int RoleId { get; set; }
        public ActivationUserEnum? ActivationUser { get; set; } = ActivationUserEnum.Pending;
        public string? ImagePath { get; set; }
        public DateTime? RegisterAt { get; set; }
        public Customer? Customer { get; set; }
        public Expert? Expert { get; set; }
        public Admin? Admin { get; set; }
    }
}