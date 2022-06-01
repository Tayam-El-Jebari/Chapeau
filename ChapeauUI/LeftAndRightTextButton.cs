using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChapeauUI
{
    public class LeftAndRightTextButton : Button
    {
        public string LeftText { get; set; }
        public string RightText { get; set; }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            SolidBrush leftTextBrush = new SolidBrush(this.ForeColor);

            //hide left text when stock isn't available
            if (this.ForeColor == Color.LightGray)
            {
                leftTextBrush = new SolidBrush(Color.Transparent);
            }
            using (leftTextBrush)
            {
                using (StringFormat sf = new StringFormat()
                { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center })
                {
                    pevent.Graphics.DrawString(LeftText, this.Font, leftTextBrush, this.ClientRectangle, sf);
                }
            }
            using (StringFormat sf = new StringFormat()
            { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Near })
            {
                pevent.Graphics.DrawString(RightText, new Font(this.Font.FontFamily, this.Font.Size - 2), new SolidBrush(this.ForeColor), this.ClientRectangle, sf);
            }

        }
    }
}
