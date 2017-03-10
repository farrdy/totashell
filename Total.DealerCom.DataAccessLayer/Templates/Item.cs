using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Total.DealerCom.DataAccessLayer.Templates
{
    public class Item
    {
        private string _Name;
        private string _Text;

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        public string Text
        {
            get
            {
                return _Text;
            }
            set
            {
                _Text = value;
            }
        }
    }
}
