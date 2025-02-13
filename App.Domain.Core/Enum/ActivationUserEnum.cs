using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.Enum
{
    public enum ActivationUserEnum
    {
        [Display(Name ="فعال")]
        Active = 1,
        [Display(Name = "غیرفعال")]
        InActive,
        [Display(Name = "در انتظار")]
        Pending
    }
}
