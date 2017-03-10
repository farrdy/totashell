using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Infrastructure.Server.DataAccess;
using Infrastructure.Shared.Security;
using Total.DealerCom.Core;

namespace Total.DealerCom.DataAccessLayer.DataAccess
{
    public class UserDao
    {
        public DataRow Authenticate(string userName, string hashedPassword)
        {
            DataRow dataRow = DataFacade.GetDataRow("Authenticate",
                                                    new ParameterValue("userName", userName),
                                                    new ParameterValue("password", hashedPassword));

            return dataRow;
        }

        public static IEnumerable<Role> GetRoleList()
        {
            var dataTable = DataFacade.GetDataTable("RoleLoad",
                                                    new ParameterValue[0]);

            return (from DataRow r in dataTable.Rows
                    select new Role
                        {
                            RoleID = r["RoleID"].ToString(),
                            Description = r["Description"].ToString(),
                            Code = r["Code"].ToString()
                        }).ToList();
        }

        public static IEnumerable<DealerAccountInfo> GetDealerAccountInfo(string userName)
        {
            var dataTable = DataFacade.GetDataTable("GetDealerAccountInfo",
                                                  new ParameterValue("userName", userName));

            return (from DataRow r in dataTable.Rows
                    select new DealerAccountInfo
                    {
                        SoldTo = r["SoldTo"] != DBNull.Value ? r["SoldTo"].ToString() : "",
                        ShipTo = r["ShipTo"] != DBNull.Value ? r["ShipTo"].ToString() : "",
                        TemplateLightShipTo = r["TemplateLightShipTo"] != DBNull.Value ? r["TemplateLightShipTo"].ToString() : "",
                        TemplateLightSoldTo = r["TemplateLightSoldTo"] != DBNull.Value ? r["TemplateLightSoldTo"].ToString() : "",
                        DealerName = r["DealerName"] != DBNull.Value ? r["DealerName"].ToString() : ""
                    }).ToList();
        }

        public static DataSet GetMenuItems(string userId, string bla)
        {
            //Setting up menu
            var ds = new DataSet();

            ds = GetMenuData(userId, ds);

            return ds;
        }

        public static string GetMenuItems(string userId)
        {
            //Setting up menu
            var ds = new DataSet();

            ds = GetMenuData(userId, ds);

            return ds.GetXml();
        }

        private static DataSet GetMenuData(string userId, DataSet ds)
        {
            var roleIdList = new List<string>();

            using (
                var conn =
                    new SqlConnection(
                        ConfigurationManager.ConnectionStrings["TotalDealerCommunicationConnectionString"].
                            ConnectionString))
            {
                //Using parameters to protect against potential SQL injection
                //TODO: Move this entire method to a stored procedure to keep things neat

                var par = new SqlParameter("userID", SqlDbType.VarChar) { Value = userId };
                var sql =
                    new SqlCommand(
                        "select FunctionId from SecurityRoleFunction s inner join SecurityUserRole d on s.RoleId = d.RoleID where d.UserID = @userID",
                        conn);
                sql.Parameters.Add(par);
                var da = new SqlDataAdapter(sql);

                da.Fill(ds);
                da.Dispose();

                ds.DataSetName = "Menus";
                ds.Tables[0].TableName = "Menu";

                //Getting rid of '-1' parent Id values in our dataset. Parent-child relationship need them to be NULL!
                for (int x = 0; x < ds.Tables["Menu"].Rows.Count; x++)
                {
                    roleIdList.Add(ds.Tables["Menu"].Rows[x]["FunctionId"].ToString());
                }
            }

            ds = new DataSet();

            string roleList = string.Empty;
            if (GetRoleIdList(roleIdList) == string.Empty)
            {
                roleList = "0";
            }

            //RoleList above selected from database. Values below not open to SQL injection. Refer to above TODO:
            if (roleList != "0")
            {
                //Selecting menu from database
                using (
                    var conn =
                        new SqlConnection(
                            ConfigurationManager.ConnectionStrings["TotalDealerCommunicationConnectionString"].
                                ConnectionString))
                {
                    var sql =
                        "select FunctionId, MenuCaption,Description, ParentFunctionId, URL, Type, menusequence " +
                        "from dbo.SecurityFunctions " +
                        "where FunctionId in (" + GetRoleIdList(roleIdList) +
                        ") or FunctionId in (select distinct ParentFunctionId " +
                        "from dbo.SecurityFunctions " +
                        "where FunctionId in (" + GetRoleIdList(roleIdList) + ")) " +
                        " order by type, menusequence asc";
                    var da = new SqlDataAdapter(sql, conn);
                    da.Fill(ds);
                    da.Dispose();
                }
                ds.DataSetName = "Menus";
                ds.Tables[0].TableName = "Menu";
            }
            else
            {
                //Selecting menu from database
                using (
                    var conn =
                        new SqlConnection(
                            ConfigurationManager.ConnectionStrings["TotalDealerCommunicationConnectionString"].
                                ConnectionString))
                {
                    var sql =
                        "select FunctionId, MenuCaption,Description, ParentFunctionId, URL, Type, menusequence " +
                        "from dbo.SecurityFunctions " +
                        "where FunctionId in (" + roleList +
                        ") or FunctionId in (select distinct ParentFunctionId " +
                        "from dbo.SecurityFunctions " +
                        "where FunctionId in (" + roleList + ")) " +
                        " order by type, menusequence asc";
                    var da = new SqlDataAdapter(sql, conn);
                    da.Fill(ds);
                    da.Dispose();
                }
                ds.DataSetName = "Menus";
                ds.Tables[0].TableName = "Menu";
            }

            //Getting rid of '-1' parent Id values in our dataset. Parent-child relationship need them to be NULL!
            for (int x = 0; x < ds.Tables["Menu"].Rows.Count; x++)
            {
                if (ds.Tables["Menu"].Rows[x]["ParentFunctionId"].ToString() == "-1")
                {
                    ds.Tables["Menu"].Rows[x]["ParentFunctionId"] = DBNull.Value;
                }
            }

            //Setting up a data relation
            var relation = new DataRelation("ParentChild",
                                            ds.Tables["Menu"].Columns["FunctionId"],
                                            ds.Tables["Menu"].Columns["ParentFunctionId"], true) { Nested = true };

            ds.Relations.Add(relation);
            return ds;
        }


        public static string GetDryStockMenuXml(string userId)
        {
            //Setting up menu
            var ds = new DataSet();

            var roleIdList = new List<string>();

            using (
                var conn =
                    new SqlConnection(
                        ConfigurationManager.ConnectionStrings["TotalDealerCommunicationConnectionString"].
                            ConnectionString))
            {
                //Using parameters to protect against potential SQL injection
                //TODO: Move this entire method to a stored procedure to keep things neat

                var par = new SqlParameter("userID", SqlDbType.VarChar) { Value = userId };
                var sql =
                    new SqlCommand(
                        "select FunctionId from SecurityRoleFunctionDryStock s inner join SecurityUserRole d on s.RoleId = d.RoleID where d.UserID = @userID",
                        conn);
                sql.Parameters.Add(par);
                var da = new SqlDataAdapter(sql);

                da.Fill(ds);
                da.Dispose();

                ds.DataSetName = "Menus";
                ds.Tables[0].TableName = "Menu";

                //Getting rid of '-1' parent Id values in our dataset. Parent-child relationship need them to be NULL!
                for (int x = 0; x < ds.Tables["Menu"].Rows.Count; x++)
                {
                    roleIdList.Add(ds.Tables["Menu"].Rows[x]["FunctionId"].ToString());
                }
            }

            ds = new DataSet();

            string roleList = string.Empty;
            if (GetRoleIdList(roleIdList) == string.Empty)
            {
                roleList = "0";
            }

            //RoleList above selected from database. Values below not open to SQL injection. Refer to above TODO:
            if (roleList != "0")
            {
                //Selecting menu from database
                using (
                    var conn =
                        new SqlConnection(
                            ConfigurationManager.ConnectionStrings["TotalDealerCommunicationConnectionString"].
                                ConnectionString))
                {
                    var sql =
                        "select FunctionId, MenuCaption,Description, ParentFunctionId, URL, Type, menusequence " +
                        "from dbo.SecurityFunctionsDryStock " +
                        "where FunctionId in (" + GetRoleIdList(roleIdList) +
                        ") or FunctionId in (select distinct ParentFunctionId " +
                        "from dbo.SecurityFunctionsDryStock " +
                        "where FunctionId in (" + GetRoleIdList(roleIdList) + ")) " +
                        " order by type, menusequence asc";
                    var da = new SqlDataAdapter(sql, conn);
                    da.Fill(ds);
                    da.Dispose();
                }
                ds.DataSetName = "Menus";
                ds.Tables[0].TableName = "Menu";
            }
            else
            {
                //Selecting menu from database
                using (
                    var conn =
                        new SqlConnection(
                            ConfigurationManager.ConnectionStrings["TotalDealerCommunicationConnectionString"].
                                ConnectionString))
                {
                    var sql =
                        "select FunctionId, MenuCaption,Description, ParentFunctionId, URL, Type, menusequence " +
                        "from dbo.SecurityFunctionsDryStock " +
                        "where FunctionId in (" + roleList +
                        ") or FunctionId in (select distinct ParentFunctionId " +
                        "from dbo.SecurityFunctionsDryStock " +
                        "where FunctionId in (" + roleList + ")) " +
                        " order by type, menusequence asc";
                    var da = new SqlDataAdapter(sql, conn);
                    da.Fill(ds);
                    da.Dispose();
                }
                ds.DataSetName = "Menus";
                ds.Tables[0].TableName = "Menu";
            }

            //Getting rid of '-1' parent Id values in our dataset. Parent-child relationship need them to be NULL!
            for (int x = 0; x < ds.Tables["Menu"].Rows.Count; x++)
            {
                if (ds.Tables["Menu"].Rows[x]["ParentFunctionId"].ToString() == "-1")
                {
                    ds.Tables["Menu"].Rows[x]["ParentFunctionId"] = DBNull.Value;
                }
            }

            //Setting up a data relation
            var relation = new DataRelation("ParentChild",
                                            ds.Tables["Menu"].Columns["FunctionId"],
                                            ds.Tables["Menu"].Columns["ParentFunctionId"], true) { Nested = true };

            ds.Relations.Add(relation);

            return ds.GetXml();
        }

        /// <summary>
        /// Returns a comma delimited list of articles that were selected from the results (i.e. checked)
        /// </summary>
        /// <returns>Comma delimited list of article Ids</returns>
        private static string GetRoleIdList(IEnumerable<string> roleIdList)
        {

            var sb = new StringBuilder();
            foreach (string s in roleIdList)
            {
                sb.Append(s + ",");
            }
            if (sb.ToString().EndsWith(","))
            {
                sb.Remove(sb.Length - 1, 1);
            }
            return sb.ToString();
        }

        public static IEnumerable<User> Search(User user)
        {
            var paramList = new List<ParameterValue>
                {
                    new ParameterValue("DeAct", user.DeAct ? 1 : 0)
                };
            if (!String.IsNullOrEmpty(user.UserName))
            {
                paramList.Add(new ParameterValue("Name", user.UserName));
            }
            if (!String.IsNullOrEmpty(user.IDRole))
            {
                paramList.Add(new ParameterValue("idRole", user.IDRole));
            }
            if (!String.IsNullOrEmpty(user.IDSalesArea))
            {
                paramList.Add(new ParameterValue("idSalesArea", user.IDSalesArea));
            }
            if (!String.IsNullOrEmpty(user.Id))
            {
                paramList.Add(new ParameterValue("UserID", user.Id));
            }

            var dataTable = DataFacade.GetDataTable("UserSearch",
                                                    paramList.ToArray());


            return (from DataRow r in dataTable.Rows
                    select new User
                        {
                            Id = r["UserID"].ToString(),
                            UserName = r["Name"].ToString(),
                            IDRole = r["Role"].ToString(),
                            Email = r["Email"].ToString()
                        }).ToList();
        }

        public static void Delete(string users)
        {
            DataFacade.ExecuteNonQuery("UsersDelete",
                                       new ParameterValue("UserIDs", users));
        }

        public static void Update(User user)
        {
            DataFacade.ExecuteNonQuery("UserEdit",
                                       new ParameterValue("UserID", user.Id),
                                       new ParameterValue("Name", user.UserName),
                                       new ParameterValue("Email", user.Email),
                                       new ParameterValue("idRole", user.IDRole),
                                       new ParameterValue("idRegion", user.IDRegion),
                                       new ParameterValue("idSalesArea", user.IDSalesArea),
                                       new ParameterValue("Adding", 0),
                                       new ParameterValue("LaBoutique", user.LaBoutique ? 1 : 0));
        }

        public static void Add(ref User user)
        {
            DataRow dataRow = DataFacade.GetDataRow("UserEdit",
                                                    new ParameterValue("UserID", user.Id),
                                                    new ParameterValue("Name", user.UserName),
                                                    new ParameterValue("Email", user.Email),
                                                    new ParameterValue("idRole", user.IDRole),
                                                    new ParameterValue("idRegion", user.IDRegion),
                                                    new ParameterValue("idSalesArea", user.IDSalesArea),
                                                    new ParameterValue("Adding", 1),
                                                    new ParameterValue("LaBoutique", user.LaBoutique ? 1 : 0));

            string password = dataRow["Password"].ToString();

            //Returning cleartext password to be emailed to user
            user.Password = password;
        }

        public static void Activate(string users)
        {
            DataFacade.ExecuteNonQuery("UsersActivate",
                                       new ParameterValue("UserIDs", users),
                                       new ParameterValue("Active", 1));
        }

        public static void Deactivate(string users)
        {
            DataFacade.ExecuteNonQuery("UsersActivate",
                                       new ParameterValue("UserIDs", users),
                                       new ParameterValue("Active", 0));
        }

        public static DataSet ValidateUniqueUserName(User user)
        {
            DataSet dataSet = DataFacade.GetDataSet("spValidateUniqueUserNamesNoDuplicates",
                                                    new ParameterValue("Username", user.UserName),
                                                    new ParameterValue("sUserId", user.Id));
            dataSet.Tables[0].TableName = "User";

            return dataSet;
        }

        public static DataSet ValidateUniqueLogon(User user)
        {
            DataSet dataSet = DataFacade.GetDataSet("spValidateUniqueLogonNoDuplicates",
                                                    new ParameterValue("Logon", user.Logon),
                                                    new ParameterValue("sUserId", user.Id));

            dataSet.Tables[0].TableName = "User";

            return dataSet;
        }

        public static DataSet ValidateUniquePassword(string password)
        {
            DataSet dataSet = DataFacade.GetDataSet("spValidateUniquePasswordNoDuplicates",
                                                    new ParameterValue("Password", password));

            dataSet.Tables[0].TableName = "User";

            return dataSet;
        }

        public static DataRow ResetPassword(string id)
        {
            DataRow dataRow = DataFacade.GetDataRow("UserPasswordReset",
                                                    new ParameterValue("UserID", id));

            return dataRow;
        }

        public static DataRow SendUserPassword(string newPassword, User user)
        {
            DataRow dataRow = DataFacade.GetDataRow("UserSendPassword",
                                                    new ParameterValue("UserID", user.Id),
                                                    new ParameterValue("ClearTextPassword", newPassword));

            return dataRow;

        }

        public static DataRow UpdatePassword(User user)
        {
            DataRow dataRow = DataFacade.GetDataRow("UserPasswordChange",
                                                    new ParameterValue("UserId", user.Id),
                                                    new ParameterValue("NewPassword", user.NewPassword),
                                                    new ParameterValue("OldPassword", user.OldPassword));

            return dataRow;
        }

        public static void UpdateExpiredPassword(SecurityUser securityUser, User user)
        {
            DataFacade.ExecuteNonQuery("UserPasswordExpiredUpdate",
                                       new ParameterValue("UserId", user.Id),
                                       new ParameterValue("Password", user.Password),
                                       new ParameterValue("UpdatedBy", securityUser.UserId));

        }

        public static User Read(string id)
        {

            DataRow r = DataFacade.GetDataRow("UserGet",
                                              new ParameterValue("UserID", id));

            if (r == null) throw new Exception("User with ID: " + id + " does not exist.");

            var l = new User
                {
                    Id = r["UserID"].ToString(),
                    UserName = r["Name"].ToString(),
                    IDRole = r["idRole"].ToString(),
                    Email = r["Email"].ToString(),
                    Password = r["Password"].ToString(),
                    Active = Convert.ToBoolean(r["Active"].ToString()),
                    PasswordChange = Convert.ToBoolean(r["PasswordChangeRequired"].ToString()),
                    IDRegion = r["idRegion"].ToString(),
                    IDSalesArea = r["idSalesArea"].ToString(),
                    LaBoutique = Convert.ToBoolean(r["LaBoutique"].ToString())
                };
            return l;

        }

        public static void Delete(int userId)
        {
            DataFacade.ExecuteNonQuery("UserDelete",
                                       new ParameterValue("UserId", userId));
        }
    }
}