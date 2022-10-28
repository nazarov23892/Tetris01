using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisBase;

namespace TetrisBase
{
    class TetrisLevel
    {
        private readonly List<TetrisPoint> points = new List<TetrisPoint>();
        private int speed = 0;

        public int Speed
        {
            get { return this.speed; }
            set { this.speed = value; }
        }

        public int GetPointsCount()
        {
            return this.points.Count;
        }

        public TetrisPoint GetPointAt(int index)
        {
            return new TetrisPoint(this.points[index]);
        }

        public void AddPoint(TetrisPoint point)
        {
            foreach (TetrisPoint point1 in this.points)
            {
                if (point1.X == point.X
                    && point1.Y == point.Y)
                {
                    throw new Exception("point already exist");
                }
            }
            this.points.Add(new TetrisPoint(point));
        }
    }
}
