using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisBase
{
    public class TetrisCup
    {
        private readonly int Width_pt = 8;
        private readonly int Height_pt = 16;
        private readonly List<TetrisPoint> _Points = new List<TetrisPoint>();

        public TetrisCup(int Width_pt, int Height_pt)
        {
            this.Width_pt = Width_pt;
            this.Height_pt = Height_pt;
        }

        public TetrisCup(TetrisCup cup)
        {
            this.Width_pt = cup.Width_pt;
            this.Height_pt = cup.Height_pt;
            this._Points.Clear();
            foreach (TetrisPoint point in cup._Points)
            {
                this._Points.Add(new TetrisPoint(point));
            }
        }

        public int Width
        {
            get { return this.Width_pt; }
        }

        public int Height
        {
            get { return this.Height_pt; }
        }

        public void CopyFrom(TetrisCup cup)
        {
            if (this.Height != cup.Height
                || this.Width != cup.Width)
            {
                throw new Exception("incorrect copy using: size incompatible");
            }
            this._Points.Clear();
            for (int i = 0; i < cup.GetPointsCount(); i++)
            {
                TetrisPoint point = cup.GetPointAt(i);
                this._Points.Add(new TetrisPoint(point));
            }
        }

        public void AddPoint(int X, int Y, TetrisColor color)
        {
            if (X < 0 || X >= this.Width)
            {
                throw new Exception("invalid X value");
            }
            if (Y < 0 )
            {
                throw new Exception("invalid Y value");
            }
            TetrisPoint point = new TetrisPoint(X, Y, color);
            if( this._Points.Contains(point, new TetrisPointComparer()))
            {
                throw new Exception("point already exist");
            }
            this._Points.Add(point);
        }

        public void AddPoint(TetrisPoint point)
        {
            this.AddPoint(point.X, point.Y, point.Color);
        }

        public void AddPoints(IEnumerable<TetrisPoint> points)
        {
            foreach (TetrisPoint point in points)
            {
                this.AddPoint(point);
            }
        }

        public int GetPointsCount()
        {
            return this._Points.Count;
        }

        public TetrisPoint GetPointAt(int index)
        {
            return this._Points[index];
        }

        public bool IsFilledRow(int Y)
        {
            bool[] hasPoints = new bool[Width_pt];
            hasPoints.Initialize();
            foreach (TetrisPoint point in this._Points)
            {
                if (point.Y == Y)
                {
                    hasPoints[point.X] = true;
                }
            }
            foreach (bool item in hasPoints)
            {
                if (!item)
                {
                    return false;
                }
            }
            return true;
        }

        public void DeleteRow(int Y)
        {
            for (int i = this._Points.Count - 1; i >= 0 ; i--)
            {
                TetrisPoint point = _Points[i];
                if (point.Y == Y)
                {
                    this._Points.RemoveAt(i);
                }
                if (point.Y > Y)
                {
                    point.Y--;
                }
            }
        }

        public void Clear()
        {
            this._Points.Clear();
        }

        public bool CheckOverflow()
        {
            for (int i = 0; i < this._Points.Count; i++)
            {
                TetrisPoint point = this._Points[i];
                if (point.Y > Height_pt - 1)
                {
                    return true;
                }
            }
            return false;
        }

        private class TetrisPointComparer : System.Collections.Generic.IEqualityComparer<TetrisPoint>
        {
            public bool Equals(TetrisPoint x, TetrisPoint y)
            {
                if (x.X == y.X && x.Y == y.Y)
                {
                    return true;
                }
                return false;
            }

            public int GetHashCode(TetrisPoint obj)
            {
                throw new NotImplementedException();
            }
        }
    }
}
