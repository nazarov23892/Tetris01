using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisBase;

namespace TetrisBase
{
    class LineTetrisFigure : AbstractTetrisFigure
    {
        public LineTetrisFigure(int X, int Y)
        {
            this.points2 = new List<TetrisPoint>
            {
                new TetrisPoint(1, 0, TetrisColor.Yellow),
                new TetrisPoint(1, 1, TetrisColor.Red),
                new TetrisPoint(1, 2, TetrisColor.None),
                new TetrisPoint(1, 3, TetrisColor.Yellow)
            };
            this.X = X;
            this.Y = Y;
        }

        public override void RotateBack()
        {
            this.AssignPrevAngle();
            Angle newAngle = this.angle;

            switch (newAngle)
            {
                case Angle.Angle_0:
                    this.points2[0].X += 1;
                    this.points2[0].Y -= 1;
                    this.points2[2].X -= 1;
                    this.points2[2].Y += 1;
                    this.points2[3].X -= 2;
                    this.points2[3].Y += 2;
                    break;
                case Angle.Angle_90:
                    this.points2[0].X -= 1;
                    this.points2[0].Y += 1;
                    this.points2[2].X += 1;
                    this.points2[2].Y -= 1;
                    this.points2[3].X += 2;
                    this.points2[3].Y -= 2;
                    break;
                case Angle.Angle_180:
                    this.points2[0].X += 1;
                    this.points2[0].Y -= 1;
                    this.points2[2].X -= 1;
                    this.points2[2].Y += 1;
                    this.points2[3].X -= 2;
                    this.points2[3].Y += 2;
                    break;
                case Angle.Angle_270:
                    this.points2[0].X -= 1;
                    this.points2[0].Y += 1;
                    this.points2[2].X += 1;
                    this.points2[2].Y -= 1;
                    this.points2[3].X += 2;
                    this.points2[3].Y -= 2;
                    break;
                default:
                    break;
            }
        }

        public override void RotateForward()
        {
            this.AssignNextAngle();
            Angle newAngle = this.angle;
            
            if (newAngle == Angle.Angle_90
                || newAngle == Angle.Angle_270)
            {
                this.points2[0].X -= 1;
                this.points2[0].Y += 1;
                this.points2[2].X += 1;
                this.points2[2].Y -= 1;
                this.points2[3].X += 2;
                this.points2[3].Y -= 2;
            }
            else if (newAngle == Angle.Angle_0
                || newAngle == Angle.Angle_180)
            {
                this.points2[0].X += 1;
                this.points2[0].Y -= 1;
                this.points2[2].X -= 1;
                this.points2[2].Y += 1;
                this.points2[3].X -= 2;
                this.points2[3].Y += 2;
            }
        }

        public override AbstractTetrisFigure CreateCopy()
        {
            LineTetrisFigure tetrisFigure = new LineTetrisFigure(0, 0);
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

    }
}
