using System.Collections;
using System.Collections.Specialized;
using Total.DealerCom.DataAccessLayer.Utility;

namespace TotalDealer_2008
{
    public class SessionManager
    {
        private readonly BasePage _page;

        public SessionManager(BasePage page)
        {
            _page = page;
        }

        public void Set(string key, object data, SessionScope scope)
        {
            string sessionKey = key;

            if (scope == SessionScope.Page)
            {
                sessionKey = _page.ScreenId + "|" + key;
            }

            _page.Session[sessionKey] = data;
        }

        public T Get<T>(string key, SessionScope scope)
        {
            string sessionKey = key;

            if (scope == SessionScope.Page)
            {
                sessionKey = _page.ScreenId + "|" + key;
            }

            return (T)_page.Session[sessionKey];
        }

        public bool Contains(string key, SessionScope scope)
        {
            string sessionKey = key;

            if (scope == SessionScope.Page)
            {
                sessionKey = _page.ScreenId + "|" + key;
            }

            return _page.Session[sessionKey] != null;
        }

        public void ClearItem(string key, SessionScope scope)
        {
            string sessionKey = key;

            if (scope == SessionScope.Page)
            {
                sessionKey = _page.ScreenId + "|" + key;
            }

            _page.Session.Remove(sessionKey);
        }

        public void ClearPageSession()
        {
            IEnumerator pos = _page.Session.GetEnumerator();

            var pageKeys = new StringCollection();
            while (pos.MoveNext())
            {
                var sessionKey = (string)pos.Current;
                pageKeys.Add(sessionKey);
            }

            foreach (string key in pageKeys)
            {
                _page.Session.Remove(key);
            }
        }

        public void ClearUserSession()
        {
            _page.Session.Clear();
        }
    }
}