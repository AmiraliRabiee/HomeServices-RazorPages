using App.Domain.Core.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace App.Domain.Core.Helpers
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this StausServiceEnum enumValue)
        {
            var displayAttribute = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>();

            return displayAttribute?.Name ?? enumValue.ToString();
        }
        public static string GetStatusEnumItems(this StausServiceEnum enumValue)
        {
            switch (enumValue)
            {
                case StausServiceEnum.NewlyRegistered:
                    return "ثبت شده"; // "Newly Registered"
                case StausServiceEnum.ExpertSelectionQueue:
                    return "در صف انتخاب متخصص"; // "Expert Selection Queue"
                case StausServiceEnum.WaitingForService:
                    return "در انتظار سرویس"; // "Waiting for Service"
                case StausServiceEnum.Done:
                    return "انجام شده"; // "Done"
                default:
                    return "نامشخص"; // "Unknown"
            }
        }
    }
}
