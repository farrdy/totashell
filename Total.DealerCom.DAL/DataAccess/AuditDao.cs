using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Infrastructure.Server.DataAccess;
using Services.DTO;


namespace Services.DataAccess
{
    /// <summary>
    /// AuditDao Domain Object
    /// </summary>
    public partial class AuditDao
    {

        public static int Add(Audit audit)
        {

            var r = DataFacade.GetDataRow("AuditInsert",

                                          new ParameterValue("Description", audit.Description),
                                          new ParameterValue("UpdateDate", audit.UpdateDate),
                                          new ParameterValue("UserID", audit.UserID),
                                          new ParameterValue("TableName", audit.TableName),
                                          new ParameterValue("TableKey", audit.TableKey)

                );

            return (int) r["AuditId"];
        }

        public static int Update(Audit audit)
        {

            var r = DataFacade.GetDataRow("AuditUpdate",
                                          new ParameterValue("AuditId", audit.AuditId),
                                          new ParameterValue("Description", audit.Description),
                                          new ParameterValue("UpdateDate", audit.UpdateDate),
                                          new ParameterValue("UserID", audit.UserID),
                                          new ParameterValue("TableName", audit.TableName),
                                          new ParameterValue("TableKey", audit.TableKey)

                );

            return (int) r["AuditId"];
        }

        public static Audit AuditGet(int auditid)
        {
            var audit = new Audit();
            var paramList = new List<ParameterValue> {new ParameterValue("AuditId", auditid)};

            var r = DataFacade.GetDataRow("AuditGet",
                                          paramList.ToArray());
            if (r != null)
            {
                Populate(audit, r);
            }
            return audit;
        }

        public static List<Audit> GetAll()
        {

            var paramList = new List<ParameterValue>();

            var dataTable = DataFacade.GetDataTable("AuditGetAll",
                                                    paramList.ToArray());

            var returnList = new List<Audit>();

            foreach (DataRow r in dataTable.Rows)
            {
                var audit = new Audit();

                Populate(audit, r);

                returnList.Add(audit);

            }

            return returnList;
        }

        public static Audit Populate(Audit audit, DataRow dr)
        {
            if (dr["AuditId"] != DBNull.Value) audit.AuditId = Convert.ToInt32(dr["AuditId"]);
            if (dr["Description"] != DBNull.Value) audit.Description = Convert.ToString(dr["Description"]);
            if (dr["UpdateDate"] != DBNull.Value) audit.UpdateDate = Convert.ToDateTime(dr["UpdateDate"]);
            if (dr["UserID"] != DBNull.Value) audit.UserID = Convert.ToString(dr["UserID"]);
            if (dr["TableName"] != DBNull.Value) audit.TableName = Convert.ToString(dr["TableName"]);
            if (dr["TableKey"] != DBNull.Value) audit.TableKey = Convert.ToString(dr["TableKey"]);

            return audit;
        }


        public static IEnumerable<Audit> Search(Audit audit)
        {
            var paramList = new List<ParameterValue>
                {
                    new ParameterValue("StartDate", audit.StartDate),
                    new ParameterValue("EndDate", audit.EndDate)
                };

            if (!String.IsNullOrEmpty(audit.Description))
            {
                paramList.Add(new ParameterValue("Description", audit.Description));
            }
            if (!String.IsNullOrEmpty(audit.TableName))
            {
                paramList.Add(new ParameterValue("TableName", audit.TableName));
            }
            if (!String.IsNullOrEmpty(audit.UserID))
            {
                paramList.Add(new ParameterValue("UserID", audit.UserID));
            }
            if (!String.IsNullOrEmpty(audit.TableKey))
            {
                paramList.Add(new ParameterValue("TableKey", audit.TableKey));
            }

            var dataTable = DataFacade.GetDataTable("AuditSearch",
                                                    paramList.ToArray());


            return (from DataRow r in dataTable.Rows
                    select new Audit
                        {
                            UserID = r["UserID"].ToString(),
                            TableKey = r["TableKey"].ToString(),
                            TableName = r["TableName"].ToString(),
                            Description = r["Description"].ToString(),
                            UpdateDate = (DateTime) r["UpdateDate"]
                        }).ToList();
        }

    }
}


