using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisBase;

namespace TetrisBase
{
    public class TetrisLevelSet : ITetrisLevelSet
    {
        private readonly List<TetrisLevel> levels = new List<TetrisLevel>();
        private int levelIndex = 0;

        public TetrisLevelSet()
        {
            InitLevels();
            levelIndex = 0;
        }

        public void Begin()
        {
            this.levelIndex = 0;
        }

        public int GetLevelNo()
        {
            return this.levelIndex;
        }

        public TetrisPoint GetLevelPointAt(int index)
        {
            TetrisLevel level = this.levels[this.levelIndex];
            TetrisPoint point = level.GetPointAt(index);
            return point != null 
                ? new TetrisPoint(point) 
                : null;
        }

        public int GetLevelPointsCount()
        {
            TetrisLevel level = this.levels[this.levelIndex];
            return level.GetPointsCount();
        }

        public int GetLevelsCount()
        {
            return this.levels.Count;
        }

        public int GetLevelSpeed()
        {
            TetrisLevel level = this.levels[this.levelIndex];
            return level.Speed;
        }

        public bool IsEnd()
        {
            return this.levelIndex >= this.levels.Count - 1;
        }

        public bool Next()
        {
            if (this.IsEnd())
            {
                return false;
            }
            this.levelIndex++;
            return true;
        }

        private void InitLevels()
        {
            TetrisLevel level_01 = new TetrisLevel();
            level_01.Speed = 0;
            level_01.AddPoint(new TetrisPoint(2, 0, TetrisColor.Green));
            level_01.AddPoint(new TetrisPoint(3, 0, TetrisColor.Yellow));
            this.levels.Add(level_01);

            TetrisLevel level_02 = new TetrisLevel();
            level_02.Speed = 1;
            level_02.AddPoint(new TetrisPoint(2, 0, TetrisColor.Green));
            level_02.AddPoint(new TetrisPoint(3, 0, TetrisColor.Yellow));
            level_02.AddPoint(new TetrisPoint(4, 0, TetrisColor.Yellow));
            this.levels.Add(level_02);

            TetrisLevel level_03 = new TetrisLevel();
            level_03.Speed = 2;
            level_03.AddPoint(new TetrisPoint(2, 0, TetrisColor.Green));
            level_03.AddPoint(new TetrisPoint(3, 0, TetrisColor.Yellow));
            level_03.AddPoint(new TetrisPoint(4, 0, TetrisColor.Yellow));
            level_03.AddPoint(new TetrisPoint(5, 0, TetrisColor.Yellow));
            level_03.AddPoint(new TetrisPoint(3, 1, TetrisColor.Green));
            level_03.AddPoint(new TetrisPoint(5, 1, TetrisColor.Yellow));
            level_03.AddPoint(new TetrisPoint(5, 6, TetrisColor.Yellow));
            level_03.AddPoint(new TetrisPoint(5, 7, TetrisColor.Yellow));
            level_03.AddPoint(new TetrisPoint(6, 7, TetrisColor.Yellow));
            this.levels.Add(level_03);
        }

        
    }
}
