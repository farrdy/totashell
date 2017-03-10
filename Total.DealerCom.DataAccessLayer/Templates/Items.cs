using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Total.DealerCom.DataAccessLayer.Templates
{
    public class Items : System.Collections.Generic.Queue<Item>
    {
        public void Enqueue(string Name, string Text)
        {
            Item Item = new Item();
            Item.Name = Name;
            Item.Text = Text;
            this.Enqueue(Item);
        }
    }
}
