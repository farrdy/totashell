using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Total.DealerCom.DataAccessLayer.DataAccess;
using System.Web.Mvc;

namespace Total.DealerCom.BL.StandingDryLogs
{
    public class StandingDrySearchLists
    {
        public List<System.Web.Mvc.SelectListItem> PopulateSOCList()
        {
            var list = IssueDao.GetSOCList();

            var query = (from i in list
                         select new SelectListItem
                         {
                             Text = i.Key.ToString(),
                             Value = i.Value
                         }).ToList();
            return query;
        }

        public List<System.Web.Mvc.SelectListItem> PopulateProductList()
        {

            var list = IssueDao.GetProductList();

            var query = (from i in list
                         select new SelectListItem
                         {
                             Text = i.Key.ToString(),
                             Value = i.Value
                         }).ToList();
            return query;


        }
        public List<System.Web.Mvc.SelectListItem> PopulateRequestStatusList()
        {

            var list = IssueDao.GetRequestStatusList();

            var query = (from i in list
                         select new SelectListItem
                         {
                             Text = i.Key.ToString(),
                             Value = i.Value
                         }).ToList();
            return query;

        }

        public List<System.Web.Mvc.SelectListItem> PopulateTankList()
        {

            var list = IssueDao.GetTankList();

            var query = (from i in list
                         select new SelectListItem
                         {
                             Text = i.Key.ToString(),
                             Value = i.Value
                         }).ToList();
            return query;

        }


        public List<System.Web.Mvc.SelectListItem> PopulateDealerUserList()
        {
            var list = IssueDao.GetDealerUserList();

            var query = (from i in list
                         select new SelectListItem
                         {
                             Text = i.UserName,
                             Value = i.Id
                         }).ToList();
            return query;

        }





    }
}
