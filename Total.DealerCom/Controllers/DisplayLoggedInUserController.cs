using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Total.DealerCom.Web.Controllers
{
    public class DisplayLoggedInUserController : Controller
    {
        // GET: DisplayLoggedInUser
        public ActionResult DisplayLoggedInUser()
        {
            return PartialView("Partials/DisplayLoggedInUser");
        }
    }
}