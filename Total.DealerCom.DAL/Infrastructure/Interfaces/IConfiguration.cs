namespace Services.Infrastructure.Interfaces
{
    /// <summary>
    /// Example of configuration interface
    /// </summary>
    public interface IConfig
    {
        string ConnectionString { get; }
        string LogFile { get; }
        string LogFilePath { get; }
        int CacheTime { get; }
        string EmailFromAddress { get; }
        string SmtpServer { get; }
        string EmailOverride { get; }
        string UploadsPath { get; }
        string ScorecardPath { get; }
        string AdministratorContactNumber { get; }
        string BusinessContactNumber { get; }
        string BusinessAdministratorName { get; }
        string SwitchboardContactNumber { get; }
        string DefaultPassword { get; }
        string DelearFileName { get; }
        string DealerWorkSheet { get; }
        string AccountManagementFileName { get; }
        string AccountManagementWorkSheet { get; }
        string AttendanceFileName { get; }
        string AttendanceWorkSheet { get; }
        string RentReceivableFileName { get; }
        string RentReceivableWorkSheet { get; }
        string SalesTargetFileName { get; }
        string SalesTargetWorkSheet { get; }
        string SalesVolumeFileName { get; }
        string SalesVolumeWorkSheet { get; }
        string TopServiceFileName { get; }
        string TopServiceWorkSheet { get; }
        string UnpaidsFileName { get; }
        string UnpaidsWorkSheet { get; }
    }
}