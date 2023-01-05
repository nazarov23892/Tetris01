using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisBase;

namespace TetrisBase
{
    public class TetrisBrickModel : ITetrisBrickModel
    {
        private readonly TetrisCup cup = null;
        private TetrisCup cupCopy = null;
        private AbstractTetrisFigure figure = null;
        private AbstractTetrisFigure nextFigure = null;
        private AbstractTetrisFigure planeFigure = null;
        private readonly ITetrisFigureCreator figureCreator = null;

        public AbstractTetrisFigure Figure
        {
            get => this.figure;
        }

        public TetrisCup Cup
        {
            get => this.cupCopy;
        }

        public AbstractTetrisFigure NextFigure
        {
            get => this.nextFigure;
        }

        public AbstractTetrisFigure PlaneFigure
        {
            get => this.planeFigure;
        }

        public int[] FilledRows 
        {
            get
            {
                List<int> rowIndexes = new List<int>();
                for (int i = cup.Height - 1; i >= 0; i--)
                {
                    if (this.cup.IsFilledRow(i))
                    {
                        rowIndexes.Add(i);
                    }
                }
                return rowIndexes.ToArray();
            }
        }

        public bool IsCupOverflowed => this.Cup.CheckOverflow();

        public TetrisBrickModel(int CupWidth, int CupHeight, ITetrisFigureCreator figureCreator)
        {
            this.cup = new TetrisCup(CupWidth, CupHeight);
            this.cupCopy = new TetrisCup(cup);

            this.figureCreator = figureCreator;
            this.AssignNextFigure();
        }

        public bool MoveLeft()
        {
            this.figure.X -= 1;
            if (this.CheckIntersection(this.figure))
            {
                this.figure.X += 1;
                return false;
            }
            this.UpdatePlaneFigure();
            return true;
        }

        public bool MoveRight()
        {
            this.figure.X += 1;
            if (this.CheckIntersection(this.figure))
            {
                this.figure.X -= 1;
                return false;
            }
            this.UpdatePlaneFigure();
            return true;
        }

        public bool MoveUp()
        {
            this.figure.Y += 1;
            this.UpdatePlaneFigure();
            return true;
        }

        public bool MoveDown()
        {
            this.figure.Y -= 1;
            if (this.CheckIntersection(this.figure))
            {
                this.figure.Y += 1;
                this.PutFigureToCup();
                this.AssignNextFigure();
                return false;
            }
            this.UpdatePlaneFigure();
            return true;
        }

        public bool Rotate()
        {
            this.figure.RotateForward();
            if (this.CheckIntersection(this.figure))
            {
                this.figure.RotateBack();
                return false;
            }
            this.UpdatePlaneFigure();
            return true;
        }

        private void AssignNextFigure()
        {
            AbstractTetrisFigure figure = this.nextFigure != null ? this.nextFigure : figureCreator.Create();
            this.nextFigure = figureCreator.Create();

            int cupWidth = cup.Width;
            int cupHeight = cup.Height;
            var figureSize = figure.CalcSizePoints();
            int center_x2 = (figureSize.X_Left + figureSize.X_Right) / 2;
            int bottom_y2 = figureSize.Y_Bottom;
            int cupCenter_x = (cupWidth / 2) - 1 + (cupWidth % 2 > 0 ? 1 : 0);
            int x_delta = cupCenter_x - center_x2;
            int y_delta = cupHeight - bottom_y2;
            figure.X += x_delta;
            figure.Y += y_delta;

            this.figure = figure;
            this.UpdatePlaneFigure();
        }

        public void AssignCupPoints(List<TetrisPoint> points)
        {
            this.cup.Clear();
            foreach (TetrisPoint point in points)
            {
                this.cup.AddPoint(point);
            }
            this.UpdateCupCopy();
        }

        public void Reset()
        {
            this.AssignNextFigure();
        }

        private void PutFigureToCup()
        {
            for (int i = 0; i < this.figure.GetPointsCount(); i++)
            {
                TetrisPoint point = this.figure.GetPoint(i);
                this.cup.AddPoint(point.X, point.Y, point.Color);
            }
            UpdateCupCopy();
        }

        private bool CheckIntersection(AbstractTetrisFigure figure1)
        {
            for (int i = 0; i < figure1.GetPointsCount(); i++)
            {
                TetrisPoint figurePoint = figure1.GetPoint(i);
                if (figurePoint.X < 0 || figurePoint.X >= this.cup.Width)
                {
                    return true;
                }
                if (figurePoint.Y < 0)
                {
                    return true;
                }
                for (int k = 0; k < this.cup.GetPointsCount(); k++)
                {
                    TetrisPoint cupPoint = this.cup.GetPointAt(k);
                    if (figurePoint.X == cupPoint.X
                        && figurePoint.Y == cupPoint.Y)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void UpdateCupCopy()
        {
            this.cupCopy = new TetrisCup(this.cup);
        }

        private void UpdatePlaneFigure()
        {
            int ITER_MAX = 64;
            planeFigure = this.figure.CreateCopy();
            int iter = 0;
            while(true)
            {
                if (iter > ITER_MAX)
                {
                    throw new Exception("OVER ITERATION");
                }
                this.planeFigure.Y -= 1;
                if (this.CheckIntersection(this.planeFigure))
                {
                    this.planeFigure.Y += 1;
                    break;
                }
                iter += 1;
            }
        }

        int ITetrisBrickModel.ExploseFilledRows()
        {
            int[] rowIndexes = this.FilledRows;
            if (rowIndexes.Length == 0)
            {
                return 0;
            }
            int counter = 0;
            foreach (int index in rowIndexes)
            {
                this.cup.DeleteRow(index);
                counter++;
            }
            this.UpdateCupCopy();
            return counter;
        }
    }
}

