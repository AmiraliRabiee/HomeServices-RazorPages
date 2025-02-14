using App.Domain.Core.Entites;
using App.Domain.Core.Enum;
using App.Domain.Core.Enums;
using System.ComponentModel.DataAnnotations;

public class Comment
{
    [Key]
    public int Id { get; set; }
    public DateTime CreateAt { get; set; }
    public StausServiceEnum? stausService { get; set; }
    public ExpertRatingEnum? ExpertRating { get; set; }
    public bool IsDeleted { get; set; } = false;


    public int ExpertId { get; set; }

    public Expert Expert { get; set; }
}
