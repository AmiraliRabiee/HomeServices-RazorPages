using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.Entites.User
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public float ProfitPercentage { get; set; } = 0.06f;
    }
}
