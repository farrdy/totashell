using System;
using Total.DealerCom.DataAccessLayer.Facade;
using Total.DealerCom.DataAccessLayer.Facade.Interfaces;

namespace WebUI.Context
{
    public class WebSiteContext
    {
/*
        private static readonly object SyncRoot = new Object();
*/

        private static readonly WebSiteContext Instance = new WebSiteContext();
        private readonly IFacadeFactory _facadeFactory;

        private WebSiteContext()
        {
            _facadeFactory = new FacadeFactory();
        }

        public static WebSiteContext GetInstance()
        {
            //if (_instance == null)
            //{
            //    lock (_syncRoot)
            //    {
            //        if (_instance == null)
            //        {
            //            _instance = new WebSiteContext();
            //        }
            //    }
            //}

            return Instance;
        }

        public IFacadeFactory FacadeRepository
        {
            get { return _facadeFactory; }
        }
    }
}