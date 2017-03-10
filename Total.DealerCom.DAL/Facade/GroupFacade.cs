
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Services.DataAccess;
using Services.DTO;
using Services.Facade.Interfaces;

namespace Services.Facade
{
    class GroupFacade : IGroupFacade
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

        public  IEnumerable<User> GetGroupMembersIncluded(string idgroup)
        {
            return GroupDao.GetGroupMembersIncluded(idgroup);
        }

        public  IEnumerable<User> GetGroupMembersNotIncluded(string idgroup)
        {
            return GroupDao.GetGroupMembersNotIncluded(idgroup);
        }

        public void GroupMemberInsert(string idgroup, string idmembers)
        {
            GroupDao.GroupMemberInsert(idgroup, idmembers);
        }

        public string Edit(string idGroup, string groupName)
        {
            return GroupDao.Edit(idGroup, groupName);
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

        public IEnumerable<Group> Search(Group group)
        {
            return GroupDao.Search(group);
        }

    }
}
