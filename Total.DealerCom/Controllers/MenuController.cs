using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Total.DealerCom.Core;
using Total.DealerCom.DataAccessLayer;
using Total.DealerCom.DataAccessLayer.Facade.Interfaces;
using Total.DealerCom.Web.Models;
using System.Data.Sql;
using System.Data;
using Total.DealerCom.BL.CustomBusiness;

namespace Total.DealerCom.Web.Controllers
{
    [Authorize]
    public class MenuController : BaseController
    {
        // GET: Menu
        public ActionResult MainMenu()
        {
            return PartialView("Menu/MainMenu", MenuBuilder.GetMenuData(Session[Constants.UserID].ToString()));
        }
    }
}