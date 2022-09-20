using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace GUI.Nhang_CustomControls
{
    public class NhangDateTimePicker: DateTimePicker
    {
        private Color skinColor = Color.MediumSlateBlue;
        private Color textColor = Color.White;
        private Color borderColor = Color.PaleVioletRed;
        private int borderSize = 0;

        private bool dropedDown = false;
        private Image calendarIcon = DoAnCuoiKi.Properties.Resources.WhitePicker;
        private RectangleF iconButtonArea;
        private const int calendarIconWidth = 34;
        private const int arrowIconWidth = 17;

        //Properties    
        public Color SkinColor { get => skinColor; 
            set 
            { 
                skinColor = value;
                if (skinColor.GetBrightness() >= 0.8F)
                    calendarIcon = DoAnCuoiKi.Properties.Resources.BlackPicker;
                else calendarIcon = DoAnCuoiKi.Properties.Resources.WhitePicker;
                this.Invalidate();
            } 
        }
        public Color TextColor { get => textColor; set => textColor = value; }
        public Color BorderColor { get => borderColor; set => borderColor = value; }
        public int BorderSize { get => borderSize; set => borderSize = value; }


        //Constructor
        public NhangDateTimePicker()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.MinimumSize = new Size(0, 35);
            this.Font = new Font(this.Font.Name, 9.5F);
        }
        //Overrid methods
        protected override void OnDropDown(EventArgs eventargs)
        {
            base.OnDropDown(eventargs);
            dropedDown = true;
        }
        protected override void OnCloseUp(EventArgs eventargs)
        {
            base.OnCloseUp(eventargs);
            dropedDown = false;
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            e.Handled = true;

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            using(Graphics graphics=this.CreateGraphics())
            using(Pen penBorder = new Pen(borderColor, borderSize))
            using(SolidBrush skinBrush = new SolidBrush(skinColor))
            using (SolidBrush openIconBrush = new SolidBrush(Color.FromArgb(50, 64, 64, 64)))
            using(SolidBrush textBrush = new SolidBrush(textColor))
            using(StringFormat textFormat = new StringFormat())
            {
                RectangleF clientArea = new RectangleF(0, 0, this.Width - 0.5F, this.Height - 0.5F);
                RectangleF iconArea = new RectangleF(clientArea.Width - calendarIconWidth, 0, calendarIconWidth, clientArea.Height);
                penBorder.Alignment = PenAlignment.Inset;
                textFormat.LineAlignment = StringAlignment.Center;

                //drawSurface
                graphics.FillRectangle(skinBrush, clientArea);
                //drawText
                graphics.DrawString("   " + this.Text, this.Font, textBrush, clientArea, textFormat);
                //Draw calendar Icon hightlight
                if (dropedDown == true) graphics.FillRectangle(openIconBrush, iconArea);
                //Draw border
                if (borderSize >= 1) graphics.DrawRectangle(penBorder, clientArea.X, clientArea.Y, clientArea.Width, clientArea.Height);
                //draw icon
                graphics.DrawImage(calendarIcon, this.Width - calendarIcon.Width - 9, (this.Height - calendarIcon.Height) / 2);
            }
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            int iconWidth = GetIconButtonWidth();
            iconButtonArea = new RectangleF(this.Width - iconWidth, 0, iconWidth, this.Height);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (iconButtonArea.Contains(e.Location))
                this.Cursor = Cursors.Hand;
            else this.Cursor = Cursors.Default;
        }
        //private methods
        private int GetIconButtonWidth()
        {
            int textWidth = TextRenderer.MeasureText(this.Text, this.Font).Width;
            if (textWidth <= this.Width - (calendarIconWidth + 20))
                return calendarIconWidth;
            else return arrowIconWidth;
        }

    }
}
