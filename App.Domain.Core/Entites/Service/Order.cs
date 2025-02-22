using App.Domain.Core.Entites.Service;
using App.Domain.Core.Entites.User;
using App.Domain.Core.Enum;
using System.ComponentModel.DataAnnotations;

public class Order
{
    [Key]
    public int Id { get; set; }
    [MaxLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
    public string? Description { get; set; }
    //تاریخ اجرا
    public DateTime CompletionDate { get; set; }
    // ساعت اجرا
    public TimeOnly RunningTime { get; set; }
    public DateTime? CreateAt { get; set; }
    public StausServiceEnum StausService { get; set; }
    public bool IsDeleted { get; set; } = false;
    public bool? IsConfrim { get; set; }
    public bool? IsFinish { get; set; }

    public int HouseWorkId { get; set; }
    public int CustomerId { get; set; }
    public int? ExpertId { get; set; }

    public HouseWork HouseWork { get; set; }
    public Customer Customer { get; set; }
    public Expert? Expert { get; set; }
    public List<Suggestion>? Suggestions { get; set; }
}
