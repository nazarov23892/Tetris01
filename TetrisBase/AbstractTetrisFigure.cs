using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TetrisBase
{
    public abstract class AbstractTetrisFigure
    {
        protected enum Angle
        {
            Angle_0, Angle_90, Angle_180, Angle_270
        }

        protected Angle angle = Angle.Angle_0;
        protected int _X = 0;
        protected int _Y = 0;
        protected List<TetrisPoint> points2 = new List<TetrisPoint>();

        public int X
        {
            get => this._X;
            set
            {
                int Xdelta = value - this._X;
                foreach (TetrisPoint point in this.points2)
                {
                    point.X += Xdelta;
                }
                this._X = value;
            }
        }

        public int Y
        {
            get { return this._Y; }
            set
            {
                int Ydelta = value - this._Y;
                foreach (TetrisPoint point in this.points2)
                {
                    point.Y += Ydelta;
                }
                this._Y = value;
            }
        }

        public abstract void RotateForward();

        public abstract void RotateBack();

        public (int X_Left, int X_Right, int Y_Bottom, int Y_Top) CalcSizePoints()
        {
            int x_left = 0;
            int x_right = 0;
            int y_bottom = 0;
            int y_top = 0;

            for (int i = 0; i < this.points2.Count; i++)
            {
                TetrisPoint point = this.points2[i];
                x_left = (i == 0 || point.X < x_left) ? point.X : x_left;
                x_right = (i == 0 || point.X > x_right) ? point.X : x_right;
                y_top = (i == 0 || point.Y > y_top) ? point.Y : y_top;
                y_bottom = (i == 0 || point.Y < y_bottom) ? point.Y : y_bottom;
            }
            return (x_left, x_right, y_bottom, y_top);
        }

        public int GetPointsCount()
        {
            return this.points2.Count;
        }

        public TetrisPoint GetPoint(int index)
        {
            return this.points2[index];
        }

        public abstract AbstractTetrisFigure CreateCopy();

        protected void AssignPointList(List<TetrisPoint> sourceList)
        {
            this.points2.Clear();
            foreach (TetrisPoint point in sourceList)
            {
                TetrisPoint pointCopy = new TetrisPoint(point);
                this.points2.Add(pointCopy);
            }
        }

        protected void AssignNextAngle()
        {
            Angle newAngle = Angle.Angle_0;
            switch (this.angle)
            {
                case Angle.Angle_0:
                    newAngle = Angle.Angle_90;
                    break;
                case Angle.Angle_90:
                    newAngle = Angle.Angle_180;
                    break;
                case Angle.Angle_180:
                    newAngle = Angle.Angle_270;
                    break;
                case Angle.Angle_270:
                    newAngle = Angle.Angle_0;
                    break;
                default:
                    new Exception();
                    break;
            }
            this.angle = newAngle;
        }

        protected void AssignPrevAngle()
        {
            Angle newAngle = Angle.Angle_0;
            switch (this.angle)
            {
                case Angle.Angle_270:
                    newAngle = Angle.Angle_180;
                    break;
                case Angle.Angle_180:
                    newAngle = Angle.Angle_90;
                    break;
                case Angle.Angle_90:
                    newAngle = Angle.Angle_0;
                    break;
                case Angle.Angle_0:
                    newAngle = Angle.Angle_270;
                    break;
                default:
                    new Exception();
                    break;
            }
            this.angle = newAngle;
        }
    }
}
