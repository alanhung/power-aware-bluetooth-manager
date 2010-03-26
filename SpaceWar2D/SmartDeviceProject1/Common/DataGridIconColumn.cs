using System.Drawing;
using System.Windows.Forms;

namespace PowerAwareBluetooth.Common
{
    class DataGridIconColumn : DataGridColumnStyle
    {

        public Icon ColumnIcon
        {
            get;
            set;
        }

        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
        {

            // Fill in background color
            g.FillRectangle(backBrush, bounds);

            object drawIconObj = this.PropertyDescriptor.GetValue(source.List[rowNum]);
            if (drawIconObj is bool)
            {
                bool drawIcon = (bool) drawIconObj;
                if (drawIcon && ColumnIcon != null)
                {
                    g.DrawIcon(this.ColumnIcon, bounds.X, bounds.Y);
                }
            }
        }
    }

}
