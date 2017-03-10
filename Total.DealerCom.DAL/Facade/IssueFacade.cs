
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Services.DataAccess;
using Services.DTO;
using Services.Facade.Interfaces;

namespace Services.Facade
{
    class IssueFacade : IIssueFacade
    {
        public void PopulateGroupList(ref DropDownList dropDownList)
        {
            dropDownList.Items.Clear();
            var groupList = GroupDao.GetGroupList();

            dropDownList.Items.Add(new ListItem("All", "0"));
            foreach (var g in groupList)
            {
                dropDownList.Items.Add(new ListItem(g.GroupName, g.IdGroup));
            }
        }

        public void PopulateDealerUserList(ref DropDownList dropDownList)
        {
            dropDownList.Items.Clear();
            var groupList = IssueDao.GetDealerUserList();

            dropDownList.Items.Add(new ListItem(string.Empty, "0"));
            foreach (var g in groupList)
            {
                dropDownList.Items.Add(new ListItem(g.UserName, g.Id));
            }
        }

        public IssueResult GetInstance(string id)
        {
            return IssueDao.GetInstance(id);
        }

        public void PopulateTankList(ref DropDownList dropDownList)
        {
            dropDownList.Items.Clear();
            var groupList = IssueDao.GetTankList();

            dropDownList.Items.Add(new ListItem(string.Empty, "0"));
            foreach (var g in groupList)
            {
                dropDownList.Items.Add(new ListItem(g.Value, g.Key.ToString()));
            }
        }

        public void PopulateIssueTypeList(ref DropDownList dropDownList)
        {
            dropDownList.Items.Clear();
            var groupList = IssueDao.GetIssueTypeList();

            dropDownList.Items.Add(new ListItem(string.Empty, "0"));
            foreach (var g in groupList)
            {
                dropDownList.Items.Add(new ListItem(g.Value, g.Key.ToString()));
            }
        }

        public string Edit(IssueResult log)
        {
            return IssueDao.Edit(log);
        }

        public void PopulateSOCList(ref DropDownList dropDownList)
        {
            dropDownList.Items.Clear();
            var groupList = IssueDao.GetSOCList();

            dropDownList.Items.Add(new ListItem(string.Empty, "0"));
            foreach (var g in groupList)
            {
                dropDownList.Items.Add(new ListItem(g.Value, g.Key.ToString()));
            }
        }

        public void PopulateProductList(ref DropDownList dropDownList)
        {
            dropDownList.Items.Clear();
            var groupList = IssueDao.GetProductList();

            dropDownList.Items.Add(new ListItem(string.Empty, "0"));
            foreach (var g in groupList)
            {
                dropDownList.Items.Add(new ListItem(g.Value, g.Key.ToString()));
            }
        }

        public void PopulateRequestStatusList(ref DropDownList dropDownList)
        {
            dropDownList.Items.Clear();
            var groupList = IssueDao.GetRequestStatusList();

            dropDownList.Items.Add(new ListItem(string.Empty, "0"));
            foreach (var g in groupList)
            {
                dropDownList.Items.Add(new ListItem(g.Value, g.Key.ToString()));
            }
        }

        public void GroupMemberDelete(string idgroup, string idmembers)
        {
            GroupDao.GroupMemberDelete(idgroup, idmembers);
        }

        public string ReturnGroupId(string groupName)
        {
            return GroupDao.ReturnGroupId(groupName);
        }

        public void Delete(string groups)
        {
            GroupDao.GroupDelete(groups);
        }


        public IEnumerable<IssueResult> Search(Issue group)
        {
            return IssueDao.Search(group);
        }

        public IEnumerable<IssueResult> Report(Issue group)
        {
            return IssueDao.Report(group);
        }

    }
}
