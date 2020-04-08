using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace beaverNet.POS.WebApp.Areas.MvcDashboardIdentity.Controllers
{
    [Area("MvcDashboardIdentity")]
    [Authorize(Roles = "Administrator")]
    //[Authorize]
    public abstract class BaseController : Controller
    {
        protected IActionResult Acknowledge()
        {
            return this.StatusCode(202);
        }

        protected IActionResult DialogClose()
        {
            return this.StatusCode(204);
        }

        protected IActionResult DialogOk(string returnUrl = null)
        {
            if (returnUrl != null) this.Response.Headers["Location"] = returnUrl;
            return this.StatusCode(205);
        }
    }
}
