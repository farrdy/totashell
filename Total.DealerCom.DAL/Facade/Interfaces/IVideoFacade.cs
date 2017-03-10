using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Facade.Interfaces
{
    public interface IVideoFacade
    {
        List<Video> GetAll();

        void LogVideoAccess(VideoAudit videoAudit);
    }
}
