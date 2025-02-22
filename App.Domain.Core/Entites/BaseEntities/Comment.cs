using App.Domain.Core.Entites.User;
using App.Domain.Core.Enum;
using System.ComponentModel.DataAnnotations;

public class Comment
{
    [Key]
    public int Id { get; set; }
    public string Opinion { get; set; }
    public DateTime CreateAt { get; set; }
    [Range(1, 10, ErrorMessage = ".امتیاز باید بین 1 تا 10 باشد")]
    public int? Points { get; set; }
    public StausServiceEnum? stausService { get; set; }
    public ExpertRatingEnum? ExpertRating { get; set; }
    public bool IsDeleted { get; set; } = false;
    public bool IsPlayable { get; set; } = false;


    public int ExpertId { get; set; }

    public Expert Expert { get; set; }
}
