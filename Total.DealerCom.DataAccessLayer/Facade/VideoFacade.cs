using Total.DealerCom.DataAccessLayer.DataAccess;
using Total.DealerCom.Core;
using Total.DealerCom.DataAccessLayer.Facade.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Total.DealerCom.DataAccessLayer.Facade
{
    public class VideoFacade : IVideoFacade
    {

        public List<Video> GetAll()
        {
            return VideoDao.GetAll();
        }

        public void LogVideoAccess(VideoAudit videoAudit)
        {
            VideoDao.LogVideoAccess(videoAudit);
        }
    }
}
