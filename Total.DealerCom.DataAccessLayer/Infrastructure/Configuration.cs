using System;
using System.Configuration;
using Total.DealerCom.DataAccessLayer.Infrastructure.Interfaces;

namespace Total.DealerCom.DataAccessLayer.Infrastructure
{
    /// <summary>
    /// Example of configuration class. Here you would access config, handle missing values, supply defaults, etc
    /// </summary>
    public class Config : IConfig
    {
        #region IConfig Members

        public string ConnectionString
        {
            get { return ConfigurationManager.AppSettings["ConnectionString"]; }
        }

        public string LogFile
        {
            get { return ConfigurationManager.AppSettings["LogFile"]; }
        }

        public string LogFilePath
        {
            get { return @ConfigurationManager.AppSettings["LogFilePath"]; }
        }

        public int CacheTime
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["CacheTime"]); }
        }

        public string EmailFromAddress
        {
            get { return ConfigurationManager.AppSettings["EmailFromAddress"]; }
        }

        public string SmtpServer
        {
            get { return ConfigurationManager.AppSettings["SmtpServer"]; }
        }

        public string EmailOverride
        {
            get { return ConfigurationManager.AppSettings["EmailOverride"]; }
        }

        public string UploadsPath
        {
            get { return ConfigurationManager.AppSettings["UploadsPath"]; }
        }

        public string ScorecardPath
        {
            get { return ConfigurationManager.AppSettings["ScorecardPath"]; }
        }

        public string AdministratorContactNumber
        {
            get { return ConfigurationManager.AppSettings["AdministratorContactNumber"]; }
        }

        public string SwitchboardContactNumber
        {
            get { return ConfigurationManager.AppSettings["SwitchboardContactNumber"]; }
        }

        public string BusinessContactNumber
        {
            get { return ConfigurationManager.AppSettings["BusinessContactNumber"]; }
        }

        public string BusinessAdministratorName
        {
            get { return ConfigurationManager.AppSettings["BusinessAdministratorName"]; }
        }

        public string DefaultPassword
        {
            get { return ConfigurationManager.AppSettings["DefaultPassword"]; }
        }

        public string DelearFileName
        {
            get { return ConfigurationManager.AppSettings["DelearFileName"]; }
        }

        public string DealerWorkSheet
        {
            get { return ConfigurationManager.AppSettings["DealerWorkSheet"]; }
        }

        public string AccountManagementFileName
        {
            get { return ConfigurationManager.AppSettings["AccountManagementFileName"]; }
        }

        public string AccountManagementWorkSheet
        {
            get { return ConfigurationManager.AppSettings["AccountManagementWorkSheet"]; }
        }

        public string AttendanceFileName
        {
            get { return ConfigurationManager.AppSettings["AttendanceFileName"]; }
        }

        public string AttendanceWorkSheet
        {
            get { return ConfigurationManager.AppSettings["AttendanceWorkSheet"]; }
        }

        public string RentReceivableFileName
        {
            get { return ConfigurationManager.AppSettings["RentReceivableFileName"]; }
        }

        public string RentReceivableWorkSheet
        {
            get { return ConfigurationManager.AppSettings["RentReceivableWorkSheet"]; }
        }

        public string SalesTargetFileName
        {
            get { return ConfigurationManager.AppSettings["SalesTargetFileName"]; }
        }

        public string SalesTargetWorkSheet
        {
            get { return ConfigurationManager.AppSettings["SalesTargetWorkSheet"]; }
        }

        public string SalesVolumeFileName
        {
            get { return ConfigurationManager.AppSettings["SalesVolumeFileName"]; }
        }

        public string SalesVolumeWorkSheet
        {
            get { return ConfigurationManager.AppSettings["SalesVolumeWorkSheet"]; }
        }

        public string TopServiceFileName
        {
            get { return ConfigurationManager.AppSettings["TopServiceFileName"]; }
        }

        public string TopServiceWorkSheet
        {
            get { return ConfigurationManager.AppSettings["TopServiceWorkSheet"]; }
        }

        public string UnpaidsFileName
        {
            get { return ConfigurationManager.AppSettings["UnpaidsFileName"]; }
        }

        public string UnpaidsWorkSheet
        {
            get { return ConfigurationManager.AppSettings["UnpaidsWorkSheet"]; }
        }

        #endregion
    }
}