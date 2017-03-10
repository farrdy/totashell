using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Infrastructure.Server.DataAccess;
using Services.DTO;

namespace Services.DataAccess
{
    internal class GroupDao
    {

        public static IEnumerable<Group> GetGroupList()
        {
            var dataTable = DataFacade.GetDataTable("GroupList",
                                                    new ParameterValue[0]);

            return (from DataRow r in dataTable.Rows
                    select new Group
                        {
                            GroupName = r["GroupName"].ToString(),
                            IdGroup = r["IdGroup"].ToString(),
                            SpecialGroup = r["SpecialGroup"].ToString()
                        }).ToList();
        }

        public static void GroupDelete(string group)
        {
            DataFacade.ExecuteNonQuery("GroupDelete",
                                       new ParameterValue("idGroups", group));
        }

        public static void GroupMemberInsert(string idgroup, string idmembers)
        {
            DataFacade.ExecuteNonQuery("GroupMemberInsert",
                                       new ParameterValue("idGroup", idgroup),
                                       new ParameterValue("idMembers", idmembers)
                );
        }

        public static void GroupMemberDelete(string idgroup, string idmembers)
        {
            DataFacade.ExecuteNonQuery("GroupMemberDelete",
                                       new ParameterValue("idGroup", idgroup),
                                       new ParameterValue("idMembers", idmembers)
                );
        }

        public static string ReturnGroupId(string groupName)
        {
            IEnumerable<Group> groupList = GetGroupList();
            foreach (Group g in groupList)
            {
                if (g.GroupName == groupName)
                {
                    return g.IdGroup;
                }
            }
            return string.Empty;
        }

        public static IEnumerable<User> GetGroupMembersIncluded(string idgroup)
        {
            var dataTable = DataFacade.GetDataTable("GroupMemberLoad",
                                                    new ParameterValue("idGroup", idgroup));

            return (from DataRow r in dataTable.Rows
                    select new User
                        {
                            Id = r["UserID"].ToString(),
                            UserName = r["Name"].ToString(),
                            Email = r["Email"].ToString(),
                            Password = r["Password"].ToString(),
                            Active = Convert.ToBoolean(r["Active"].ToString()),
                            PasswordChange = Convert.ToBoolean(r["PasswordChangeRequired"].ToString()),
                            IDRegion = r["idRegion"].ToString(),
                            IDSalesArea = r["idSalesArea"].ToString()
                        }).ToList();
        }

        public static IEnumerable<User> GetGroupMembersNotIncluded(string idgroup)
        {
            var dataTable = DataFacade.GetDataTable("GroupMemberLoadNot",
                                                    new ParameterValue("idGroup", idgroup));

            return (from DataRow r in dataTable.Rows
                    select new User
                        {
                            Id = r["UserID"].ToString(),
                            UserName = r["Name"].ToString(),
                            Email = r["Email"].ToString(),
                            Password = r["Password"].ToString(),
                            Active = Convert.ToBoolean(r["Active"].ToString()),
                            PasswordChange = Convert.ToBoolean(r["PasswordChangeRequired"].ToString()),
                            IDRegion = r["idRegion"].ToString(),
                            IDSalesArea = r["idSalesArea"].ToString()
                        }).ToList();
        }

        public static string Edit(string idGroup, string groupName)
        {
            DataRow dataRow = DataFacade.GetDataRow("GroupEdit",
                                                    new ParameterValue("idGroup", idGroup),
                                                    new ParameterValue("GroupName", groupName));

            if (dataRow["idGroup"] != null) return dataRow["idGroup"].ToString();

            return string.Empty;
        }


        public static IEnumerable<Group> Search(Group group)
        {
            var dataTable = DataFacade.GetDataTable("GroupSearch",
                                                    new ParameterValue("GroupName", group.GroupName),
                                                    new ParameterValue("MemberID", group.MemberId),
                                                    new ParameterValue("MemberName", group.MemberName));

            return (from DataRow r in dataTable.Rows
                    select new Group
                        {
                            GroupName = r["GroupName"].ToString(),
                            IdGroup = r["idGroup"].ToString(),
                            SpecialGroup = r["SpecialGroup"].ToString()
                        }).ToList();
        }

        public static void LogArticleView(Article article)
        {
            DataFacade.ExecuteNonQuery("LogAccessInsert",
                                       new ParameterValue("UserID", article.UserId),
                                       new ParameterValue("idArticle", article.IdArticle));
        }
    }
}
