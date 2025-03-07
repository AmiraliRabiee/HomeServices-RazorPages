using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Helpers
{
    public static class UserTools
    {
        public static string GetName(IEnumerable<Claim> claims)
        {
            return claims.FirstOrDefault(x => x.Type == "FirstName").Value;
        }

        public static int GetCustomerId(IEnumerable<Claim> claims)
        {
            return int.Parse(claims.FirstOrDefault(c => c.Type == "CustomerId").Value);
        }
    }
}
