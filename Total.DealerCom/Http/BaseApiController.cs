using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Total.DealerCom.DataAccessLayer.Facade.Interfaces;
using TotalDealer_2008;
using WebUI.Context;

namespace Total.DealerCom.Web.Http
{
    public class BaseApiController
    {

         private readonly SessionManager _sessionManager;

         protected BaseApiController(BasePage page)
        {
            _sessionManager = new SessionManager(page);
        }

        /// <summary>
        /// Facade repository - Gives access to all other facades. Maybe use Unity later on; although this is cleaner.
        /// </summary>
        public static IFacadeFactory FacadeRepository
        {
            get
            {
                return WebSiteContext.GetInstance().FacadeRepository;
            }
        }

        /// <summary>
        /// Return the page namespace and class name as unique identifier
        /// </summary>
      
        public SessionManager SessionState
        {
            get { return _sessionManager; }
        }

        #region Nested type: SessionKeys

        protected class GlobalSessionKeys
        {
            //Put all global session goodies here!!;
        }

        #endregion
    }
}