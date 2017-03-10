using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Total.DealerCom.Core.ViewModels
{
    public class Menu
    {
        public int FunctionId { get; set; }
        public string URL { get; set; }
        public List<Menu> MyMenuItems { get; set; }
        public string MenuCaption { get; set; }
        public string MenuDescription { get; set; }
        public int Type { get; set; }
        public int MenuSequence { get; set; }
        public int ParentFunctionId { get; set; }

    }
}