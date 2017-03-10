
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Total.DealerCom.Core;

namespace Total.DealerCom.DataAccessLayer.Facade.Interfaces
{
        public interface IGroupFacade
        {
            void PopulateGroupList(ref DropDownList dropDownList);
            string ReturnGroupId(string groupName);
            IEnumerable<Group> Search(Group group);
            void Delete(string groups);

            IEnumerable<User> GetGroupMembersIncluded(string idgroup);
            IEnumerable<User> GetGroupMembersNotIncluded(string idgroup);

            void GroupMemberInsert(string idgroup, string idmembers);
            void GroupMemberDelete(string idgroup, string idmembers);
            string Edit(string idGroup, string groupName);
        }
}
