using Services.DataAccess;
using Services.DTO;
using Services.Facade.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Facade
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
