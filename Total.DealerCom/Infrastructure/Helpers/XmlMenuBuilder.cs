using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using System.Text;

namespace Total.DealerCom.Web.Infrastructure.Helper
{
    public static class XmlMenuBuilder
    {
        public static MvcHtmlString MainMenuBuilder(this HtmlHelper html, string xmlData, object attributes = null)
        {
            var menuXml = XDocument.Parse(xmlData);

            IEnumerable<XElement> headnodes = menuXml.Root.Descendants("Menu").Where(n => n.Element("Type").Value == "0");

            string FinalContainter = null;

            FinalContainter = BuildMenu(headnodes);

            return new MvcHtmlString(FinalContainter);
        }

        public static string BuildMenu(IEnumerable<XElement> headnodes)
        {
            string Containter = null;
            int i = 0;

            foreach (XElement node in headnodes)
            {
                TagBuilder ul = new TagBuilder("ul");
                TagBuilder li = new TagBuilder("li");
                TagBuilder a = new TagBuilder("a");

                if (node.Descendants("Menu").Any())
                {
                    ul.AddCssClass("dropdown-menu");

                    a = BuildListItemHtml(node, true);
                    a.AddCssClass("dropdown-toggle");
                    a.MergeAttribute("data-toggle", "dropdown");
                    a.MergeAttribute("href", "#");
                    a.MergeAttribute("role", "button");
                    a.MergeAttribute(" aria-haspopup", "true");
                    a.MergeAttribute("aria-expanded", "false");

                    ul.InnerHtml += BuildMenu(node.Descendants("Menu"));


                    li.AddCssClass("dropdown");
                    li.InnerHtml += a.ToString();
                    li.InnerHtml += ul.ToString();
                    Containter += li.ToString();
                }
                else
                {
                    Containter += BuildListItemHtml(node, false);
                }

                i++;
            }

            return Containter;
        }

        public static TagBuilder BuildListItemHtml(XElement element, bool isRoot)
        {

            TagBuilder a = new TagBuilder("a");
            a.InnerHtml = element.Element("MenuCaption").Value;
            a.MergeAttribute("href", isRoot ? "#" : element.Element("URL").Value);

            TagBuilder li = new TagBuilder("li");
            li.MergeAttribute("role", "presentation");
            li.InnerHtml = a.ToString();

            return isRoot ? a : li;
        }
    }
}