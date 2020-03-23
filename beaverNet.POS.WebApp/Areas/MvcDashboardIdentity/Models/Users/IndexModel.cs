using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace beaverNet.POS.WebApp.Areas.MvcDashboardIdentity.Models.Users
{
    public class IndexModel
    {
        public DataPage<IdentityUser> DataPage { get; set; }
    }
}
