using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using Total.DealerCom.DataAccessLayer.DataAccess;
using Total.DealerCom.Core;
using Total.DealerCom.DataAccessLayer.Facade.Interfaces;


namespace Total.DealerCom.DataAccessLayer.Facade
{
    /// <summary>
    /// Auditfacade  
    /// </summary>
    public class AuditFacade : IAuditFacade
    {

        public int Add(Audit audit)
        {

            return AuditDao.Add(audit);
        }

        public int Update(Audit audit)
        {

            return AuditDao.Update(audit);
        }

        public Audit GetAudit(int auditid)
        {
            throw new NotImplementedException();
        }

        public Audit AuditGet(int auditid)
        {
            return AuditDao.AuditGet(auditid);
        }


        public List<Audit> GetAll()
        {
            return AuditDao.GetAll();
        }

        public IEnumerable<Audit> Search(Audit audit)
        {
            return AuditDao.Search(audit);
        }
    }

}







