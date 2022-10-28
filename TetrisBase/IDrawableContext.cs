namespace TetrisBase
{
    public interface IDrawableContext
    {
        TetrisColor OutlineColor
        {
            get; set;
        }

        int OutlineWidth
        {
            get; set;
        }

        int FontSize
        {
            get; set;
        }

        TetrisColor FontColor
        {
            get; set;
        }

        void DrawRectangleOutline(int x, int y, int width, int height);

        void DrawRectangleFillng(TetrisColor color, int x, int y, int width, int height);

        void DrawLine(int x1, int y1, int x2, int y2);

        void DrawString(string str, int x, int y);

        (int Height, int Width) CalcDrawedStringSize(string text);

        void Clear();

        void Flush();
    }
}
