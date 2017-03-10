using System.Web.UI;
using Total.DealerCom.DataAccessLayer.Facade.Interfaces;
using Total.DealerCom.DataAccessLayer.Utility;
using WebUI.Context;

namespace TotalDealer_2008
{
    public abstract class BasePage : Page
    {
        private readonly SessionManager _sessionManager;

        protected BasePage()
        {
            _sessionManager = new SessionManager(this);
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
        public string ScreenId
        {
            get
            {
                return Page.GetType().BaseType.FullName;
            }
        }

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