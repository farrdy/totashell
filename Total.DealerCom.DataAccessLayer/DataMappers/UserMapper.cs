using System;
using System.Data;
using Infrastructure.Server.DataAccess;
using Total.DealerCom.Core;

namespace Total.DealerCom.DataAccessLayer.DataMappers
{
    public class UserMapper
    {
        public static User Transform(DataSet dataSet)
        {
            var user = new User();

            DataTable userTable = dataSet.Tables["User"];

            var reader = new NullableDataRowReader(userTable.Rows[0]);
            user.Id = reader.GetString("Id");
            user.UserName = reader.GetString("UserName");
            user.Logon = reader.GetString("Logon");
            user.Password = reader.GetString("Password");
            user.Level = reader.GetInt32("Level");
            user.IsReference = reader.GetString("Reference");
            user.IsLocked = reader.GetBoolean("IsLocked");

            return user;
        }
    }
}
