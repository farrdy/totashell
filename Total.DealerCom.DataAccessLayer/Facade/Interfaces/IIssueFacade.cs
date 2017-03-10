using System.Collections.Generic;
using System.Web.UI.WebControls;
using Total.DealerCom.Core;

namespace Total.DealerCom.DataAccessLayer.Facade.Interfaces
{
    public interface IIssueFacade
    {
        void PopulateGroupList(ref DropDownList dropDownList);
        string ReturnGroupId(string groupName);
        IEnumerable<IssueResult> Search(Issue issue);
        IEnumerable<IssueResult> Report(Issue issue);

        void Delete(string groups);
        string Edit(IssueResult log);

        IssueResult GetInstance(string id);

        void PopulateDealerUserList(ref DropDownList dropDownList);
        void PopulateTankList(ref DropDownList dropDownList);
        void PopulateSOCList(ref DropDownList dropDownList);
        void PopulateProductList(ref DropDownList dropDownList);
        void PopulateRequestStatusList(ref DropDownList dropDownList);
        void PopulateIssueTypeList(ref DropDownList dropDownList);
    }
}
