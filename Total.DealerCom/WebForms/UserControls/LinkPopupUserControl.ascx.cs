using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TotalDealer_2008
{
    public partial class LinkPopupUserControl : System.Web.UI.UserControl
    {
        public string PopupQuerystingValue
        {
            get { return hdnserverQueryStringValue.Value; }
            set { hdnserverQueryStringValue.Value = value; }
        }

        public string PopupQuerystingName
        {
            get { return hdnquerystringName.Value; }
            set { hdnquerystringName.Value = value; }
        }

        public string Url
        {
            get { return hdnUrl.Value; }
            set { hdnUrl.Value = value; }
        }

        //public string CloseButtonImagepath
        //{
        //    get
        //    {
        //        return imgpopupclose.ImageUrl;
        //    }
        //    set
        //    {
        //        imgpopupclose.ImageUrl = value;
        //    }
        //}

        public string PopupTitle
        {
            get
            {
                return lblHeading.Text;
            }
            set
            {
                lblHeading.Text = value;
            }
        }

        public int Width
        {
            get
            {
                return Convert.ToInt32(hdniFrameWidth.Value);
            }
            set
            {
                hdniFrameWidth.Value = value.ToString();
            }
        }

        public int Height
        {
            get
            {
                return Convert.ToInt32(hdniFrameHeight.Value);
            }
            set
            {
                hdniFrameHeight.Value = value.ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            frmSearch.Attributes.Add("onload", "iframeLoaded()");
        }

        public void AddQuerystring(string key, string value)
        {
            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
            {
                if (string.IsNullOrEmpty(this.PopupQuerystingValue))
                {
                    this.PopupQuerystingValue = key + "=" + value;
                }
                else
                {
                    this.PopupQuerystingValue += "|" + key + "=" + value;
                }
            }
            else
            {
                throw new Exception(this.ID + " querystring error: Neither querystring key nor querystring value can be empty ");
            }
        }

    }
}