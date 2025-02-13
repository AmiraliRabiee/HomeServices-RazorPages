using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.Entites.User
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public List<Order> Orders { get; set; }
        //If needed
        //public List<Suggestion>? SuggestionsReceived { get; set; }
    }
}
