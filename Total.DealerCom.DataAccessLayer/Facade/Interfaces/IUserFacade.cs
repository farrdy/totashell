using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Infrastructure.Shared.Security;
using Total.DealerCom.Core;

namespace Total.DealerCom.DataAccessLayer.Facade.Interfaces
{
    public interface IUserFacade
    {
        SecurityUser Authenticate(string userName, string password);

        IEnumerable<User> Search(User user);

        IEnumerable<DealerAccountInfo> GetDealerAccountInfo(string userName);

        List<string> PopulateRoleList(ref DropDownList dropDownList);

        SecurityUser UserLoginAs(string userID);

        DataRow UpdatePassword(User user);

        void Update(User user);

        void Add(ref User user);

        void Delete(string users);

        void Activate(string users);

        void Deactivate(string users);

        string ValidateUniqueLogon(User user);

        string ValidateUniquePassword(string password);

        string ResetPassword(User user);

        string SendUserPassword(string newPassword, User user);

        User Read(string id);

        void Delete(int id);

        string GetMenuItems(string userId);
        DataSet GetMenuItems(string userId, string bla);

        string GetDryStockMenuXml(string userId);
    }
}