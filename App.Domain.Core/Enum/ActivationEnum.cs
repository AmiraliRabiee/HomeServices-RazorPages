using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.Enum
{
    public enum ActivationEnum
    {
        [Display(Name ="فعال")]
        Active = 1,
        [Display(Name = "غیرفعال")]
        InActive,
        [Display(Name = "در انتظار")]
        Pending
    }
}
