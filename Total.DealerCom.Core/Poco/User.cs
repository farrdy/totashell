namespace Total.DealerCom.Core
{
    public class User
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Logon { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string IDRegion { get; set; }

        public bool LaBoutique { get; set; }

        public int? DefaulterId { get; set; }

        public bool IsLocked { get; set; }

        public bool DeAct { get; set; }

        public bool Active { get; set; }

        public int? LoginErrorCount { get; set; }

        public bool PasswordChange { get; set; }

        public string IsReference { get; set; }

        public int Level { get; set; }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public string IDRole { get; set; }

        public string IDSalesArea { get; set; }

    }
}