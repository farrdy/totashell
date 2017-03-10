using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Infrastructure.Server.DataAccess;
using Services.DTO;

namespace Services.DataAccess
{
    internal class IssueDao
    {
        public static IEnumerable<User> GetDealerUserList()
        {
            var dataTable = DataFacade.GetDataTable("DealerUserLoad",
                                                    new ParameterValue[0]);


            return (from DataRow r in dataTable.Rows
                    select new User
                        {
                            Id = r["UserID"].ToString(),
                            UserName = r["Name"].ToString()
                        }).ToList();
        }

        public static List<KeyValuePair<int, string>> GetTankList()
        {
            var dataTable = DataFacade.GetDataTable("TankLoad",
                                                    new ParameterValue[0]);


            return (from DataRow r in dataTable.Rows
                    select
                        new KeyValuePair<int, string>(Convert.ToInt32(r["idTank"].ToString()), r["TankName"].ToString()))
                .ToList();
        }

        public static List<KeyValuePair<int, string>> GetSOCList()
        {
            var dataTable = DataFacade.GetDataTable("SOCLoad",
                                                    new ParameterValue[0]);


            return (from DataRow r in dataTable.Rows
                    select
                        new KeyValuePair<int, string>(Convert.ToInt32(r["idSOC"].ToString()), r["SOCName"].ToString())).
                ToList();
        }

        public static List<KeyValuePair<int, string>> GetIssueTypeList()
        {
            var dataTable = DataFacade.GetDataTable("IssueTypeLoad",
                                                    new ParameterValue[0]);


            return (from DataRow r in dataTable.Rows
                    select
                        new KeyValuePair<int, string>(Convert.ToInt32(r["idIssueType"].ToString()),
                                                      r["IssueTypeName"].ToString())).ToList();
        }

        public static List<KeyValuePair<int, string>> GetProductList()
        {
            var dataTable = DataFacade.GetDataTable("ProductLoad",
                                                    new ParameterValue[0]);


            return (from DataRow r in dataTable.Rows
                    select
                        new KeyValuePair<int, string>(Convert.ToInt32(r["idProduct"].ToString()),
                                                      r["ProductName"].ToString())).ToList();
        }

        public static List<KeyValuePair<int, string>> GetRequestStatusList()
        {
            var dataTable = DataFacade.GetDataTable("RequestStatusLoad",
                                                    new ParameterValue[0]);


            return (from DataRow r in dataTable.Rows
                    select
                        new KeyValuePair<int, string>(Convert.ToInt32(r["idRequestStatus"].ToString()),
                                                      r["RequestStatusName"].ToString())).ToList();
        }

        public static IEnumerable<IssueResult> Search(Issue log)
        {

            var paramList = new List<ParameterValue>
                {new ParameterValue("DateDryFrom", log.DateDryFrom), new ParameterValue("DateDryTo", log.DateDryTo)};


            if (!String.IsNullOrEmpty(log.DealerUser) && log.DealerUser.Trim() != "0")
            {
                paramList.Add(new ParameterValue("DealerUser", log.DealerUser));
            }
            if (log.IDInstance != null)
            {
                paramList.Add(new ParameterValue("idInstance", log.IDInstance));
            }
            if (log.IDProduct != null && log.IDProduct != 0)
            {
                paramList.Add(new ParameterValue("idProduct", log.IDProduct));
            }
            if (!String.IsNullOrEmpty(log.IDRequestStatus) && log.IDRequestStatus != "0")
            {
                paramList.Add(new ParameterValue("idRequestStatus", log.IDRequestStatus));
            }
            if (log.IDSoc != null && log.IDSoc != 0)
            {
                paramList.Add(new ParameterValue("idSoc", log.IDSoc));
            }
            if (log.IDTank != null && log.IDTank != 0)
            {
                paramList.Add(new ParameterValue("idTank", log.IDTank));
            }
            if (!String.IsNullOrEmpty(log.Name))
            {
                paramList.Add(new ParameterValue("Name", log.Name));
            }
            if (!String.IsNullOrEmpty(log.OutletNo))
            {
                paramList.Add(new ParameterValue("OutletNo", log.OutletNo));
            }
            if (!String.IsNullOrEmpty(log.UserId))
            {
                paramList.Add(new ParameterValue("UserId", log.UserId));
            }

            var dataTable = DataFacade.GetDataTable("InstanceSearch",
                                                    paramList.ToArray());


            return (from DataRow r in dataTable.Rows
                    select new IssueResult
                        {
                            DateDryFrom = r["DateDryFrom"].ToString(),
                            DateDryTo = r["DateDryTo"].ToString(),
                            ATGCommFail = r["ATGCommFail"].ToString(),
                            ATGOperational = r["ATGOperational"].ToString(),
                            Claim = r["Claim"].ToString(),
                            ClaimComment = r["ClaimComment"].ToString(),
                            DealerName = r["DealerName"].ToString(),
                            IDInstance = (r["idInstance"].ToString()),
                            IDIssueType = (r["idIssueType"].ToString()),
                            IDProduct = (r["idProduct"].ToString()),
                            ProductName = (r["ProductName"].ToString()),
                            IDRequestStatus = (r["idRequestStatus"].ToString()),
                            RequestStatusName = (r["RequestStatusName"].ToString()),
                            IDSOC = (r["idSOC"].ToString()),
                            IDTank = (r["idTank"].ToString()),
                            TankName = (r["TankName"].ToString()),
                            UserId = r["UserId"].ToString()
                        }).ToList();
        }

        public static IssueResult GetInstance(string id)
        {
            var paramList = new List<ParameterValue> {new ParameterValue("idInstance", id)};

            var r = DataFacade.GetDataRow("InstanceGet",
                                          paramList.ToArray());

            var l = new IssueResult
                {
                    DateDryFrom = r["DateDryFrom"].ToString(),
                    DateDryTo = r["DateDryTo"].ToString(),
                    ATGCommFail = r["ATGCommFail"].ToString(),
                    ATGOperational = r["ATGOperational"].ToString(),
                    Claim = r["Claim"].ToString(),
                    ClaimComment = r["ClaimComment"].ToString(),
                    IDIssueType = (r["idIssueType"].ToString()),
                    IDProduct = (r["idProduct"].ToString()),
                    ProductName = (r["ProductName"].ToString()),
                    IDRequestStatus = (r["idRequestStatus"].ToString()),
                    RequestStatusName = (r["RequestStatusName"].ToString()),
                    IDTank = (r["idTank"].ToString()),
                    TankName = (r["TankName"].ToString()),
                    UserId = r["UserId"].ToString(),
                    Email = r["Email"].ToString(),
                    Name = r["Name"].ToString(),
                    PODReference = r["PODReference"].ToString(),
                    DateLogged = (r["DateLogged"].ToString()),
                    DateClosed = (r["DateClosed"].ToString()),
                    Comment = r["Comment"].ToString(),
                    IssueTypeName = r["IssueTypeName"].ToString(),
                    Volume = r["Volume"].ToString(),
                    IDInstance = (r["idInstance"].ToString()),
                    IDSOC = (r["idSOC"].ToString()),
                    SOCName = (r["SOCName"].ToString())
                };


            return l;
        }

        public static string Edit(IssueResult log)
        {

            var paramList = new List<ParameterValue> {new ParameterValue("idInstance", log.IDInstance)};

            if (!String.IsNullOrEmpty(log.DateDryTo))
            {
                paramList.Add(new ParameterValue("DateDryTo", log.DateDryTo)); //
            }
            if (!String.IsNullOrEmpty(log.ATGCommFail))
            {
                paramList.Add(new ParameterValue("ATGCommFail", Convert.ToBoolean(log.ATGCommFail) ? 1 : 0)); //
            }
            if (!String.IsNullOrEmpty(log.ATGOperational))
            {
                paramList.Add(new ParameterValue("ATGOperational", Convert.ToBoolean(log.ATGOperational) ? 1 : 0)); //
            }
            if (!String.IsNullOrEmpty(log.DateDryFrom))
            {
                paramList.Add(new ParameterValue("DateDryFrom", log.DateDryFrom)); //
            }

            if (!String.IsNullOrEmpty(log.DateLogged))
            {
                paramList.Add(new ParameterValue("DateLogged", log.DateLogged)); //
            }

            if (!String.IsNullOrEmpty(log.PODReference))
            {
                paramList.Add(new ParameterValue("PODReference", log.PODReference)); //
            }

            if (!String.IsNullOrEmpty(log.Comment))
            {
                paramList.Add(new ParameterValue("Comment", log.Comment)); //
            }
            if (!String.IsNullOrEmpty(log.Claim))
            {
                paramList.Add(new ParameterValue("Claim", Convert.ToBoolean(log.Claim) ? 1 : 0)); //
            }
            if (!String.IsNullOrEmpty(log.ClaimComment))
            {
                paramList.Add(new ParameterValue("ClaimComment", log.ClaimComment)); //
            }
            if (!String.IsNullOrEmpty(log.Volume))
            {
                paramList.Add(new ParameterValue("Volume", log.Volume)); //
            }

            if (!String.IsNullOrEmpty(log.DealerUser))
            {
                paramList.Add(new ParameterValue("DealerUser", log.DealerUser));
            }
            if (log.IDInstance != null)
            {
                paramList.Add(new ParameterValue("idInstance", log.IDInstance));
            }

            if (!String.IsNullOrEmpty(log.IDIssueType))
            {
                paramList.Add(new ParameterValue("idIssueType", log.IDIssueType)); //
            }
            if (log.IDProduct != null)
            {
                paramList.Add(new ParameterValue("idProduct", log.IDProduct)); //
            }
            if (log.IDRequestStatus != null)
            {
                paramList.Add(new ParameterValue("idRequestStatus", log.IDRequestStatus)); //
            }
            if (log.IDSOC != null)
            {
                paramList.Add(new ParameterValue("idSOC", log.IDSOC)); //
            }
            if (log.IDTank != null)
            {
                paramList.Add(new ParameterValue("idTank", log.IDTank)); //
            }
            if (!String.IsNullOrEmpty(log.Name))
            {
                paramList.Add(new ParameterValue("Name", log.Name)); //
            }
            if (!String.IsNullOrEmpty(log.UserId))
            {
                paramList.Add(new ParameterValue("UserId", log.UserId)); //
            }

            paramList.Add(new ParameterValue("Adding", log.Adding ? 1 : 0)); //


            var r = DataFacade.GetDataRow("InstanceEdit",
                                          paramList.ToArray());

            string idInstance = r["idInstance"].ToString();
            return idInstance;
        }


        public static IEnumerable<IssueResult> Report(Issue log)
        {

            var paramList = new List<ParameterValue>
                {new ParameterValue("DateDryFrom", log.DateDryFrom), new ParameterValue("DateDryTo", log.DateDryTo)};


            if (!String.IsNullOrEmpty(log.DealerUser) && log.DealerUser != "0")
            {
                paramList.Add(new ParameterValue("DealerUser", log.DealerUser));
            }
            if (log.IDInstance != null)
            {
                paramList.Add(new ParameterValue("idInstance", log.IDInstance));
            }
            if (log.IDProduct != null && log.IDProduct != 0)
            {
                paramList.Add(new ParameterValue("idProduct", log.IDProduct));
            }
            if (!String.IsNullOrEmpty(log.IDRequestStatus) && log.IDRequestStatus != "0")
            {
                paramList.Add(new ParameterValue("idRequestStatus", log.IDRequestStatus));
            }
            if (log.IDSoc != null && log.IDSoc != 0)
            {
                paramList.Add(new ParameterValue("idSoc", log.IDSoc));
            }
            if (log.IDTank != null && log.IDTank != 0)
            {
                paramList.Add(new ParameterValue("idTank", log.IDTank));
            }
            if (!String.IsNullOrEmpty(log.Name))
            {
                paramList.Add(new ParameterValue("Name", log.Name));
            }
            if (!String.IsNullOrEmpty(log.OutletNo))
            {
                paramList.Add(new ParameterValue("OutletNo", log.OutletNo));
            }
            if (!String.IsNullOrEmpty(log.UserId))
            {
                paramList.Add(new ParameterValue("UserId", log.UserId));
            }

            var dataTable = DataFacade.GetDataTable("InstanceReport",
                                                    paramList.ToArray());


            return (from DataRow r in dataTable.Rows
                    select new IssueResult
                        {
                            DateDryFrom = (r["DateDryFrom"].ToString()),
                            DateDryTo = (r["DateDryTo"].ToString()),
                            DateLogged = (r["DateLogged"].ToString()),
                            DateClosed = (r["DateClosed"].ToString()),
                            Duration = r["Duration"].ToString(),
                            Comment = r["Comment"].ToString(),
                            IssueTypeName = r["IssueTypeName"].ToString(),
                            Volume = r["Volume Lost (Litres)"].ToString(),
                            ATGCommFail = r["ATGCommFail"].ToString(),
                            ATGOperational = r["ATGOperational"].ToString(),
                            Claim = r["Claim"].ToString(),
                            ClaimComment = r["ClaimComment"].ToString(),
                            DealerName = r["Dealer"].ToString(),
                            IDInstance = (r["idInstance"].ToString()),
                            IDIssueType = (r["idIssueType"].ToString()),
                            IDProduct = (r["idProduct"].ToString()),
                            ProductName = (r["Product"].ToString()),
                            IDRequestStatus = (r["idRequestStatus"].ToString()),
                            RequestStatusName = (r["Status"].ToString()),
                            IDSOC = (r["idSOC"].ToString()),
                            SOCName = (r["SOCName"].ToString()),
                            IDTank = (r["idTank"].ToString()),
                            TankName = (r["Tank"].ToString()),
                            UserId = r["UserId"].ToString()
                        }).ToList();
        }

        public static IEnumerable<LogEntry> LoginSearch(LogEntry log)
        {
            if ((log.StartYear == log.EndYear) && (log.StartMonth == log.EndMonth))
            {
                if (log.EndMonth == 12)
                {
                    log.EndYear++;
                    log.EndMonth = 1;
                }
                else
                {
                    log.EndMonth++;
                }
            }

            var paramList = new List<ParameterValue>();

            if (!String.IsNullOrEmpty(log.UserId))
            {
                paramList.Add(new ParameterValue("UserID", log.UserId));
            }
            if (!String.IsNullOrEmpty(log.UserName))
            {
                paramList.Add(new ParameterValue("Name", log.UserName));
            }
            if (log.StartYear != null)
            {
                paramList.Add(new ParameterValue("StartYear", log.StartYear));
            }
            if (log.StartMonth != null)
            {
                paramList.Add(new ParameterValue("StartMonth", log.StartMonth));
            }
            if (log.EndYear != null)
            {
                paramList.Add(new ParameterValue("EndYear", log.EndYear));
            }
            if (log.EndMonth != null)
            {
                paramList.Add(new ParameterValue("EndMonth", log.EndMonth));
            }


            var dataTable = DataFacade.GetDataTable("LogLoginSearch",
                                                    paramList.ToArray());


            return (from DataRow r in dataTable.Rows
                    select new LogEntry
                        {
                            UserId = r["UserID"].ToString(),
                            LastLogin = (r["LastLogin"].ToString()),
                            UserName = r["Name"].ToString(),
                            LoginCount = Convert.ToInt32(r["LoginCount"].ToString())
                        }).ToList();
        }
    }
}
