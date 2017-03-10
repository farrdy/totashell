
using Total.DealerCom.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Infrastructure.Server.DataAccess;

namespace Total.DealerCom.DataAccessLayer.DataAccess
{
    public class VideoDao
    {
        public static void LogVideoAccess(VideoAudit videoAudit)
        {
            DataFacade.ExecuteNonQuery("VideoAuditInsert",
                                        new ParameterValue("UserID", videoAudit.UserId),
                                        new ParameterValue("VideoID", videoAudit.VideoId));
        }


        public static List<Video> GetAll()
        {
            var paramList = new List<ParameterValue>();
            var dataTable = DataFacade.GetDataTable("GetVideos",
                                                    paramList.ToArray());

            var returnList = new List<Video>();
            foreach (DataRow r in dataTable.Rows)
            {
                Video video = new Video();
                Populate(video, r);
                returnList.Add(video);
            }
            return returnList;
        }

        private static Video Populate(Video video, DataRow dr)
        {
            video.VideoId = Convert.ToInt32(dr["VideoId"]);
            if (dr["VideoName"] != DBNull.Value) video.VideoName = Convert.ToString(dr["VideoName"]);
            if (dr["VideoDescription"] != DBNull.Value) video.VideoDescription = Convert.ToString(dr["VideoDescription"]);
            if (dr["ViewLink"] != DBNull.Value) video.ViewLink = Convert.ToString(dr["ViewLink"]);
            if (dr["DownloadLink"] != DBNull.Value) video.DownloadLink = Convert.ToString(dr["DownloadLink"]);
            return video;
        }
    }
}
