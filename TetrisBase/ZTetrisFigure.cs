using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisBase
{
    class ZTetrisFigure: AbstractTetrisFigure
    {
        private readonly List<TetrisPoint> TemplatePoints = new List<TetrisPoint>();

        public ZTetrisFigure(int X, int Y)
        {
            TemplatePoints.Add(new TetrisPoint(1, 1, TetrisColor.Red));
            TemplatePoints.Add(new TetrisPoint(0, 1, TetrisColor.None));
            TemplatePoints.Add(new TetrisPoint(0, 0, TetrisColor.None));
            TemplatePoints.Add(new TetrisPoint(1, 2, TetrisColor.Yellow));
            this.AssignPointList(TemplatePoints);
            this.X = X;
            this.Y = Y;
        }

        public override AbstractTetrisFigure CreateCopy()
        {
            ZTetrisFigure tetrisFigure = new ZTetrisFigure(0, 0);
            tetrisFigure.angle = angle;
            tetrisFigure._X = this._X;
            tetrisFigure._Y = this._Y;
            tetrisFigure.points2.Clear();
            foreach (var point1 in this.points2)
            {
                TetrisPoint point2 = new TetrisPoint(point1);
                tetrisFigure.points2.Add(point2);
            }
            return tetrisFigure;
        }

        public override void RotateBack()
        {
            this.AssignNextAngle();
            if (this.angle == Angle.Angle_90
                || this.angle == Angle.Angle_270)
            {
                this.points2[1].X += 1;
                this.points2[1].Y += 1;
                this.points2[2].X += 0;
                this.points2[2].Y += 2;
                this.points2[3].X += 1;
                this.points2[3].Y -= 1;
            }
            else if (this.angle == Angle.Angle_0
                || this.angle == Angle.Angle_180)
            {
                this.points2[1].X -= 1;
                this.points2[1].Y -= 1;
                this.points2[2].X += 0;
                this.points2[2].Y -= 2;
                this.points2[3].X -= 1;
                this.points2[3].Y += 1;
            }
        }

        public override void RotateForward()
        {
            this.AssignNextAngle();
            if (this.angle == Angle.Angle_90
                || this.angle == Angle.Angle_270)
            {
                this.points2[1].X += 1;
                this.points2[1].Y += 1;
                this.points2[2].X += 0;
                this.points2[2].Y += 2;
                this.points2[3].X += 1;
                this.points2[3].Y -= 1;
            }
            else if (this.angle == Angle.Angle_0
                || this.angle == Angle.Angle_180)
            {
                this.points2[1].X -= 1;
                this.points2[1].Y -= 1;
                this.points2[2].X += 0;
                this.points2[2].Y -= 2;
                this.points2[3].X -= 1;
                this.points2[3].Y += 1;
            }
        }
    }
}
