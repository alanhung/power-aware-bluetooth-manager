using System.Drawing;
using System.Windows.Forms;

namespace PowerAwareBluetooth_UI.Common
{
    class DataGridIconColumn : DataGridColumnStyle
    {

        public Icon ColumnIcon
        {
            get;
            set;
        }

        public bool Center
        {
            get; set;
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
                    
                    int x;
                    int y;
                    if (Center)
                    {
                        x = bounds.X + (bounds.Width / 2) - ColumnIcon.Width / 2; ;
                        y = bounds.Y + (bounds.Height / 2) - ColumnIcon.Height / 2; ;
                    }
                    else
                    {
                        x = bounds.X;
                        y = bounds.Y;
                    }
                    g.DrawIcon(this.ColumnIcon, x, y);
                }
            }
        }
    }
}