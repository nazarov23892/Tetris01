using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisBase;

namespace TetrisBase
{
    public interface ITetrisLevelSet
    {
        void Begin();

        int GetLevelNo();

        int GetLevelsCount();

        int GetLevelSpeed();

        int GetLevelPointsCount();

        TetrisPoint GetLevelPointAt(int index);

        bool IsEnd();

        bool Next();
    }
}
