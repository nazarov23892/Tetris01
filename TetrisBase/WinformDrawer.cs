using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TetrisBase;

namespace TetrisBase
{
    public class WinformDrawer : IDrawableContext, IDisposable
    {
        private System.Drawing.Graphics graphics = null;
        private System.Drawing.Pen outlinePen1 = null;
        private System.Drawing.SolidBrush outlineBrush1 = null;
        private System.Drawing.SolidBrush fontBrush1 = null;
        private System.Drawing.Font font1 = null;
        private System.Drawing.Color backColor1 = System.Drawing.Color.White;
        private const int FONT_SIZE_DEFAULT = 12;

        private System.Drawing.Bitmap bufferImage = null;
        private System.Drawing.Graphics bufferGraphics = null;

        public WinformDrawer(System.Drawing.Graphics graphics)
        {
            this.graphics = graphics;
            this.outlinePen1 = new System.Drawing.Pen(System.Drawing.Color.Black);
            this.outlineBrush1 = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
            this.fontBrush1 = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            this.font1 = CreateFont(FONT_SIZE_DEFAULT);
            int width = Convert.ToInt32(this.graphics.VisibleClipBounds.Width);
            int height = Convert.ToInt32(this.graphics.VisibleClipBounds.Height);
            this.bufferImage = new Bitmap(width, height);
            this.bufferGraphics = Graphics.FromImage(this.bufferImage);
        }

        public System.Drawing.Color BackColor
        {
            get => this.backColor1; 
            set => this.backColor1 = value; 
        }

        public System.Drawing.Graphics Graphics
        {
            get => this.graphics; 
            set => this.graphics = value ?? throw new Exception("graphics param is null"); 
        }

        public TetrisColor FontColor
        {
            get => this.ConvertColorToTetrisColor(fontBrush1.Color);
            set
            {
                Color color = this.ConvertTetrisColorToColor(value);
                if (this.fontBrush1.Color != color)
                {
                    this.fontBrush1.Color = color;
                }
            }
        }

        public int FontSize {
            get => Convert.ToInt32(this.font1.Size);
            set
            {
                if (this.font1.Height != value)
                {
                    font1.Dispose();
                    font1 = CreateFont(value);
                }
            }
        }

        public TetrisColor OutlineColor 
        { 
            get => this.ConvertColorToTetrisColor(this.outlinePen1.Color);
            set
            {
                Color color = this.ConvertTetrisColorToColor(value);
                if (this.outlinePen1.Color != color)
                {
                    this.outlinePen1.Color = color;
                }
            }
        }
        
        public int OutlineWidth 
        { 
            get => throw new NotImplementedException();
            set
            {
                int width = Convert.ToInt32(this.outlinePen1.Width);
                if (width != value)
                {
                    outlinePen1.Width = value;
                }
            }
        }

        public void Clear()
        {
            if (this.bufferGraphics == null)
            {
                return;
            }
            this.bufferGraphics.Clear(this.BackColor);
        }

        public void DrawLine(int x1, int y1, int x2, int y2)
        {
            if (this.bufferGraphics == null)
            {
                return;
            }
            bufferGraphics.DrawLine(this.outlinePen1, x1, y1, x2, y2);
        }

        public void DrawRectangleOutline(int x, int y, int width, int height)
        {
            if (this.bufferGraphics == null)
            {
                return;
            }
            bufferGraphics.DrawRectangle(this.outlinePen1, x, y, width, height);
        }

        public void DrawRectangleFillng(TetrisColor color, int x, int y, int width, int height)
        {
            if (this.bufferGraphics == null)
            {
                return;
            }
            if (color == TetrisColor.None)
            {
                return;
            }
            Color color1 = this.ConvertTetrisColorToColor(color);
            if (this.outlineBrush1.Color != color1)
            {
                this.outlineBrush1.Color = color1;
            }
            bufferGraphics.FillRectangle(this.outlineBrush1, x, y, width, height);
        }

        public void Dispose()
        {
            bufferGraphics.Dispose();
            bufferImage.Dispose();
            outlinePen1.Dispose();
            outlineBrush1.Dispose();
            fontBrush1.Dispose();
            font1.Dispose();
        }

        public void DrawString(string strLabel, int x, int y)
        {
            bufferGraphics.DrawString(strLabel, this.font1, this.fontBrush1, x, y);
        }

        public (int Height, int Width) CalcDrawedStringSize(string text)
        {
            SizeF sizeF = this.bufferGraphics.MeasureString(text, this.font1);
            int height = Convert.ToInt32(sizeF.Height);
            int width = Convert.ToInt32(sizeF.Width);
            return (height, width);
        }

        public void Flush()
        {
            this.graphics.DrawImage(this.bufferImage, 0, 0);
        }

        private Font CreateFont(int fontSize)
        {
            Font font = new Font(FontFamily.GenericMonospace, fontSize, FontStyle.Regular, GraphicsUnit.Point);
            return font;
        }

        private System.Drawing.Color ConvertTetrisColorToColor(TetrisColor color)
        {
            System.Drawing.Color color1;

            switch (color)
            {
                case TetrisColor.None:
                    color1 = System.Drawing.Color.Empty;
                    break;
                case TetrisColor.Red:
                    color1 = System.Drawing.Color.Red;
                    break;
                case TetrisColor.Blue:
                    color1 = System.Drawing.Color.Blue;
                    break;
                case TetrisColor.Green:
                    color1 = Color.Green;
                    break;
                case TetrisColor.Black:
                    color1 = System.Drawing.Color.Black;
                    break;
                case TetrisColor.Yellow:
                    color1 = System.Drawing.Color.Yellow;
                    break;
                case TetrisColor.Gray:
                    color1 = System.Drawing.Color.Gray;
                    break;
                default:
                    color1 = System.Drawing.Color.Empty;
                    break;
            }
            return color1;
        }

        private TetrisColor ConvertColorToTetrisColor(System.Drawing.Color color)
        {
            TetrisColor color1 = TetrisColor.None;
            if (color == Color.Black)
            {
                color1 = TetrisColor.Black;
            }
            else if (color == Color.Red)
            {
                color1 = TetrisColor.Red;
            }
            else if (color == Color.Blue)
            {
                color1 = TetrisColor.Blue;
            }
            else if (color == Color.Green)
            {
                color1 = TetrisColor.Green;
            }
            else if (color == Color.Yellow)
            {
                color1 = TetrisColor.Yellow;
            }
            else if(color == Color.Gray)
            {
                color1 = TetrisColor.Gray;
            }
            return color1;
        }
    }
}
