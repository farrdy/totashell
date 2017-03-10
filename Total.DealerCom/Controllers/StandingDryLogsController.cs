using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Total.DealerCom.Web.Http;

using Total.DealerCom.Core;

namespace Total.DealerCom.Web.Controllers
{
    public class StandingDryLogsController : Controller
    {
        // GET: StandingDryLogs
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IssueReport() {

            return View();
        }

        public ActionResult EditIssue()
        {
            return PartialView("EditIssue");
        }


        public ActionResult Edit(int id)
        {
            var model = new StandingDryLogController().GetIssueInstance(id.ToString());
            ViewBag.Tanks = new StandingDryLogController().GetIssueLists().Tanklist.
                Select(x => new SelectListItem
                {
                    Value = x.Text,
                    Text = x.Value

                });
            ViewBag.ProductList = new StandingDryLogController().GetIssueLists().ProductList.Select(x => new SelectListItem
            {
                Value = x.Text,
                Text = x.Value
            });
            ViewBag.RequestStatuslist = new StandingDryLogController().GetIssueLists().RequestStatuslist.Select(x => new SelectListItem
            {

                Value = x.Text,
                Text = x.Value

            });
            ViewBag.SocList = new StandingDryLogController().GetIssueLists().Soclist.Select(x => new SelectListItem
            {
                Value = x.Text,
                Text = x.Value

            });

            if (model != null)
            {
                return View("Edit", model);
            }
            else
                return RedirectToAction("IssueReport");
        }
    }
}