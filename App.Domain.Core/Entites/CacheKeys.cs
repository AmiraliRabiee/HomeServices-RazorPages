using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entites
{
    public static class CacheKeys
    {
        // ✅ Category
        public static string AllCategories => "CategoryService:GetAllCategories";

        // ✅ Work
        public static string AllWorks => "WorkService:GetAllWorks";

        // ✅ Order
        public static string AllOrders => "OrderService:GetAllOrders";
    }

}
