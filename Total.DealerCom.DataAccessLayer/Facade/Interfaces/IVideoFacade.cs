using Total.DealerCom.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Total.DealerCom.DataAccessLayer.Facade.Interfaces
{
    public interface IVideoFacade
    {
        List<Video> GetAll();

        void LogVideoAccess(VideoAudit videoAudit);
    }
}
