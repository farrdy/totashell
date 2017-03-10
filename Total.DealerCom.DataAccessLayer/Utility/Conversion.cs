using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace Total.DealerCom.DataAccessLayer.Utility
{
    public static class Conversion
    {
        public static int MonthToInt(string month)
        {
            return DateTime.Parse("1." + month + " 2008").Month;
        }

        public static DropDownList PopulateMonths(ref DropDownList dropDownList)
        {
            dropDownList.Items.Clear();
            dropDownList.Items.AddRange(
                CultureInfo.CurrentCulture.DateTimeFormat.MonthNames.TakeWhile(x => !String.IsNullOrEmpty(x)).Select(
                    x => new ListItem(x)).ToArray());
            dropDownList.SelectedIndex = DateTime.Now.Date.Month - 1;
            return dropDownList;
        }

        public static DropDownList PopulateYears(ref DropDownList dropDownList, int currentYear)
        {
            dropDownList.Items.Clear();
            dropDownList.Items.AddRange(
                Enumerable.Range(currentYear - 7, 8).Select(x => new ListItem(String.Format("{0}", x))).ToArray());
            dropDownList.SelectedValue = DateTime.Now.Date.Year.ToString(CultureInfo.InvariantCulture);
            return dropDownList;
        }

        public static bool IsEarlierThan(DateTime fromDate, DateTime toDate)
        {
            return fromDate < toDate;
        }

        public static bool IsEarlierThan(string fromYear, string toYear, string fromMonth, string toMonth)
        {
            return IsEarlierThan(DateTime.Parse("1." + fromMonth + " " + fromYear),
                                 DateTime.Parse("28." + toMonth + " " + toYear));
        }

        public static bool IsEmail(string inputEmail)
        {
            if (string.IsNullOrEmpty(inputEmail)) return false;

            const string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                    @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                    @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

            return new Regex(strRegex).IsMatch(inputEmail);
        }
    }
}