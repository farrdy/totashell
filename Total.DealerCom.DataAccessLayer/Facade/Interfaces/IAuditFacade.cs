using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Infrastructure.Shared.Security;
using Total.DealerCom.Core;


namespace Total.DealerCom.DataAccessLayer.Facade.Interfaces
{
    /// <summary>
    /// IAuditfacade  
    /// </summary>
    public interface IAuditFacade
    {

        int Add(Audit audit);

        int Update(Audit audit);

        Audit AuditGet(int auditid);

        List<Audit> GetAll();

        IEnumerable<Audit> Search(Audit audit);

    }

}

