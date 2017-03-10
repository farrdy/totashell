

namespace Total.DealerCom.DataAccessLayer
{
    public static class Constants
    {
        public const string ArticleCategory = "ArticleCat";
        public const string ArticleType = "ArticleType";
        public const string MSStatus = "MSStatus";
        public const string Region = "Region";
        public const string SalesArea = "SalesArea";
        
        public const string AdminUserID = "AdminUserID";
        public const string AdminRoleID = "AdminRoleID";
        public const string AdminRole = "AdminRole";
        public const string AdminPermissionString = "AdminPermissionString";
        public const string AdminName = "AdminName";

        public const string VIEW = "VIEW";
        public const string EDIT = "EDIT";
        public const string ADD = "ADD";

        public const string UserID = "UserID";
        public const string SoldTo = "SoldTo";
        public const string ShipTo = "ShipTo";
        public const string TemplateLightSoldTo = "TemplateLightSoldTo";
        public const string TemplateLightShipTo = "TemplateLightShipTo";
        public const string UserInfo = "UserInfo";
        public const string RoleID = "RoleID";
        public const string Role = "Role";
        public const string PermissionString = "PermissionString";
        public const string Name = "Name";

        public const string ROLE_ADMIN = "1";
        public const string ROLE_DEALER = "2";
        public const string ROLE_MSADMIN = "3";
        public const string ROLE_TOTALUSER = "4";
        public const string ROLE_STANDINGDRYUSER = "10";
        public const string ROLE_SUPERADMIN = "11";
        public const string ROLE_MDBADMIN = "12";
        public const string ROLE_DRYSTOCKADMIN = "13";
        public const string ROLE_WETSTOCKADMIN = "14";
        public const string ROLE_HSEQADMIN = "15";

        public const string STATUS_READONLY = "1";

        public const string REQUEST_STATUS_OPEN = "1";
        public const string REQUEST_STATUS_CLOSED = "2";
        public const string REQUEST_STATUS_RETRACTED = "3";


        public const string FAQ_STATUS_TRUE = "1";
        public const string FAQ_STATUS_FALSE = "0";

    }

    public enum Dates
    {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }

    public enum SupplierStatus
    {
        Loaded,
        Reject,
        In_Progress
    
    }
}
