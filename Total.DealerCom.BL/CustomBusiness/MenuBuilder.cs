using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Total.DealerCom.Core.ViewModels;
using Total.DealerCom.DataAccessLayer.Facade;
using Total.DealerCom.DataAccessLayer.Facade.Interfaces;


namespace Total.DealerCom.BL.CustomBusiness
{
    public class MenuBuilder
    {
        public static List<Menu> GetMenuData(string userName)
        {
            FacadeFactory facade = new FacadeFactory();

            var ds = facade.GetUserFacade().GetMenuItems(userName, "bkl");
            List<Menu> MenuItems = new List<Menu>();
            List<Menu> finalMenu = new List<Menu>();

            foreach (DataTable table in ds.Tables)
            {
                string[] columnNames = (from dc in table.Columns.Cast<DataColumn>()
                                        select dc.ColumnName).ToArray();

                foreach (DataRow row in table.Rows)
                {
                    Menu itemToAdd = new Menu();
                    var col = (from t in row.ItemArray select t).ToArray();
                    itemToAdd.FunctionId = col[0] == null ? 0 : (int)col[0];
                    itemToAdd.MenuCaption = col[1] == null ? "" : col[1].ToString();
                    itemToAdd.MenuDescription = col[2] == null ? "" : col[2].ToString();
                    itemToAdd.Type = col[5] == null ? 0 : (int)col[5];
                    itemToAdd.ParentFunctionId = string.IsNullOrEmpty(col[3].ToString()) ? 0 : (int)col[3];
                    itemToAdd.URL = col[4].ToString();
                    itemToAdd.MenuSequence = col[6] == null ? 0 : (int)col[6];

                    MenuItems.Add(itemToAdd);
                }

                foreach (var mainMenuItems in MenuItems.Where(t => t.ParentFunctionId == 0))
                {
                    mainMenuItems.MyMenuItems = MenuItems.Where(t => t.ParentFunctionId == mainMenuItems.FunctionId).ToList();
                    finalMenu.Add(mainMenuItems);
                }
                
            }
            return finalMenu;
        }
    }
}
