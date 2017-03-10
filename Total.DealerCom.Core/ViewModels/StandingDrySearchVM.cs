using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Total.DealerCom.Core.ViewModels
{
    public class StandingDrySearchVM
    {
        public List<System.Web.Mvc.SelectListItem> ProductList { get; set; }
        public List<System.Web.Mvc.SelectListItem> Soclist { get; set; }      
        public List<System.Web.Mvc.SelectListItem> RequestStatuslist { get; set; }
        public List<System.Web.Mvc.SelectListItem> Tanklist { get; set; }
        public List<System.Web.Mvc.SelectListItem> DealerUserList { get; set; }
    }
}
