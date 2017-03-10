﻿
using System.Data;
using Infrastructure.Server.DataAccess;
using Total.DealerCom.Core;

namespace Total.DealerCom.DataAccessLayer.DataAccess
{
    internal class EmailDao
    {
        public static string SendEmail(ref Email email)
        {
            DataRow dataRow = DataFacade.GetDataRow("UserSendPassword",
                                                    new ParameterValue("UserID", email.UserID),
                                                    new ParameterValue("ClearTextPassword", email.Password));

            if (dataRow["Email"] != null) return dataRow["Email"].ToString();

            return string.Empty;
        }
    }
}
