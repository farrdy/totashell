
using System.Collections.Generic;
using System.Data;
using System.Transactions;
using System.Web.UI.WebControls;
using Infrastructure.Server.DataAccess;
using Infrastructure.Shared.Security;
using Total.DealerCom.DataAccessLayer.DataAccess;
using Total.DealerCom.Core;
using Total.DealerCom.DataAccessLayer.Facade.Interfaces;

namespace Total.DealerCom.DataAccessLayer.Facade
{
    public class UserFacade : IUserFacade
    {
        #region IUserFacade Members

        public SecurityUser Authenticate(string userName, string password)
        {

            DataRow dataRow = DataFacade.GetDataRow("UserLogin",
                                                     new ParameterValue("UserID", userName),
                                                     new ParameterValue("Password", password));

            //Detail that is returned
            SecurityUser securityUser;

            if (dataRow != null)
            {
                var userId = dataRow["UserID"].ToString().Trim();
                var roleId = dataRow["RoleID"].ToString();
                var permission = dataRow["PermissionString"].ToString();
                var name = dataRow["Name"].ToString();
                var passwordChangeRequired = bool.Parse(dataRow["PasswordChangeRequired"].ToString());
	            

                DataFacade.ExecuteNonQuery("LogLoginInsert",
                                                     new ParameterValue("UserID", userId));

                securityUser = new SecurityUser(userId, userName, permission, name, roleId, passwordChangeRequired);
            }
            else
            {
                throw new SecurityException(
                      "Login Failed.");
            }

            return securityUser;
        }


        public string GetMenuItems(string userId)
        {
            return UserDao.GetMenuItems(userId);
        }

        public string GetDryStockMenuXml(string userId)
        {
            return UserDao.GetDryStockMenuXml(userId);
        }


        public SecurityUser UserLoginAs(string userID)
        {

            DataRow dataRow = DataFacade.GetDataRow("UserLoginAs",
                                                    new ParameterValue("UserID", userID));
                                                   

            //Detail that is returned
            SecurityUser securityUser;

            if (dataRow != null)
            {
                var userId = dataRow["UserID"].ToString().Trim();
                var roleId = dataRow["RoleID"].ToString();
                var permission = dataRow["PermissionString"].ToString();
                var name = dataRow["Name"].ToString();
                var passwordChangeRequired = bool.Parse(dataRow["PasswordChangeRequired"].ToString());


                DataFacade.ExecuteNonQuery("UserLoginAs",
                                           new ParameterValue("UserID", userId));

                securityUser = new SecurityUser(userId, "", permission, name, roleId, passwordChangeRequired);
            }
            else
            {
                throw new SecurityException(
                    "Login Failed.");
            }
            return securityUser;
        }

        public IEnumerable<User> Search(User user)
        {
            return UserDao.Search(user);
        }

        public IEnumerable<DealerAccountInfo> GetDealerAccountInfo(string userName)
        {
            return UserDao.GetDealerAccountInfo(userName);
        }
       


        public List<string> PopulateRoleList(ref DropDownList dropDownList)
        {
            dropDownList.Items.Clear();
            var groupList = UserDao.GetRoleList();
            var returnList = new List<string>();

            foreach (var g in groupList)
            {
                returnList.Add(g.RoleID);
                dropDownList.Items.Add(new ListItem(g.Description, g.RoleID));
            }

            return returnList;
        }

        public DataRow UpdatePassword(User user)
        {
            DataRow dataRow = UserDao.UpdatePassword(user);
            
            return dataRow;
        }

        public void UpdateExpiredPassword(SecurityUser securityUser, User user)
        {
            using (var scope = new TransactionScope())
            {
                UserDao.UpdateExpiredPassword(securityUser, user);
                scope.Complete();
            }
        }

        public void Update(User user)
        {
            //using (var scope = new TransactionScope())
            //{
                UserDao.Update(user);
            //    scope.Complete();
            //}
        }

        public void Add(ref User user)
        {
            //using (var scope = new TransactionScope())
            //{
                UserDao.Add(ref user);
            //    scope.Complete();
            //}
        }

        public void Delete(string users)
        {
            UserDao.Delete(users);
        }

        public void Activate(string users)
        {
            UserDao.Activate(users);
        }

        public void Deactivate(string users)
        {
            UserDao.Deactivate(users);
        }

        public string SendUserPassword(string newPassword, User user)
        {
            DataRow dataRow = UserDao.SendUserPassword(newPassword, user);

            if (dataRow != null)
            {
                var email = dataRow["Email"].ToString().Trim();
                return email;
            }
            return string.Empty;
        }

        public User Read(string id)
        {
            return UserDao.Read(id);
        }
        

        public string ValidateUniqueUserName(User user)
        {
            DataSet dataSet = UserDao.ValidateUniqueUserName(user);

            DataTable countTable = dataSet.Tables["User"];

            var reader = new NullableDataRowReader(countTable.Rows[0]);
            return reader.GetString("usercount");
        }

        public string ValidateUniqueLogon(User user)
        {
            DataSet dataSet = UserDao.ValidateUniqueLogon(user);

            DataTable countTable = dataSet.Tables["User"];

            var reader = new NullableDataRowReader(countTable.Rows[0]);
            return reader.GetString("logoncount");
        }

        public string ResetPassword(User user)
        {
            DataRow dataRow = UserDao.ResetPassword(user.Id);

            if (dataRow != null)
            {
                var userId = dataRow["Password"].ToString().Trim();
                return userId;
            }
            return string.Empty;
        }

        public string ValidateUniquePassword(string password)
        {
            DataSet dataSet = UserDao.ValidateUniquePassword(password);

            DataTable countTable = dataSet.Tables["User"];

            var reader = new NullableDataRowReader(countTable.Rows[0]);
            return reader.GetString("passwordcount");
        }

       
        public void Delete(int userId)
        {
            using (var scope = new TransactionScope())
            {
                UserDao.Delete(userId);
                scope.Complete();
            }
        }


        #endregion


        public DataSet GetMenuItems(string userId, string bla)
        {
            return UserDao.GetMenuItems(userId,bla);
        }
    }
}