using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Infrastructure.Server.DataAccess;
using Total.DealerCom.Core;

namespace Total.DealerCom.DataAccessLayer.DataAccess
{
    public class GeneralChangesDao
    {
        public static IEnumerable<GeneralChangesItemGroup> GetGeneralChangesGroups()
        {
            var dataSet = DataFacade.GetDataSet("GeneralChangesGroupsGet", new ParameterValue[0]);

            var returnList = new List<GeneralChangesItemGroup>();
            foreach (
                var groupItem in
                    dataSet.Tables["Table"].Rows.Cast<DataRow>().Select(@group => new GeneralChangesItemGroup
                    {
                        Active = (bool)@group["Active"],
                        GroupName = @group["GroupName"].ToString(),
                        Id = (int)@group["Id"],
                        SortOrder = (int)@group["SortOrder"],
                        MinSelectionCount = (byte)@group["MinSelectionCount"],
                        MaxSelectionCount = (byte)@group["MaxSelectionCount"],
                        Approvable = (bool)@group["Approvable"]
                    }))
            {
                groupItem.GeneralChangesItems =
                    dataSet.Tables["Table1"].Rows.Cast<DataRow>().Where(
                        x => (int)x["GeneralChangesItemGroupId"] == groupItem.Id).Select(row => new GeneralChangesItem
                        {
                            Active = (bool)row["Active"],
                            GeneralChangesItemGroup = groupItem,
                            Id = (int)row["Id"],
                            ItemName = row["ItemName"].ToString(),
                            SortOrder = (int)row["SortOrder"]
                        }).ToList();

                returnList.Add(groupItem);
            }

            return returnList;
        }

        public static GeneralChangesItemGroup SaveGeneralChangesItemGroup(GeneralChangesItemGroup group)
        {
            DataRow dr;

            if (group.Id > 0)
            {
                dr = DataFacade.GetDataRow("GeneralChangesItemGroupUpdate",
                                           new ParameterValue("Id", group.Id),
                                           new ParameterValue("GroupName", group.GroupName),
                                           new ParameterValue("Active", group.Active),
                                           new ParameterValue("SortOrder", group.SortOrder),
                                           new ParameterValue("MaxSelectionCount", group.MaxSelectionCount),
                                           new ParameterValue("MinSelectionCount", group.MinSelectionCount),
                                           new ParameterValue("Approvable", group.Approvable)
                    );
            }
            else
            {
                dr = DataFacade.GetDataRow("GeneralChangesItemGroupCreate",
                                           new ParameterValue("GroupName", group.GroupName),
                                           new ParameterValue("Active", group.Active),
                                           new ParameterValue("SortOrder", group.SortOrder),
                                           new ParameterValue("MaxSelectionCount", group.MaxSelectionCount),
                                           new ParameterValue("MinSelectionCount", group.MinSelectionCount),
                                           new ParameterValue("Approvable", group.Approvable)
                    );
            }

            return GetGeneralChangesGroups().FirstOrDefault(x => x.Id == Convert.ToInt32(dr["Id"]));
        }

        public static GeneralChangesItem SaveGeneralChangesItem(GeneralChangesItem item)
        {
            DataRow dr;

            if (item.Id > 0)
            {
                dr = DataFacade.GetDataRow("GeneralChangesItemUpdate",
                                           new ParameterValue("Id", item.Id),
                                           new ParameterValue("GeneralChangesItemGroupId", item.GeneralChangesItemGroup.Id),
                                           new ParameterValue("ItemName", item.ItemName),
                                           new ParameterValue("Active", item.Active),
                                           new ParameterValue("SortOrder", item.SortOrder)
                    );
            }
            else
            {
                dr = DataFacade.GetDataRow("GeneralChangesItemCreate",
                                           new ParameterValue("GeneralChangesItemGroupId", item.GeneralChangesItemGroup.Id),
                                           new ParameterValue("ItemName", item.ItemName),
                                           new ParameterValue("Active", item.Active),
                                           new ParameterValue("SortOrder", item.SortOrder)
                    );
            }

            return GetGeneralChangesGroups().Select(x => x.GeneralChangesItems.FirstOrDefault(y => y.Id == Convert.ToInt32(dr["Id"]))).FirstOrDefault();
        }
    }
}
