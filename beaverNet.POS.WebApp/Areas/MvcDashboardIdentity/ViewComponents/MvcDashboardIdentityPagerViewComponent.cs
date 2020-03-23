using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using beaverNet.POS.WebApp.Areas.MvcDashboardIdentity.Models;
using beaverNet.POS.WebApp.Areas.MvcDashboardIdentity.Models.ViewComponents;

namespace beaverNet.POS.WebApp.Areas.MvcDashboardIdentity.ViewComponents
{
    public class MvcDashboardIdentityPagerViewComponent : ViewComponent
    {
        #region Construction

        public MvcDashboardIdentityPagerViewComponent()
        { }

        #endregion

        public IViewComponentResult Invoke(DataPage page)
        {
            var model = new MvcDashboardIdentityPagerModel();
            model.DataPage = page;

            return View(model);
        }
    }
}
