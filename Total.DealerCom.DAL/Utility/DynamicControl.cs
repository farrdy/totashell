using System.Web.UI;
using System.Web.UI.WebControls;

namespace Services.Utility
{
    public static class DynamicControl
    {
        public static TableCell BuildCell(int height, int width, string value)
        {
            var cell = new TableCell();
            cell.Height = height;
            cell.Width = width;
            cell.Text = value;
            return cell;
        }

        public static TableCell BuildCell(int height, int width, Control value)
        {
            var cell = new TableCell();
            cell.Height = height;
            
            cell.Width = width;
            cell.Controls.Add(value);
            return cell;
        }

        public static TableCell BuildCell(int height, int width, Control value, string style)
        {
            var cell = new TableCell();
            cell.Height = height;
            cell.CssClass = style;
            cell.Width = width;
            cell.Controls.Add(value);
            return cell;
        }

        public static TableCell BuildCell(Control value, string style)
        {
            var cell = new TableCell();
            cell.CssClass = style;
            cell.Controls.Add(value);
            return cell;
        }

        public static TableRow BuildRow(TableCell[] theseCells)
        {
            var row = new TableRow();
            row.Cells.AddRange(theseCells);

            return row;
        }
        
    }
}
