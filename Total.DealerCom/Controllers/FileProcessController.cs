﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Total.DealerCom.Web.Models;

namespace Total.DealerCom.Web.Controllers
{
    public class FileProcessController : Controller
    {
        //  
        // GET: /FileProcess/  

        DownloadFiles obj;
        public FileProcessController()
        {
            obj = new DownloadFiles();
        }

        public ActionResult FileDownloads()
        {
            var filesCollection = obj.GetFiles();
            return View(filesCollection);
        }

        public FileResult Download(string FileID)
        {
            int CurrentFileID = Convert.ToInt32(FileID);
            var filesCol = obj.GetFiles();
            string CurrentFileName = (from fls in filesCol
                                      where fls.FileId == CurrentFileID
                                      select fls.FilePath).First();

            string contentType = string.Empty;

            if (CurrentFileName.Contains(".pdf"))
            {
                contentType = "application/pdf";
            }

            else if (CurrentFileName.Contains(".docx"))
            {
                contentType = "application/docx";
            }
            return File(CurrentFileName, contentType, CurrentFileName);
        }
    }  
}