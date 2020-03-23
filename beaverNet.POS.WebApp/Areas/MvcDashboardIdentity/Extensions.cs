using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace beaverNet.POS.WebApp.Areas.MvcDashboardIdentity
{
    public static class Extensions
    {
        public static T[] Page<T>(this IQueryable<T> query, int page, int pageSize)
        {
            return query.Skip((page - 1) * pageSize).Take(pageSize).ToArray();
        }

        public static bool IsLockedout(this IdentityUser user)
        {
            return (user.LockoutEnd.HasValue && user.LockoutEnd > DateTime.UtcNow);
        }
    }
}
