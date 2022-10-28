using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisBase
{
    class OTetrisFigure : AbstractTetrisFigure
    {
        private readonly List<TetrisPoint> TemplatePoints = new List<TetrisPoint>();

        public OTetrisFigure(int X, int Y)
        {
            TemplatePoints.Add(new TetrisPoint(0, 0, TetrisColor.Green));
            TemplatePoints.Add(new TetrisPoint(1, 0, TetrisColor.Red));
            TemplatePoints.Add(new TetrisPoint(0, 1, TetrisColor.Yellow));
            TemplatePoints.Add(new TetrisPoint(1, 1, TetrisColor.None));
            this.AssignPointList(TemplatePoints);
            this.X = X;
            this.Y = Y;
        }

        public override AbstractTetrisFigure CreateCopy()
        {
            OTetrisFigure tetrisFigure = new OTetrisFigure(0, 0);
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
            this.AssignPrevAngle();
            Angle newAngle = this.angle;
            switch (newAngle)
            {
                case Angle.Angle_0:
                    this.points2[0].X -= 0;
                    this.points2[0].Y -= 1;
                    this.points2[1].X += 1;
                    this.points2[1].Y -= 0;
                    this.points2[2].X -= 1;
                    this.points2[2].Y -= 0;
                    this.points2[3].X -= 0;
                    this.points2[3].Y += 1;
                    break;
                case Angle.Angle_90:
                    this.points2[0].X -= 1;
                    this.points2[0].Y -= 0;
                    this.points2[1].X -= 0;
                    this.points2[1].Y -= 1;
                    this.points2[2].X -= 0;
                    this.points2[2].Y += 1;
                    this.points2[3].X += 1;
                    this.points2[3].Y += 0;
                    break;
                case Angle.Angle_180:
                    this.points2[0].X -= 0;
                    this.points2[0].Y += 1;
                    this.points2[1].X -= 1;
                    this.points2[1].Y -= 0;
                    this.points2[2].X += 1;
                    this.points2[2].Y -= 0;
                    this.points2[3].X -= 0;
                    this.points2[3].Y -= 1;
                    break;
                case Angle.Angle_270:
                    this.points2[0].X += 1;
                    this.points2[0].Y -= 0;
                    this.points2[1].X -= 0;
                    this.points2[1].Y += 1;
                    this.points2[2].X -= 0;
                    this.points2[2].Y -= 1;
                    this.points2[3].X -= 1;
                    this.points2[3].Y -= 0;
                    break;
                default:
                    //
                    break;
            }
        }

        public override void RotateForward()
        {
            this.AssignNextAngle();
            Angle newAngle = this.angle;
            switch (newAngle)
            {
                case Angle.Angle_0:
                    this.points2[0].X -= 1;
                    this.points2[0].Y += 0;
                    this.points2[1].X += 0;
                    this.points2[1].Y -= 1;
                    this.points2[2].X += 0;
                    this.points2[2].Y += 1;
                    this.points2[3].X += 1;
                    this.points2[3].Y += 0;
                    break;
                case Angle.Angle_90:
                    this.points2[0].X += 0;
                    this.points2[0].Y += 1;
                    this.points2[1].X -= 1;
                    this.points2[1].Y += 0;
                    this.points2[2].X += 1;
                    this.points2[2].Y += 0;
                    this.points2[3].X += 0;
                    this.points2[3].Y -= 1;
                    break;
                case Angle.Angle_180:
                    this.points2[0].X += 1;
                    this.points2[0].Y += 0;
                    this.points2[1].X += 0;
                    this.points2[1].Y += 1;
                    this.points2[2].X += 0;
                    this.points2[2].Y -= 1;
                    this.points2[3].X -= 1;
                    this.points2[3].Y -= 0;
                    break;
                case Angle.Angle_270:
                    this.points2[0].X += 0;
                    this.points2[0].Y -= 1;
                    this.points2[1].X += 1;
                    this.points2[1].Y += 0;
                    this.points2[2].X -= 1;
                    this.points2[2].Y += 0;
                    this.points2[3].X += 0;
                    this.points2[3].Y += 1;
                    break;
                default:
                    //
                    break;
            }
        }
    }
}
