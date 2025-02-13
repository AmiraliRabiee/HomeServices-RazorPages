using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.Enum
{
    public enum ExpertRatingEnum
    {
        [Display(Name = "عالی")]
        great = 1,
        [Display(Name = "خوب")]
        good,
        [Display(Name = "متوسط")]
        middle,
        [Display(Name = "ضعیف")]
        Weak
    }
}
