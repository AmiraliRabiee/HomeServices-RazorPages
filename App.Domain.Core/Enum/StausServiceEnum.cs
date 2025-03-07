using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.Enum
{
    public enum StausServiceEnum
    {
        [Display(Name = "در انتظار پینشهاد متخصصان")]
        NewlyRegistered = 1,
        [Display(Name = " در انتظار انتخاب متخصص")]
        ExpertSelectionQueue,
        [Display(Name = "تایید برای حضور در محل")]
        WaitingForService,
        [Display(Name = "انجام شده")]
        Done,
        [Display(Name = "پرداخت شده")]
        Payment
    }
}
