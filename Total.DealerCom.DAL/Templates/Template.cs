using  System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Services.Templates
{
    public class Template
    {
        public string Build(string Path, Items Items)
        {
            string FileText = File.ReadAllText(Path);

            foreach (Item item in Items)
            {
                FileText = FileText.Replace(item.Name, item.Text);
            }
            return FileText;
        }



        public string BuildWithThisText(string FileText, Items Items)
        {
          
            foreach (Item item in Items)
            {
                FileText = FileText.Replace(item.Name, item.Text);
            }
            return FileText;
        }


    }
}
