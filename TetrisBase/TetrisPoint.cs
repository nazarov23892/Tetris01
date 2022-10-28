using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisBase
{
    public class TetrisPoint
    {
        private TetrisColor _Color = TetrisColor.None;
        private int _X = 0;
        private int _Y = 0;

        public TetrisPoint(int X, int Y)
        {
            this._X = X;
            this._Y = Y;
            this.Color = TetrisColor.None;
        }

        public TetrisPoint(TetrisColor Color)
        {
            this._Color = Color;
        }

        public TetrisPoint(int X, int Y, TetrisColor Color)
        {
            this._X = X;
            this._Y = Y;
            this._Color = Color;
        }

        public TetrisPoint(TetrisPoint SourcePoint)
        {
            this._X = SourcePoint._X;
            this._Y = SourcePoint._Y;
            this._Color = SourcePoint._Color;
        }

        public TetrisColor Color
        {
            get { return this._Color; }
            set { this._Color = value; }
        }

        public int X
        {
            get { return this._X; }
            set { this._X = value; }
        }

        public int Y
        {
            get { return this._Y; }
            set { this._Y = value; }
        }
    }

    public enum TetrisColor
    {
        None, Red, Blue, Green, Black, Yellow, Gray
    }



}
